using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour, IDamageable
{
    public Animator anim;
    public Rigidbody2D rb;
    public Weapon weapon;

    public int Heart;
    public Vector3 position;

    public float AllBlood;
    private float Blood;
    public float BloodWillBe;

    public bool OnDie = false;
    public bool OnTheHit = false;

    public float Force;

    public float AllMagic;
    private float Magic;
    public float MagicWillBe;

    private float AllTime1;
    public float time1;

    public float AllTime2;
    public float time2;
    public bool Attack2;

    public bool Attack3;
    public float AllTime3;
    public float time3;

    public float BloodPercent;
    public float MagicPercent;
    public float TimePercent1;
    public float TimePercent2;
    public float TimePercent3;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        Heart = 2;

        position = transform.position;

        Blood = AllTimeValue.Blood_;
        BloodWillBe = Blood;

        Magic = AllTimeValue.Magic_;
        MagicWillBe = Magic;

        AllTime1 = time1;
        TimePercent1 = time1 / AllTime1;

        AllTime2 = time2;
        TimePercent2 = time2 / AllTime2;

        AllTime3 = time3;
        TimePercent3 = time3 / AllTime3;

        MagicPercent = Magic / AllMagic;
        BloodPercent = Blood / AllBlood;


        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator DieWait() 
    {
        OnDie = true;
        Die(); 
        audioManager.PlayAudio(audioManager.death);
        yield return new WaitForSeconds( 1f);
        transform.position = position;
        BloodWillBe = AllBlood;
        MagicWillBe = AllMagic;
        OnDie = false;
    }



    void Update()
    {
        

        if (BloodWillBe <=0)
        {
           
            if (!OnDie)
              {
                StartCoroutine(DieWait());
              }
        }

        if(BloodWillBe >= AllBlood)
        {


            BloodWillBe = AllBlood;
        }

        if(time1 > AllTime1)
        {
            time1 = AllTime1;
        }
        if (time2 > AllTime2)
        {
            time2 = AllTime2;
        }
        if (time3 > AllTime3)
        {
            time3 = AllTime3;
        }

        //ÂýÂý»ØÂú
        if (time1 < AllTime1)
        {
            time1 += 5f * Time.deltaTime;
            TimePercent1 = time1 / AllTime1;
        }
        if (time2 < AllTime2)
        {
            time2 += 2f * Time.deltaTime;
            TimePercent2 = time2 / AllTime2;
        }
        if (time3 < AllTime3)
        {
            time3 += 1f * Time.deltaTime;
            TimePercent3 = time3 / AllTime3;
        }



        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("Attack1",true);
            if (time1 >= AllTime1 && MagicWillBe >0) 
            {
                weapon.OnAttack();
                MagicWillBe -= 10;
                time1 = 0;
                TimePercent1 = time1 / AllTime1;
            }

        }
        
        if (Input.GetKeyDown("2"))
        {
            
            anim.SetBool("Attack2", true);
            if (time2 >= AllTime2 && BloodWillBe > 0)
            {   Attack2 = true;
                if (MagicWillBe >= AllMagic)
                {
                    MagicWillBe = AllMagic;
                }
                else
                {
                    MagicWillBe += 10;
                }
                BloodWillBe -= 10;
                time2 = 0;
                TimePercent2 = time2 / AllTime2;
            }
        }
       TimePercent3 = time3 / AllTime3;
        if (Input.GetKeyDown("3"))
        {
            Attack3 = true;
            anim.SetBool("Attack2", true);
            if (time3 >= AllTime3 && MagicWillBe > 0)
            {
                weapon.TheThirdAttack();
                MagicWillBe -= 20;
                time3 = 0;
                
            }
        }
        else if (Input.GetKeyUp("3"))
        {
            Attack3 = false;
        }

        if(BloodWillBe > AllBlood)
        {
            BloodWillBe = AllBlood;
        }

        //»ºÂý¼õÉÙ
        if (Magic > MagicWillBe)
        {
            Magic -= 10f * Time.deltaTime;
            MagicPercent = Magic / AllMagic;
        }
        else
        {
            Magic = MagicWillBe;
            MagicPercent = Magic / AllMagic;
        }


        if (Blood > BloodWillBe)
        {
            if (!OnTheHit )
            {
                audioManager.PlayAudio(audioManager.Damaged);
                OnTheHit = true;
            }
            Blood -= 20f * Time.deltaTime;
            BloodPercent = Blood / AllBlood;
        }
        else
        {
            OnTheHit = false;
            Blood = BloodWillBe;
            BloodPercent = Blood / AllBlood;
        }

    }

 public void OnHit(int aggresive, Vector2 konckback)
    {
        audioManager.PlayAudio(audioManager.Damaged);
        rb.AddForce(konckback);
        anim.SetBool("Damaged", true);
        BloodWillBe -= aggresive;
 
    }


    private void Die()
    {
        OnDie = true;
        audioManager.PlayAudio(audioManager.death);

        if (Heart > 0)
        {
            Heart -= 1;
            anim.SetBool("Die", true);

        }
        else if(Heart <= 0)
        {
            SceneManager.LoadScene("Die");
        }
     
    }

    public void OnAttack()
    {
       
    }





}
