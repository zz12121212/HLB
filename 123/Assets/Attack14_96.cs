using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack14_96 : MonoBehaviour
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
        if(collision.TryGetComponent<PlayerAttack>(out PlayerAttack player))
        {
            audioManager.PlayEnemyAudio(audioManager.EnemyAttack1);
            player.OnHit(10, Vector2.zero);
        }
    }
}
