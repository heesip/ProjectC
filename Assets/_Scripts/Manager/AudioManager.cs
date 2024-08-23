using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("#BGM")]
    [SerializeField] AudioClip _bgmClip;
    [SerializeField] float _bgmVolume;
    AudioSource _bgmPlayer;

    [Header("#SFX")]
    [SerializeField] AudioClip[] _sfxClips;
    [SerializeField] float _sfxVolume;
    readonly int channels = 30;
    int _channelIndex;
    AudioSource[] _sfxPlayers;

    public void Initialize()
    {
        GameObject bgmObject = new GameObject("BGMPlayer");
        bgmObject.transform.parent = transform;
        _bgmPlayer = bgmObject.AddComponent<AudioSource>();
        _bgmPlayer.playOnAwake = false;
        _bgmPlayer.loop = true;
        _bgmPlayer.volume = _bgmVolume;
        _bgmPlayer.clip = _bgmClip;

        GameObject sfxObject = new GameObject("SFXPlayer");
        sfxObject.transform.parent = transform;
        _sfxPlayers = new AudioSource[channels];

        for (int i = 0; i < _sfxPlayers.Length; i++)
        {
            _sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
            _sfxPlayers[i].playOnAwake = false;
            _sfxPlayers[i].volume = _sfxVolume;
        }
    }

    public void PlaySFX(SFXType sfxtype)
    {
        for (int i = 0; i < _sfxPlayers.Length; i++)
        {
            int loopIndex = (i + _channelIndex) % _sfxPlayers.Length;
            if (_sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }
            _channelIndex = loopIndex;
            _sfxPlayers[loopIndex].clip = _sfxClips[(int)sfxtype];
            _sfxPlayers[loopIndex].Play();
            break;
        }
    }

    public void PlaySFX(SFXType sfxtype, float volume)
    {
        _sfxVolume = volume;
        for (int i = 0; i < _sfxPlayers.Length; i++)
        {
            int loopIndex = (i + _channelIndex) % _sfxPlayers.Length;
            if (_sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }
            _channelIndex = loopIndex;
            _sfxPlayers[loopIndex].clip = _sfxClips[(int)sfxtype];
            _sfxPlayers[loopIndex].Play();
            break;
        }
    }

}
