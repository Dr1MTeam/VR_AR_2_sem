using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    
    private AudioSource audioSource;

    public BoxCollider boxCollider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }


    void OnTriggerEnter(Collider other)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        Destroy(boxCollider);
    }
}