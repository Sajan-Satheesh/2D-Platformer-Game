using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    Click,
    PlayerRun,
    PlayerDeath,
    EnemeyAttack,
    EnemeyWalk,
    Bgm,
    Win,
    Lose,
    LevelStart
}
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    
    public AudioSource soundEffect;
    public AudioSource Bgm;
    public AudioSource GameSoundEffects;
    public AudioSource GameSFX2;
    public AudioSource PLayerSounds;
    public AudioSource EnemySounds;
    public SoundType[] Sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        PlayBgm(global::Sounds.Bgm);
    }
    public void PlayBgm(Sounds sound)
    {
        AudioClip audioClip = getAudioClip(sound);
        if (audioClip != null)
        {
            Bgm.clip = audioClip;
            Bgm.Play();
        }
        else
        {
            Debug.Log("Audio not forund for " + sound);
        }
    }
    public void PlaySfx(Sounds sound)
    {
        AudioClip audioClip = getAudioClip(sound);
        if (audioClip != null )
        {
            soundEffect.PlayOneShot(audioClip);
        }
        else
        {
            Debug.Log("Audio not forund for " + sound);
        } 
    }
    public void PlayEnemy(Sounds sound )
    {
        AudioClip audioClip = getAudioClip(sound);
        if (audioClip != null && !EnemySounds.isPlaying)
        {
            EnemySounds.PlayOneShot(audioClip);
        }
    }
    public void PlayPlayer(Sounds sound)
    {
        AudioClip audioClip = getAudioClip(sound);
        if (audioClip != null && !PLayerSounds.isPlaying)
        {
            PLayerSounds.PlayOneShot(audioClip);
        }
    }
    public void PlayGameSfx(Sounds sound)
    {
        AudioClip audioClip = getAudioClip(sound);
        if (audioClip != null && !GameSoundEffects.isPlaying)
        {
            GameSoundEffects.PlayOneShot(audioClip);
        }
        else
        {
            Debug.Log("Audio not forund for " + sound);
        }
    }
    public void PlayGameSFX2(Sounds sound)
    {
        AudioClip audioClip = getAudioClip(sound);
        if (audioClip != null )
        {
            GameSFX2.PlayOneShot(audioClip);
        }
        else
        {
            Debug.Log("Audio not forund for " + sound);
        }
    }
    private AudioClip getAudioClip(Sounds sound)
    {
        SoundType soundType = Array.Find(Sounds, item => item.soundName == sound);
        if (soundType != null )
        {
            return soundType.audioClip;
        }
        return null;    
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundName;
    public  AudioClip audioClip;
}
