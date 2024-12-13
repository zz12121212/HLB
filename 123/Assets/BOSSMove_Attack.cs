using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSMove_Attack : MonoBehaviour
{
    [SerializeField] private float speed;
     private float time;
    [SerializeField] private GameObject FireBall;
    [SerializeField] private GameObject DressBall;
     private Vector3 direction;

    private bool OnFire = false;
    private bool OnWait = false;
    bool change = false;
    Animator anim;
    Rigidbody2D rb;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator fireBallAudioWait()
    {
        OnFire = true;
        audioManager.PlayEnemyAudio(audioManager.EnemyAttack1);
        yield return new WaitForSeconds(0.3f);
        OnFire = false;
    }

    // Update is called once per frame
    void Update()
    {   anim.SetFloat("Speed", rb.velocity.magnitude);
        time += Time.deltaTime;

        if(time>= 0.5f && time < 15f)
        {
            //随便走路，轨迹留下Dressball,可以攻击，Dressball存在2f;
            
            if (change == false)
            {
                RandomDirection();
                change = true;
                rb.velocity = direction * speed;
            }
            float randomValue = Random.value;
            if (randomValue >0.999f)
            { 
                Instantiate(DressBall, transform.position, Quaternion.identity);/*角度不变*/ }
        }
        else if(time >= 15f &&time <= 23.5f)
        {
            //停下
            rb.velocity = Vector2.zero;
            //anim
            anim.SetBool("Attack",true);
            
            
            if(time >=16.5f && time <= 20f && !OnWait)
            //放很多Fireballs
            {  
                RandomDirection();
                if (!OnFire)
                { StartCoroutine(fireBallAudioWait()); }
                Vector2 position = transform.position + direction ;

                float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0f, 0f, rotZ + 180);//Quaternion.Euler创建一个表示欧拉旋转的四元数（Quaternion）

                Instantiate(FireBall, position, rotation);
                StartCoroutine(Wait());
                change = false;
             }
        }
        else if(time > 23.5f)
        {
            time = 0;
        }

    }

    private IEnumerator Wait()
    {
        OnWait = true;
        yield return new WaitForSeconds(0.05f);
        OnWait = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fence"))
        {
            /*transform.position = (Vector2)transform.position -rb.velocity;*/
            
            rb.velocity = -direction * speed;
        }
    }

    private void RandomDirection()
    {
        float targetX = Random.Range(-10, 10);
        float targetY = Random.Range(-10, 10);

        while (targetX == 0 || targetY == 0) {
             targetX = Random.Range(-10, 10);
             targetY = Random.Range(-10, 10);
        }

         direction = new Vector3(targetX, targetY, transform.position.z).normalized;
    }
}
