using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Singleton
{
    public class AudioManager : Singleton<AudioManager>
    {
        public AudioSource audioSource;

        public Vector2 volume = new Vector2(0.5f, 0.9f);
        public Vector2 pitch = new Vector2(0.8f, 1.2f);

        // play a clip from a designated AudioSource
        public void PlaySoundEffect(AudioClip clip)
        {
            if (audioSource == null)
                return;

            audioSource.volume = Random.Range(volume.x, volume.y);
            audioSource.pitch = Random.Range(pitch.x, pitch.y);

            audioSource.clip = clip;
            audioSource.Stop();
            audioSource.Play();
        }
    }
}