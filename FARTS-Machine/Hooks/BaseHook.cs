using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Reloaded.Assembler;
using Reloaded.Assembler.Definitions;
using Memory;
using FARTS_Machine.FARTSOptions;
using System.Media;
using FARTS_Machine.Mnemonics;
using System.IO;

namespace FARTS_Machine.Hooks
{
    internal class BaseHook
    {
        public BaseHook()
        {
            this._memory = new Mem();
            this._assembler = new Assembler();
            this._mnemonicsHelper = new MnemonicsHelper();
        }

        public bool IsAttached = false;

        private List<FARTSOptionBase> _availableOptions;
        private List<FARTSOptionBase> _nextOptions;
        private FARTSOptionBase _activeOption;
        private Random _randomizer;
        private SoundPlayer _soundPlayerHealth;
        private SoundPlayer _soundPlayerDamage;
        private SoundPlayer _soundPlayerEffectStart;
        private SoundPlayer _soundPlayerEffectEnd;
        private Mem _memory;
        private Assembler _assembler;
        private MnemonicsHelper _mnemonicsHelper;
        private byte[] _originalJumpHeightBytes = { 0xD9, 0x5E, 0x5C, 0x8B, 0x46, 0x1C };
        private byte[] _originalInstantBountyBytes = { 0xD9, 0x5F, 0x04, 0x8D, 0x44, 0x24, 0x14 };
        private byte[] _originalOneLastShot1Bytes = { 0x89, 0x83, 0xA0, 0x00, 0x00, 0x00 };
        private byte[] _originalOneLastShot2Bytes = { 0xA0, 0x00, 0x00, 0x00 };
        private string _jumpHeightLocation;
        private string _instantBountyLocation;
        private string _oneLastShot1Location;
        private string _oneLastShot2Location;

        public void AttachToProcess()
        {
            int processId = this._memory.GetProcIdFromName("stranger");
            if (processId > 0)
            {
                this._memory.OpenProcess(processId);
                this.IsAttached = true;
            }
        }

        public void Setup()
        {
            var directory = Directory.GetCurrentDirectory();
            this._randomizer = new Random();
            this._availableOptions = this._mnemonicsHelper.PreparedOptions();
            this._jumpHeightLocation = this._memory.AoBScan("D9 5E 5C 8B 46 1C").Result.FirstOrDefault().ToString("x8");
            this._instantBountyLocation = this._memory.AoBScan("D9 5F 04 8D 44 24 14").Result.FirstOrDefault().ToString("x8");
            this._oneLastShot1Location = this._memory.AoBScan("89 83 A0 00 00 00").Result.FirstOrDefault().ToString("x8");
            this._oneLastShot2Location = this._memory.AoBScan("89 83 A4 00 00 00").Result.FirstOrDefault().ToString("x8");
            this._nextOptions = new List<FARTSOptionBase>();
            this._soundPlayerHealth = new SoundPlayer(directory + "\\Sounds\\heal.wav");
            this._soundPlayerDamage = new SoundPlayer(directory + "\\Sounds\\damage.wav");
            this._soundPlayerEffectStart = new SoundPlayer(directory + "\\Sounds\\effect.wav");
            this._soundPlayerEffectEnd = new SoundPlayer(directory + "\\Sounds\\effectEnded.wav");
        }

        public void RandomizeNextOption()
        {
            this._nextOptions.Add(this._availableOptions[this._randomizer.Next(this._availableOptions.Count)]);
            this.ExecuteOption();
        }

        public void SetManualOption(FARTSOptionBase option)
        {
            if (this._nextOptions == null)
            {
                this._nextOptions = new List<FARTSOptionBase>();
            }
            this._nextOptions.Add(option);
            this.ExecuteOption();
        }

        public void ExecuteOption()
        {
            if (this._activeOption == null)
            {
                this._activeOption = new FARTSOptionBase();
            }
            this._activeOption = this._nextOptions[0];

            switch (this._activeOption.OptionId)
            {
                case (int)InternalOptionIds.InfiniteAmmo:
                    this._memory.WriteBytes("base+0xAA779", new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 });
                    this._memory.WriteBytes("base+0xAA78F", new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 });
                    this._soundPlayerEffectStart.Play();
                    break;

                case (int)InternalOptionIds.RemoveHealth:
                    this._memory.WriteMemory("base+0x0064C458,0xCF8", "float", (this._memory.ReadFloat("base+0x0064C458,0xCF8") - 100).ToString());
                    this._memory.WriteMemory("base+0x00414680,0x78", "float", (this._memory.ReadFloat("base+0x00414680,0x78") - 100).ToString());
                    this._soundPlayerDamage.Play();
                    break;

                case (int)InternalOptionIds.KillStranger:
                    this._memory.WriteMemory("base+0x0064C458,0xCF8", "float", "0");
                    this._memory.WriteMemory("base+0x00414680,0x78", "float", "0");
                    this._soundPlayerDamage.Play();
                    break;

                case (int)InternalOptionIds.AddHealth:
                    this._memory.WriteMemory("base+0x0064C458,0xCF8", "float", "300");
                    this._memory.WriteMemory("base+0x00414680,0x78", "float", "300");
                    this._soundPlayerHealth.Play();
                    break;

                case (int)InternalOptionIds.RemoveStamina:
                    this._memory.WriteMemory("base+0x0065178C,0x0,0x8C", "float", "0");
                    this._soundPlayerDamage.Play();
                    break;

                case (int)InternalOptionIds.AddStamina:
                    this._memory.WriteMemory("base+0x0065178C,0x0,0x8C", "float", "150");
                    this._soundPlayerHealth.Play();
                    break;

                case (int)InternalOptionIds.SuddenDeath:
                    this._memory.WriteMemory("base+0x0064C458,0xCF8", "float", "1");
                    this._memory.WriteMemory("base+0x00414680,0x78", "float", "1");
                    this._soundPlayerEffectStart.Play();
                    break;

                case (int)InternalOptionIds.Freeze:
                    this._memory.WriteBytes("base+0x25B86A", new byte[] { 0x90, 0x90, 0x90 });
                    this._memory.WriteBytes("base+0x25B86D", new byte[] { 0x90, 0x90, 0x90 });
                    this.AssembleMnemonics("base+0x25B855", MnemonicsHelper.Mnemonics_NoThirdPersonMovement, 5);
                    this._soundPlayerEffectStart.Play();
                    break;

                case (int)InternalOptionIds.NoFirstPersonMovement:
                    this._memory.WriteBytes("base+0x25B86A", new byte[] { 0x90, 0x90, 0x90 });
                    this._memory.WriteBytes("base+0x25B86D", new byte[] { 0x90, 0x90, 0x90 });
                    this._soundPlayerEffectStart.Play();
                    break;

                case (int)InternalOptionIds.Invincible:
                    this._memory.FreezeValue("base+0x0064C458,0xCF8", "float", "300");
                    this._memory.FreezeValue("base+0x00414680,0x78", "float", "300");
                    this._soundPlayerEffectStart.Play();
                    break;

                case (int)InternalOptionIds.SuperJump:
                    this.AssembleMnemonics(this._jumpHeightLocation, MnemonicsHelper.Mnemonics_SuperJump, 6);
                    this._soundPlayerEffectStart.Play();
                    break;

                case (int)InternalOptionIds.MicroJump:
                    this.AssembleMnemonics(this._jumpHeightLocation, MnemonicsHelper.Mnemonics_MicroJump, 6);
                    this._soundPlayerEffectStart.Play();
                    break;

                case (int)InternalOptionIds.InstantBounty:
                    this.AssembleMnemonics(this._instantBountyLocation, MnemonicsHelper.Mnemonics_InstantBounty, 7);
                    this._soundPlayerEffectStart.Play();
                    break;

                case (int)InternalOptionIds.OneLastShot:
                    this.AssembleMnemonics(this._oneLastShot1Location, MnemonicsHelper.Mnemonics_OneLastShot1, 6);
                    this.AssembleMnemonics(this._oneLastShot2Location, MnemonicsHelper.Mnemonics_OneLastShot2, 6);
                    this._soundPlayerEffectStart.Play();
                    break;

                case (int)InternalOptionIds.NoThirdPersonMovement:
                    this.AssembleMnemonics(this._activeOption.AddressToChange, MnemonicsHelper.Mnemonics_NoThirdPersonMovement, 5);
                    this._soundPlayerEffectStart.Play();
                    break;

                default:
                    this._memory.WriteBytes(this._activeOption.AddressToChange, this._activeOption.AlteredBytes);
                    this._soundPlayerEffectStart.Play();
                    break;
            }
            this._nextOptions.Clear();
        }

        public int GetActiveOptionDuration()
        {
            if (this._activeOption.DurationInSeconds.HasValue)
            {
                return (int)this._activeOption.DurationInSeconds;
            }
            return 0;
        }

        public void ResetActiveOption()
        {
            if (this._activeOption != null && this._activeOption.DurationInSeconds.HasValue)
            {
                switch (this._activeOption.OptionId)
                {
                    case (int)InternalOptionIds.InfiniteAmmo:
                    case (int)InternalOptionIds.OneLastShot:
                        this._memory.WriteBytes("base+0xAA779", new byte[] { 0x89, 0x83, 0xA4, 0x00, 0x00, 0x00 });
                        this._memory.WriteBytes("base+0xAA78F", new byte[] { 0x89, 0x83, 0xA0, 0x00, 0x00, 0x00 });
                        break;

                    case (int)InternalOptionIds.Freeze:
                        this._memory.WriteBytes("base+0x25B855", new byte[] { 0x8B, 0x49, 0x20, 0x89, 0x10 });
                        this._memory.WriteBytes("base+0x25B86A", new byte[] { 0x8B, 0x51, 0x2C });
                        this._memory.WriteBytes("base+0x25B86D", new byte[] { 0x8B, 0x49, 0x30 });
                        break;

                    case (int)InternalOptionIds.NoFirstPersonMovement:
                        this._memory.WriteBytes("base+0x25B86A", new byte[] { 0x8B, 0x51, 0x2C });
                        this._memory.WriteBytes("base+0x25B86D", new byte[] { 0x8B, 0x49, 0x30 });
                        break;

                    case (int)InternalOptionIds.Invincible:
                        this._memory.UnfreezeValue("base+0x0064C458,0xCF8");
                        this._memory.UnfreezeValue("base+0x00414680,0x78");
                        break;

                    case (int)InternalOptionIds.SuperJump:
                    case (int)InternalOptionIds.MicroJump:
                        this._memory.WriteBytes("0x" + this._jumpHeightLocation, this._originalJumpHeightBytes);
                        break;

                    case (int)InternalOptionIds.InstantBounty:
                        this._memory.WriteBytes("0x" + this._instantBountyLocation, this._originalInstantBountyBytes);
                        break;

                    default:
                        this._memory.WriteBytes(this._activeOption.AddressToChange, this._activeOption.OriginalBytes);
                        break;
                }
                this._soundPlayerEffectEnd.Play();
                this._activeOption = null;
            }
        }

        public string GetActiveOptionName()
        {
            return this._activeOption?.Name;
        }

        private void ShuffleOptions()
        {
            List<FARTSOptionBase> threeChoices = new List<FARTSOptionBase>();
            List<int> alreadyUsedNumbers = new List<int>();

            for (int i = 1; i < 4; i++)
            {
                int randomChoice = this._randomizer.Next(this._availableOptions.Count);
                if (alreadyUsedNumbers.Contains(randomChoice))
                {
                    i--;
                }
                else
                {
                    var choice = this._availableOptions[randomChoice];
                    choice.ChoiceNumber = i;
                    threeChoices.Add(choice);
                    alreadyUsedNumbers.Add(randomChoice);
                }
            }
            this._nextOptions = threeChoices;
        }

        private void AssembleMnemonics(string location, string[] mnemonics, int replaceCount)
        {
            byte[] changeBytes;

            try
            {
                changeBytes = this._assembler.Assemble(mnemonics);
                this._memory.CreateCodeCave(location, changeBytes, replaceCount);
            }
            catch (FasmException e)
            {
                Debug.WriteLine($"Error: {e.Result}");
                Debug.WriteLine($"Line: {e.Line}");
                Debug.WriteLine($"Code: {e.ErrorCode}");
                Debug.WriteLine("Mnemonics:");
                foreach (var mnemonic in e.Mnemonics)
                {
                    Debug.WriteLine(mnemonic);
                }
            }
        }
    }
}
