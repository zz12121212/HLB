using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLaugh : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    private float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = GetComponent<AudioSource>().clip;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 5)
        {
            audioSource.pitch = Random.Range(0, 1);
            audioSource.PlayOneShot(audioClip);
            time = 0;
        }
    }


}
