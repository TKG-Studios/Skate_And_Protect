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
                StopTrack();
                trackList[0].Stop();
                trackList[0].Play();
            }
        }

        public void playTrack2()
        {
            if (playMusic)
            {
                StopTrack();
                trackList[1].Stop();
                trackList[1].Play();
            }
        }

        public void playTrack3()
        {
            if (playMusic)
            {
                StopTrack();
                trackList[2].Stop();
                trackList[2].Play();
            }
        }

        public void StopTrack()
        {
            foreach (AudioSource track in trackList)
            {
                if (track.isPlaying)
                {
                    track.Stop();
                }
            }
        }
    }
}