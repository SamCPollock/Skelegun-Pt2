/* Sourcefile:      scr_SoundEffectsManager.cs
 * Author:          Sam Pollock
 * Student Number:  101279608
 * Last Modified:   Dec 12, 2021
 * Description:     Handles sound effects for the scene
 * Last edit:       Set as static for global access
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SoundEffectsManager : MonoBehaviour
{
    public static scr_SoundEffectsManager SFXManager;   

    public AudioClip[] audioClips;
    //public AudioClip music;

    private static AudioSource audioSource;


    private void Awake()
    {
        SFXManager = this;      // Set up a static scr_SoundEffectsManager for access across the game.
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays a sound effect according to an index passed in. 
    /// </summary>
    /// <param name="clipIndex"></param>
    public static void PlaySoundEffect(AudioClip clipToPlay, float volumeLevel = 1, float pitchLevel = 1)
    {
        audioSource.volume = volumeLevel;
        //Debug.Log(clipToPlay + "---  PLAYING SOUND AT PITCH: " + (pitchLevel));

        audioSource.PlayOneShot(clipToPlay);
    }
}
