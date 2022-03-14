using System.Collections;
using System.Collections.Generic;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static VibrationManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }



    public void VibrateChoice()
    {
        if (PlayerPrefs.GetInt("GameVibration") == 0)
        {
            MMVibrationManager.Haptic(HapticTypes.RigidImpact);
        }
    }

}
