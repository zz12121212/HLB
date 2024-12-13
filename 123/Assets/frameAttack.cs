using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameAttack : MonoBehaviour
{
    Animator anim;
   [SerializeField] GameObject AttackEffect;

    private float time = 0f;
    private bool OnAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 2 && !OnAttack)
        {
            RandomAttackMode();
            StartCoroutine(OnAttackWait());
            time = 0;
        }
    }

    private void Dash()
    {
        anim.SetTrigger("Dash");
    }

    public void Attack1()
    {
        anim.SetTrigger("Attack1");
        Instantiate(AttackEffect, transform.position + Vector3.left, transform.rotation);
        Instantiate(AttackEffect, transform.position + Vector3.left, new Quaternion(0,0,transform.rotation.z+180,0));
    }

    public void Fire()
    {
        anim.SetTrigger("Fire");
    }

    public void Attack2()
    {
        anim.SetTrigger("Attack2");
       
    }

    private void RandomAttackMode()
    {
        OnAttack = true;
        float a = Random.Range(1, 5);
        if ((int)a == 1)
        {
            Attack1();
        }

        else if ((int)a == 2)
        {
            Attack2();
        }

        else if ((int)a == 3)
        {
            Dash();
        }
        else if((int)a == 4)
        {
            Fire();
        }
    }

    IEnumerator OnAttackWait()
    {
        yield return new WaitForSeconds(1f);
        OnAttack = false;
    }
    }
