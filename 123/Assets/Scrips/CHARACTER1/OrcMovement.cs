using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spr;
    Zone zone;
    Animator anim;
    Transform Enemytransform;

    public float speed;//׷���ٶ�


    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        zone = GetComponent<Zone>();
        anim = GetComponent<Animator>();
        Enemytransform = GetComponent<Transform>();
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {//��ȡ����
        Vector2 direction = (zone.detectedObjs.transform.position - transform.position);
        //����
        if(direction.magnitude <= zone.viewRadius)
        { 
            rb.AddForce(direction.normalized * speed);
            //��ת
            if (direction.x > 0)
            {
                spr.flipX = false;
            }
            if (direction.x <0)
            {
                spr.flipX = true;
            }
            Move();
        }
        else
        {
            StopMove();
        }


    }

    
    
    public void Move()
    {anim.SetBool("Move",true); }
    public  void StopMove()
    { anim.SetBool("Move",false);}


}
