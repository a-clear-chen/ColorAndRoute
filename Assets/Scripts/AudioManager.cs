using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            }
            return _instance;
        }
    }

    private AudioSource bgSource;
    private AudioSource normalSource;

    public const string Sound_Prefix = "Sounds/";
    public const string Sound_BGM = "BGM";
    public const string Sound_Fail = "Fail";
    public const string Sound_Help = "Help";
    public const string Sound_HowToPlay = "How To Play";
    public const string Sound_HowToPlayCompleteEdition = "How To Play Complete Edition";
    public const string Sound_OnceAgain = "Once Again";
    public const string Sound_Praise1 = "Praise1";
    public const string Sound_Praise2 = "Praise2";
    public const string Sound_Praise3 = "Praise3";
    public const string Sound_Quit = "Quit";
    public const string Sound_Return = "Return";
    public const string Sound_Selectionleveldifficulty = "Selection level difficulty";
    public const string Sound_Start = "Start";


    void Awake()
    {
        bgSource = gameObject.AddComponent<AudioSource>();
        normalSource = gameObject.AddComponent<AudioSource>();
    }

	// Use this for initialization
	void Start () {

        _instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="soundName"></param>
    public void PlayBGSound(string soundName)
    {
        PlaySound(bgSource, LoadSound(soundName), 0.6f, true);
    }

    public void StopBGSound()
    {
        bgSource.Stop();
    }

    /// <summary>
    /// 播放其它音乐
    /// </summary>
    /// <param name="soundName"></param>
    public void PlayNormalSound(string soundName)
    {
        PlaySound(normalSource, LoadSound(soundName), 1);
    }

    public void StopNormalSound()
    {
        normalSource.Stop();
    }

    private void PlaySound(AudioSource audioSource,AudioClip clip,float volume, bool isLoop=false)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.loop = isLoop;
        audioSource.Play();
    }
    

    private AudioClip LoadSound(string soundName)
    {
        return Resources.Load<AudioClip>(Sound_Prefix + soundName);
    }
}
