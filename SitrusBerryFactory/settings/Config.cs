namespace SitrusBerryFactory.settings
{
    public static class Config
    {
        // Trainer class names
        public static int TrainerClassNameTableOffset = Pointer(0xD80A0);
        public static int TrainerClassNameEntryLength = 0xD;
        // Trainer prize multi
        public static int TrainerClassPrizeMultiTableOffset = Pointer(0x259CC);
        // Trainer addtional data
        public static bool EnableTrainerClassEncMusic = false;
        public static int TrainerClassEncMusicTableOffset = ToDo(/* gClassBasedTrainerEncounterBGM */);
        public static bool EnableTrainerClassBattleMusic = false;
        public static int TrainerClassBattleMusicTableOffset = ToDo(/* gClassBasedBattleBGM */);
        public static bool EnableTrainerClassPokeBall = false;
        public static int TrainerClassPokeBallTableOffset = ToDo(/* gClassPokeBalls */);
        public static bool EnableTrainerClassBaseIV = false;
        public static int TrainerClassBaseIVTableOffset = ToDo(/* gBaseIVsByTrainerClass */);

        // Trainer sprites
        public static int TrainerSpriteImageTableOffset = Pointer(0x3473C);
        public static int TrainerSpritePaletteTableOffset = Pointer(0x3474C);
        public static int TrainerSpriteYPosTableOffset = Pointer(0x37E78);
    }
}
