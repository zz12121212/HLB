using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAble : MonoBehaviour, IDamageable
{
    Rigidbody2D rb;
    Collider2D CharacterCollider;
    public PlayerAttack player;
    Animator anim;
    public HolyAttack holyAttack;

    public int Aggresive;
    public float Force;

    private float BloodBefore,AllBlood;
    public float Blood;
    public float BloodPercent;

    private float distanceToPlayer;
    private Vector2 direction;

    private bool canAttack = true;
    private bool OnDie = false;

    AudioManager audioManager;
    public void OnHit(int aggresive, Vector2 konckback)
    {
        audioManager.PlayEnemyAudio(audioManager.Damage);
 
        rb.AddForce(konckback);
        anim.SetBool("Damaged", true);
        Blood -= aggresive;
    }
    public void OnAttack()
    {
        anim.SetBool("Attack", true);
    }

    // Start is called before the first frame update
    private void Awake()
    {   audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody2D>();
        CharacterCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        BloodBefore = Blood;
        AllBlood = Blood;
        BloodPercent = Blood / BloodBefore;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    IEnumerator AttackDuration()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }






    private void Update()
    {
        if (Blood <=0)
        {
            if (!OnDie)
            {
                audioManager.PlayEnemyAudio(audioManager.Die);
                OnDie = true;
            }
            anim.SetBool("Die",true);
        }
        
        
        if(Blood != BloodBefore)
        {
            anim.SetBool("Damaged", true);
            BloodPercent = Blood / AllBlood;
            BloodBefore =Blood ;
        }
        
        direction = ((transform.position - player.transform.position).normalized);
        distanceToPlayer = (transform.position - player.transform.position).magnitude;
        if (0.2f < distanceToPlayer && distanceToPlayer <= 5f)
        {
            if (player.Attack2 == true)
            {

                    holyAttack.TheHolyAttack();
                    player.Attack2 = false;
            }
        }

        else if (distanceToPlayer <= 0.2f && canAttack)
        {
            Attack();
        }


 }
       private void Attack()
        {
            anim.SetBool("Attack", true);
        /*       player.rb.velocity = direction * Force;
               player.anim.SetBool("Damaged", true);
               player.BloodWillBe -= Aggresive;*/
        player.OnHit(Aggresive , direction * Force);

            StartCoroutine(AttackDuration());
        }

   
    }



