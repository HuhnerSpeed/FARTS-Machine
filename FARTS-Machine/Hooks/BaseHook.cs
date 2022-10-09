using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reloaded.Assembler;
using Reloaded.Assembler.Definitions;
using Memory;
using FARTS_Machine.FARTSOptions;
using System.Media;
using FARTS_Machine.Mnemonics;

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

        public void StartRandomizer()
        {
            this._randomizer = new Random();
            this._availableOptions = this._mnemonicsHelper.PreparedOptions();
            this._jumpHeightLocation = this._memory.AoBScan("D9 5E 5C 8B 46 1C").Result.FirstOrDefault().ToString("x8");
            this._instantBountyLocation = this._memory.AoBScan("D9 5F 04 8D 44 24 14").Result.FirstOrDefault().ToString("x8");
            this._oneLastShot1Location = this._memory.AoBScan("89 83 A0 00 00 00").Result.FirstOrDefault().ToString("x8");
            this._oneLastShot2Location = this._memory.AoBScan("89 83 A4 00 00 00").Result.FirstOrDefault().ToString("x8");
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
