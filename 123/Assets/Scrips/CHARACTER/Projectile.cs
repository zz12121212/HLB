using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float MoveForce;
    private float distance;
 
    private Vector2 direction;
    public float time;
    private float timeNow = 0f;

    public int Aggresive;
    public float Force;
    Player_Move player_Move;


    Rigidbody2D rb;
    Animator anim;

    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        audioManager.PlayAudio(audioManager.Attack1);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player_Move = GameObject.Find("Square").GetComponent<Player_Move>();
    }

    // Update is called once per frame
    void Update()
    {
 

        timeNow += Time.deltaTime;
        if (timeNow <= time  ) {
             Vector2 direction = ( transform.position- player_Move.PlayerTransform.position).normalized;
            distance = (transform.position - player_Move.PlayerTransform.position).magnitude;
            anim.SetFloat("distance", distance);
            rb.velocity = direction * MoveForce; 
        }
        else
        {
            Object.Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DamageAble enemy =collision.GetComponent<DamageAble>();
          
            Vector2 KnockBack =direction*Force;
            enemy.OnHit(Aggresive, KnockBack);
            anim.SetBool("Attack", true);
        }
    }
}
