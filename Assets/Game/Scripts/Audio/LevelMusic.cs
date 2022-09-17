using System.Collections.Generic;
using UnityEngine;

namespace SimpleAudioManager
{
    public class LevelMusic : MonoBehaviour
    {
        public static LevelMusic instance;

        public bool playMusic;
        public List<AudioSource> trackList = new List<AudioSource>();
        public string trackName;

        private void Start()
        {
            instance = this;
            if (GameManager.instance.currentState == GameManager.GameStates.StartMenu)
            {
                playTrack2();
            }

         



        }

        public void playTrack1()
        {
            if (playMusic)
            {
                trackList[1].Stop();
                trackList[0].Stop();
                trackList[0].Play();
            }
        }

        public void playTrack2()
        {
            if (playMusic)
            {
                trackList[1].Stop();
                trackList[1].Play();
            }
        }

        public void StopTrack1()
        {
            trackList[0].Stop();
        }
    }
}