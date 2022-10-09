using FARTS_Machine.FARTSOptions;
using System.Collections.Generic;

namespace FARTS_Machine.Mnemonics
{
    internal class MnemonicsHelper
    {

        public static string[] Mnemonics_SuperJump = {
            "use32",
            "fstp dword ptr esi+0x5C",
            "mov dword [esi+0x5C],0x41A00000",
            "mov eax,[esi+0x1C]",
        };

        public static string[] Mnemonics_InstantBounty = {
            "use32",
            "fstp dword ptr edi+04",
            "mov dword [edi+04],0x4479C000",
            "lea eax,[esp+20]"
        };

        public static string[] Mnemonics_OneLastShot1 = {
            "use32",
            "mov dword [ebx+0xA0],0"
        };

        public static string[] Mnemonics_OneLastShot2 = {
            "use32",
            "mov dword [ebx+0xA4],0"
        };

        public static string[] Mnemonics_NoThirdPersonMovement = {
            "use32",
            "add dword [ecx+0x20],0x42C80000"
        };

        public static string[] Mnemonics_MicroJump = {
            "use32",
            "fstp dword ptr esi+0x5C",
            "mov dword [esi+0x5C],0x40E00000",
            "mov eax,[esi+0x1C]",
        };

        public List<FARTSOptionBase> PreparedOptions()
        {
            List<FARTSOptionBase> optionsList = new List<FARTSOptionBase>();

            //TESTED:
            optionsList.Add(new FARTSOptionBase { Name = "No Damage", OptionId = (int)InternalOptionIds.DamageFreeze, DurationInSeconds = 20, AddressToChange = "base+0x6A6D5", AlteredBytes = new byte[] { 0x90, 0x90 }, OriginalBytes = new byte[] { 0xD9, 0x11 } });
            optionsList.Add(new FARTSOptionBase { Name = "Stamina Freeze", OptionId = (int)InternalOptionIds.StaminaFreeze, DurationInSeconds = 20, AddressToChange = "base+0x6AC3F", AlteredBytes = new byte[] { 0x90, 0x90, 0x90 }, OriginalBytes = new byte[] { 0xD9, 0x56, 0x18 } });
            optionsList.Add(new FARTSOptionBase { Name = "Infinite Ammo", OptionId = (int)InternalOptionIds.InfiniteAmmo, DurationInSeconds = 20 });
            optionsList.Add(new FARTSOptionBase { Name = "Remove 100 Health", OptionId = (int)InternalOptionIds.RemoveHealth });
            optionsList.Add(new FARTSOptionBase { Name = "Sudden Death", OptionId = (int)InternalOptionIds.SuddenDeath });
            optionsList.Add(new FARTSOptionBase { Name = "Heal Stranger", OptionId = (int)InternalOptionIds.AddHealth });
            optionsList.Add(new FARTSOptionBase { Name = "Remove Stamina", OptionId = (int)InternalOptionIds.RemoveStamina });
            optionsList.Add(new FARTSOptionBase { Name = "Refill Stamina", OptionId = (int)InternalOptionIds.AddStamina });
            optionsList.Add(new FARTSOptionBase { Name = "Sensitive 3rd Person Camera", OptionId = (int)InternalOptionIds.SensitiveCamera, DurationInSeconds = 40, AddressToChange = "base+0x25B87C", AlteredBytes = new byte[] { 0x90, 0x90 }, OriginalBytes = new byte[] { 0x89, 0x10 } });
            optionsList.Add(new FARTSOptionBase { Name = "Bird's Eye Camera", OptionId = (int)InternalOptionIds.GTACamera, DurationInSeconds = 40, AddressToChange = "base+0x25B87E", AlteredBytes = new byte[] { 0x90, 0x90, 0x90 }, OriginalBytes = new byte[] { 0x89, 0x48, 0x04 } });
            optionsList.Add(new FARTSOptionBase { Name = "No 3rd Person Camera Control", OptionId = (int)InternalOptionIds.NoThirdPersonCamera, DurationInSeconds = 40, AddressToChange = "base+0x1A66B", AlteredBytes = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, OriginalBytes = new byte[] { 0x8B, 0x84, 0x24, 0x24, 0x01, 0x00, 0x00 } });
            optionsList.Add(new FARTSOptionBase { Name = "No Jumping", OptionId = (int)InternalOptionIds.NoJump, DurationInSeconds = 40, AddressToChange = "base+0x25B6C1", AlteredBytes = new byte[] { 0x90, 0x90, 0x90 }, OriginalBytes = new byte[] { 0x8A, 0x40, 0x10 } });
            optionsList.Add(new FARTSOptionBase { Name = "No Floor Collision", OptionId = (int)InternalOptionIds.NoFloor, DurationInSeconds = 10, AddressToChange = "base+0x223D8F", AlteredBytes = new byte[] { 0x90, 0x90, 0x90 }, OriginalBytes = new byte[] { 0xD9, 0x40, 0x08 } });
            optionsList.Add(new FARTSOptionBase { Name = "Instant Bounty", OptionId = (int)InternalOptionIds.InstantBounty, DurationInSeconds = 30 });
            optionsList.Add(new FARTSOptionBase { Name = "Reduce Ammo to 1", OptionId = (int)InternalOptionIds.OneLastShot, DurationInSeconds = 40 });
            optionsList.Add(new FARTSOptionBase { Name = "Lose Control over Stranger", OptionId = (int)InternalOptionIds.Freeze, DurationInSeconds = 10, AddressToChange = "base+0x25BCA7", AlteredBytes = new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90 }, OriginalBytes = new byte[] { 0xB9, 0x0F, 0x00, 0x00, 0x00 } });
            optionsList.Add(new FARTSOptionBase { Name = "No 3rd Person Movement", OptionId = (int)InternalOptionIds.NoThirdPersonMovement, DurationInSeconds = 40, AddressToChange = "base+0x25B855", OriginalBytes = new byte[] { 0x8B, 0x49, 0x20, 0x89, 0x10 } });
            optionsList.Add(new FARTSOptionBase { Name = "Micro Jump", OptionId = (int)InternalOptionIds.MicroJump, DurationInSeconds = 40 });
            optionsList.Add(new FARTSOptionBase { Name = "Lock Camera", OptionId = (int)InternalOptionIds.LockCamera, DurationInSeconds = 40, AddressToChange = "base+0x25B6A8", AlteredBytes = new byte[] { 0x90, 0x90, 0x90 }, OriginalBytes = new byte[] { 0x8A, 0x40, 0x08 } });
            optionsList.Add(new FARTSOptionBase { Name = "Super Jump", OptionId = (int)InternalOptionIds.SuperJump, DurationInSeconds = 40 });
            optionsList.Add(new FARTSOptionBase { Name = "Kill Stranger", OptionId = (int)InternalOptionIds.KillStranger });
            optionsList.Add(new FARTSOptionBase { Name = "Freeze Stranger", OptionId = (int)InternalOptionIds.Freeze, DurationInSeconds = 15 });
            optionsList.Add(new FARTSOptionBase { Name = "No 1st Person Movement", OptionId = (int)InternalOptionIds.NoFirstPersonMovement, DurationInSeconds = 40 });
            optionsList.Add(new FARTSOptionBase { Name = "Invincible Stranger", OptionId = (int)InternalOptionIds.Invincible, DurationInSeconds = 40 });

            //IN TEST:

            //OPEN:
            //this._availableOptions.Add(new CrowdOption { Name = "Slow-Motion", OptionId = (int)InternalOptionIds.SlowDown, DurationInSeconds = 40 });
            //this._availableOptions.Add(new CrowdOption { Name = "Fast-Motion", OptionId = (int)InternalOptionIds.SpeedUp, DurationInSeconds = 40 });

            return optionsList;
        }
    }
}
