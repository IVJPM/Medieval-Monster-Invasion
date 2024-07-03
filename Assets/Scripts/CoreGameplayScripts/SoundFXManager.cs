using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void DrawBowSound(AudioSource source, AudioClip drawBow, float volume)
    {
        if (Time.timeScale == 1)
        {
            source.PlayOneShot(drawBow, volume);
        }
    }

    public void ShootBowSound(AudioSource source, AudioClip bowShot, float volume)
    {
        if (Time.timeScale == 1)
        {
            source.PlayOneShot(bowShot, volume);
        }
    }
}
