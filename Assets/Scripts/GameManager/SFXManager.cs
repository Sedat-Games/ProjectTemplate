using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;
    public List<AudioClip> SoundList = new List<AudioClip>();
    public AudioSource SFXSource, BGSource;

    void Awake()
    {
        instance = this;
        if (!PlayerPrefs.HasKey("BgMusic"))
        {
            PlayerPrefs.SetInt("BgMusic", 1);
            PlayerPrefs.SetInt("EffectSound", 1);
        }
    }

    private void Start()
    {
        Invoke("PlayBGMusic", 3f);
    }
    public void PlayBGMusic()
    {
        if (PlayerPrefs.GetInt("BgMusic") == 1)
        {
            BGSource.Play();
            BGSource.volume = 0.1f;
        }
    }

    //Example of Caliing by Name
    public void Pop()
    {

        if (PlayerPrefs.GetInt("EffectSound") == 1)
        {
            SFXSource.PlayOneShot(SoundList[0]);

        }
    }

}
