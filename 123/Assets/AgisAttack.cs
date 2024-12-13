using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgisAttack : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    DamageAble AgisDamageAble;
    [SerializeField]private PlayerAttack player;

    public float speed = 2.0f;

    public float xBoundaryMax = 10.0f;
    public float yBoundaryMax = 10.0f;

    // 等待时间，在改变方向之前等待的时间（秒）
    public float waitTime = 2.0f;
    private float time = 0f;
    private float AttackTime = 0f;

    private bool OnAttack = false;

    [SerializeField] private GameObject WaterBall;
    Vector3 WaterPosition;
    
    [SerializeField] private GameObject Agi;

    AudioManager audioManager;
    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        WaterPosition = new Vector3( 67.5f,  -31f, 0);
        AgisDamageAble = GetComponent<DamageAble>();
    }

    void Update()
    {
        time += Time.deltaTime;
        AttackTime += Time.deltaTime;

        // 随机方向动起来
        if (time >waitTime)
        {
            RandomDirectionAndMove();
           
        }
        //撞墙返回

        if(OnAttack == false)
        {
            Debug.Log("OnAttack");
            RandomAttackMode();
        }



    } 

    private IEnumerator AttackWait()
    {
        
        yield return new WaitForSeconds(15f);
        OnAttack = false;
    }


    private void RandomDirectionAndMove()
    {
        float targetX = Random.Range(-xBoundaryMax, xBoundaryMax);
        float targetY = Random.Range(-yBoundaryMax, yBoundaryMax);

        Vector3 direction = new Vector3(targetX, targetY, transform.position.z).normalized;

        rb.velocity = direction * speed;
        time = 0f;
    }

    private void RandomAttackMode()
    {
        OnAttack = true;
        float a = Random.Range(0, 4);
        if ((int)a == 1)
        {
            TheWaterBall();
        }

        else if((int)a == 2)
        {
            AgisAwake();
        }

        else if((int)a == 3)
        {
            Agis();
        }

        StartCoroutine(AttackWait());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fence"))
        {
            /*transform.position = (Vector2)transform.position -rb.velocity;*/
            rb.velocity = -(rb.velocity + new Vector2(0,20)).normalized*2;
        }
        else if (collision.TryGetComponent<PlayerAttack>(out PlayerAttack player))
        {

            audioManager.PlayEnemyAudio(audioManager.EnemyAttack3);
            player.BloodWillBe -= 90;
            rb.velocity = collision.transform.position - transform.position;
        }
    }



   private void TheWaterBall()
    {
        Instantiate(WaterBall, transform.position , transform.rotation);
    }

    private void AgisAwake()
    {
        anim.SetTrigger("Awake");
        AgisDamageAble.Blood += 15;
        player.BloodWillBe -= 40;
    }

    private void Agis()
    {
        Instantiate(Agi, transform.position, transform.rotation);
    }


}

