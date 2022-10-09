namespace FARTS_Machine.FARTSOptions
{
    public class FARTSOptionBase
    {
        public string Name;
        public int OptionId;
        public int? DurationInSeconds;
        public int? ChoiceNumber;
        public string AddressToChange;
        public byte[] AlteredBytes;
        public byte[] OriginalBytes;
    }

    public enum InternalOptionIds
    {
        VisualChaos = 1,
        DamageFreeze = 2,
        StaminaFreeze = 3,
        InfiniteAmmo = 4,
        OneLastShot = 5,
        RemoveHealth = 6,
        AddHealth = 7,
        RemoveStamina = 8,
        AddStamina = 9,
        Freeze = 10,
        NoThirdPersonMovement = 11,
        ThirdPersonLeftIsRight = 12,
        FirstPersonNoStrafing = 13,
        FirstPersonNoForwardBack = 14,
        SensitiveCamera = 15,
        GTACamera = 16,
        NoThirdPersonCamera = 17,
        NoJump = 18,
        LockCamera = 19,
        NoFloor = 20,
        InstantBounty = 21,
        SuperJump = 22,
        SlowDown = 23,
        SpeedUp = 24,
        SuddenDeath = 25,
        MicroJump = 26,
        KillStranger = 27,
        NoFirstPersonMovement = 28,
        Invincible = 29,
    }
}
