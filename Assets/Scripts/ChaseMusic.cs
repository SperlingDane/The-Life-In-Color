using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip red, blue, green;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (GlobalControl.Instance.lastColor == "Blue")
        {
            audioSource.clip = blue;
        }
        if (GlobalControl.Instance.lastColor == "Green")
        {
            audioSource.clip = green;
        }
        if (GlobalControl.Instance.lastColor == "Red")
        {
            audioSource.clip = red;
        }
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
