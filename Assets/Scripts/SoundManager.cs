/*================================================================
Product:    TapEngine
Developer:  Onur Tanrıkulu
Date:       18/01/2018 00:49

Copyright (c) 2018 Onur Tanrikulu. All rights reserved.
================================================================*/

using UnityEngine;

namespace BabylonJam
{
    internal static class SoundManager
    {
        private static AudioSource musicSource;
        private static AudioSource soundSource;

        public static void Create()
        {
            GameObject gameObject = new GameObject("SoundManager");

            musicSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
            //musicSource.clip = null;//TODO: Add music clip
            soundSource = (AudioSource)gameObject.AddComponent(typeof(AudioSource));
            soundSource.playOnAwake = false;
        }

        public static void SetMusicVolume(float volume)
		{
            musicSource.volume = volume;
		}

        public static void SetSoundVolume(float volume)
		{
            soundSource.volume = volume;
		}

        public static void PlayClip(AudioClip clip)
        {
            soundSource.clip = clip;
            soundSource.Play();
        }
    }

}