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
    }
}
