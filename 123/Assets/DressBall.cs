using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressBall : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    private float time02 = 0;
    private float time = 0;
    [SerializeField] private float Aggressive;

    AudioManager audioManager;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         time02 += Time.deltaTime;

        if(1.45f>=time02 && time02>= 1.4f)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * 3;
        }
        else if(time02 > 1.45f)
        {
            time02 = 0;
        }


        /*time += Time.deltaTime;
        if (time < 0.7f)
        {
            rb.AddForce(Vector2.up *1.5f);
        }
        else if (time < 1.4f)
        {
            rb.AddForce(Vector2.down *3f);
        }
        else
        {
            time = 0f;
        }*/
    }

    
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerAttack>(out PlayerAttack player))
        {
            audioManager.PlayEnemyAudio(audioManager.EnemyAttack2);
            player.BloodWillBe -= Aggressive;
            anim.SetTrigger("Bright");
        }
    }
}
