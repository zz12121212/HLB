using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdAttack : MonoBehaviour
{
    PlayerAttack playerAttack;
    Animator anim;
    Rigidbody2D rb;

    Vector3 difference;
    public float offset;

    private float force;
    public float SingleForce;

    public float WantToExist;
    private float LifeTime;

    public int Aggresive;

    private bool OnAttack = false;
    private bool Attacked = false;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        audioManager.PlayAudio(audioManager.Attack3_1);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        playerAttack = GameObject.FindWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (playerAttack.Attack3)
        {  

        difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //mousePosition����Vector3    ScreenToWorldPoint������Ļ���������λ��   Carema.mainָmaincarema
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //Mathf.Atan2(y, x) �������ڼ���y����x��֮��Ƕȵķ�����ֵ,Mathf.Rad2Deg����ת��Ϊ��
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        //Quaternion.Euler����һ����ʾŷ����ת����Ԫ����Quaternion��
            force = Time.deltaTime *SingleForce;

        }

        else if (playerAttack.Attack3 == false && !OnAttack)
        {
            OnAttack = true;
            audioManager.PlayAudio(audioManager.Attack3_2);
            anim.SetTrigger("Shot");
            rb.velocity = -1*difference * force;
            LifeTime += Time.deltaTime;
        }
     
        if(LifeTime >= WantToExist)
        {
            anim.SetTrigger("end");
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.TryGetComponent(out DamageAble enemy) && !Attacked)
        {
            enemy.OnHit(Aggresive , difference);
            anim.SetTrigger("end");
            Attacked = true;
        }
        else
        {
            anim.SetTrigger("end");
        }
        
    }


}

