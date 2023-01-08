using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioManager : MonoBehaviour
{
    public const string prefAudioMute = "prefAudioMute";

    public static AudioManager Instance;

    [SerializeField] private Image muteButtonImage;
    [SerializeField] private Sprite audioOnSprite;
    [SerializeField] private Sprite audioOffSprite;
    [SerializeField] private Sound[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;

        if (PlayerPrefs.HasKey(prefAudioMute))
            AudioListener.volume = PlayerPrefs.GetFloat(prefAudioMute);

        UpdateMuteButtonImageSprite();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.isLoop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.volume = s.volume;

            if (s.playOnAwake)
                s.source.Play();
        }
    }

    private void UpdateMuteButtonImageSprite()
    {
        if (AudioListener.volume == 0)
            muteButtonImage.sprite = audioOffSprite;
        else
            muteButtonImage.sprite = audioOnSprite;
    }

    public void PlayClipByName(string _clipName)
    {
        Sound soundToPlay = Array.Find(sounds, dummySound => dummySound.clipName == _clipName);
        if (soundToPlay != null)
            soundToPlay.source.Play();
    }

    public void StopClipByName(string _clipName)
    {
        Sound soundToPlay = Array.Find(sounds, dummySound => dummySound.clipName == _clipName);
        if (soundToPlay != null)
            soundToPlay.source.Stop();
    }

    public void ToggleMute()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }

        PlayerPrefs.SetFloat(prefAudioMute, AudioListener.volume);

        UpdateMuteButtonImageSprite();
    }
}
