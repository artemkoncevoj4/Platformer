using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Sound {
    public class AudioManager : MonoBehaviour
    {
        // Статическая переменная для доступа к AudioManager из любого места (Singleton Pattern)
        public static AudioManager Instance;

        // Ссылки на Audio Source
        [Header("Источники звука")]
        
        [Tooltip("Источник для фоновой музыки")]
        public AudioSource musicSource;

        [Header("Настройки Аудио Mixer")]
        [Tooltip("Ссылка на ваш главный Audio Mixer")]
        public AudioMixer masterMixer; 
        [Tooltip("Имя группы микшера для SFX")]
        public string sfxMixerGroupName = "SFX";
        [Tooltip("Имя группы микшера для музыки")]
        public string musicMixerGroupName = "Music";


        [Header("Основные SFX (по умолчанию)")]
        public AudioClip spawnSound;


        // Клип для фоновой музыки
        [Header("Фоновая музыка")]
        public AudioClip backgroundMusicClip;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                if (musicSource == null)
                {
                    Debug.LogError("<color=red>AudioManager: musicSource не назначен в инспекторе!</color>");
                }

                if (masterMixer != null)
                {
                    if (musicSource != null)
                    {
                        AudioMixerGroup[] musicGroups = masterMixer.FindMatchingGroups(musicMixerGroupName);
                        if (musicGroups.Length > 0)
                        {
                            musicSource.outputAudioMixerGroup = musicGroups[0];
                        }
                        else
                        {
                            Debug.LogWarning($"<color=orange>AudioManager: Mixer group с именем '{musicMixerGroupName}' не найдена.</color>");
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("<color=orange>AudioManager: masterMixer не назначен. Звуки будут воспроизводиться без микшера.</color>");
                }
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }
        void Start()
        {
            PlayBackgroundMusic();
        }
        
        public void PlayBackgroundMusic()
        {
            if (musicSource == null)
            {
                Debug.LogError("<color=red>AudioManager: Music Source не назначен!</color>");
                return;
            }
            if (backgroundMusicClip == null)
            {
                Debug.LogWarning("<color=orange>AudioManager: Клип фоновой музыки не назначен.</color>");
                return;
            }
            musicSource.clip = backgroundMusicClip;
            musicSource.loop = true; 
            musicSource.Play();
        }
    }
}