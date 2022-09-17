using System.Collections.Generic;
using UnityEngine;

namespace SimpleAudioManager
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        public List<AudioSource> gameSounds = new List<AudioSource>();

        public List<AudioSource> UISounds = new List<AudioSource>();

        private void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        //Player And Enemy Sounds
        public void PlayerHit()
        {
            gameSounds[0].Stop();
            gameSounds[0].Play();
        }

        public void HealthUp()
        {
            gameSounds[1].Stop();
            gameSounds[1].Play();
        }

        public void ShieldHit()
        {
            gameSounds[2].Stop();
            gameSounds[2].Play();
        }

        public void HazardDrop()
        {
            gameSounds[3].Stop();
            gameSounds[3].Play();
        }

        public void HazardGround()
        {
            gameSounds[4].Stop();
            gameSounds[4].Play();
        }

        public void InnocentSaved()
        {
            gameSounds[5].Stop();
            gameSounds[5].Play();
        }

        public void InnocentLost()
        {
            gameSounds[6].Stop();
            gameSounds[6].Play();
        }

        //User Interface Sounds

        public void GameOver()
        {
            UISounds[0].Stop();
            UISounds[0].Play();
        }

        public void SelectSound()
        {
            UISounds[1].Stop();
            UISounds[1].Play();
        }

        public void StartSound()
        {
            UISounds[2].Stop();
            UISounds[2].Play();
        }

        public void MenuErrorSound()
        {
            UISounds[3].Stop();
            UISounds[3].Play();
        }
    }
}