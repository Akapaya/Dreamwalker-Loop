using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource atmosphereSound;

    public void RestartAtmosphereSound()
    {
        atmosphereSound.Play();
    }
}