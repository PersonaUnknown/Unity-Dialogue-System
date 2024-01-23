using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    // Simple audio player for dialogue system
    // Plays audio each time dialogue changes
    public class LinearDialogueAudioController : MonoBehaviour
    {
        // Outlets
        public AudioSource audioSource;

        // Methods
        public void UpdateAudio(LinearDialogueSource speaker)
        {
            if (speaker == null) { return; }
            PlayAudio(speaker.GetCurrAudioLine());
        }
        
        public void PlayAudio()
        {
            if (audioSource.clip == null) { return; }
            audioSource.PlayOneShot(audioSource.clip);
        }
        
        public void PlayAudio(AudioClip clip)
        {
            if (clip == null) { return; }

            audioSource.clip = clip;
            audioSource.Play();
        }

        public void PauseAudio()
        {
            audioSource.Pause();
        }

        public void OnReset()
        {
            audioSource.clip = null;
        }
    }
}
