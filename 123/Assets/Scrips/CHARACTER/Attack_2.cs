using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_2 : MonoBehaviour
{
    public int Aggresive;
    public int Force;

    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        audioManager.PlayAudio(audioManager.Attack2);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            IDamageable enemy = collision.GetComponent<IDamageable>();
            Vector2 KnockBack =Vector2.up *Force;
            enemy.OnHit(Aggresive, KnockBack);
            
        }
    }
}
