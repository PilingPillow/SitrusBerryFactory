namespace SitrusBerryFactory.settings
{
    public static class Config
    {
        // Trainer class names
        public static string TrainerClassNameTableOffset = Pointer(0xD80A0);
        public static string TrainerClassNameEntryLength = Int(0xD);
        // Trainer prize multi
        public static string TrainerClassPrizeMultiTableOffset = Pointer(0x259CC);
        // Trainer addtional data
        public static string EnableTrainerClassEncMusic = Bool(false);
        public static string TrainerClassEncMusicTableOffset = ToDo(/* gClassBasedTrainerEncounterBGM */);
        public static string EnableTrainerClassBattleMusic = Bool(false);
        public static string TrainerClassBattleMusicTableOffset = ToDo(/* gClassBasedBattleBGM */);
        public static string EnableTrainerClassPokeBall = Bool(false);
        public static string TrainerClassPokeBallTableOffset = ToDo(/* gClassPokeBalls */);
        public static string EnableTrainerClassBaseIV = Bool(false);
        public static string TrainerClassBaseIVTableOffset = ToDo(/* gBaseIVsByTrainerClass */);

        // Trainer sprites
        public static string TrainerSpriteImageTableOffset = Pointer(0x3473C);
        public static string TrainerSpritePaletteTableOffset = Pointer(0x3474C);
        public static string TrainerSpriteYPosTableOffset = Pointer(0x37E78);

        // These are all dummy
        public static string Int(int _) => string.Empty;
        public static string Pointer(int _) => string.Empty;
        public static string Bool(bool _) => string.Empty;
        public static string ToDo() => string.Empty;
    }
}
