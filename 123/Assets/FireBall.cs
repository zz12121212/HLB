using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float Aggressive;

    private Vector2 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        

        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed * direction;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Fence"))
        {
            anim.SetTrigger("Boom");
            if(collision.TryGetComponent<PlayerAttack>(out PlayerAttack player))
            {
                player.BloodWillBe -= Aggressive;
            }
        }
        if (collision.CompareTag("Enemy") )
        {
         direction =   collision.transform.position - transform.position;
        }

    }

}
