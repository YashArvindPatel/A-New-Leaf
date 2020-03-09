using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickScript : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;

    private void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}
