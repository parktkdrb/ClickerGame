using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip MainButtonSound;
    public AudioClip UpgradeButtonSound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void MainSound()
    {
        audioSource.PlayOneShot(MainButtonSound);
    }
    public void UpgradeSound()
    {
        audioSource.PlayOneShot(UpgradeButtonSound);
    }
}
