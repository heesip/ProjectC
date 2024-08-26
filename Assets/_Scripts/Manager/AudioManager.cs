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
    // [SerializeField] float _sfxVolume;
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
        }
    }

    public void PlayBGM()
    {
        _bgmPlayer.Play();
    }

    public void PauseBGM()
    {
        _bgmPlayer.Pause();
    }

    public void PlaySFX(SFXType sfxType)
    {
        for (int i = 0; i < _sfxPlayers.Length; i++)
        {
            int loopIndex = (i + _channelIndex) % _sfxPlayers.Length;
            if (_sfxPlayers[loopIndex].isPlaying)
            {
                continue;
            }
            _channelIndex = loopIndex;
            _sfxPlayers[loopIndex].clip = _sfxClips[(int)sfxType];
            _sfxPlayers[loopIndex].volume = VolumeSetting(sfxType);
            _sfxPlayers[loopIndex].Play();
            break;
        }
    }

    float VolumeSetting(SFXType sfxType)
    {
        switch (sfxType)
        {
            case SFXType.Dead:
                return 0.2f;
            case SFXType.Win:
                return 0.2f;
            case SFXType.Lose:
                return 0.2f;
            case SFXType.LevelUp:
                return 0.1f;
            case SFXType.Select:
                return 0.2f;
            case SFXType.Hit:
                return 0.1f;
            case SFXType.Melee:
                return 0.2f;
            case SFXType.Range:
                return 0.2f;
            case SFXType.Throwing:
                return 0.7f;
            case SFXType.Thunder:
                return 0.15f;
            case SFXType.Electrode:
                return 0.15f;
            case SFXType.Fjorgin:
                return 0.2f;
            case SFXType.Shield:
                return 0.1f;
            case SFXType.Fire:
                return 0.2f;
            case SFXType.Potion:
                return 0.6f;
            case SFXType.Gem:
                return 0.1f;
            default:
                return 0.2f;
        }
    }

}
