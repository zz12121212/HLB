using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holy : MonoBehaviour
{
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioManager.PlayEnemyAudio(audioManager.EnemyAttack1);
            collision.GetComponent<PlayerAttack>().OnHit(10 , Vector2.zero);
        }
    }
}
