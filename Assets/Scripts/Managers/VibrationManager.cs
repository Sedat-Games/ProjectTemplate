using MoreMountains.NiceVibrations;
using UnityEngine;

public static class VibrationManager 
{
    public static void VibrateChoice(HapticTypes hapticTypes)
    {
        if (PlayerPrefs.GetInt("GameVibration") == 0)
        {
            MMVibrationManager.Haptic(hapticTypes);
        }
    }

}
