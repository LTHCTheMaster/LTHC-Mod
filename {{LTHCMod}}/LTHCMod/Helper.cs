namespace LTHCMod {
    static class Helper {
        public static bool lthcPlayer(byte playerId) {
            return GlobalVariables.lthcPlayer != null ? playerId == GlobalVariables.lthcPlayer.PlayerId : false;
        }
    }
}
