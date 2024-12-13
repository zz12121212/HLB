using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ring : MonoBehaviour
{
    [SerializeField] private Image fillUp;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        fillUp.fillAmount = time / 5;
        if( time>= 5)
        {
            time = 0;
            GameObject.FindWithTag("Player").GetComponent<PlayerAttack>().BloodWillBe += 50;
            GameObject.FindWithTag("Enemy").GetComponent<DamageAble>().Blood -= 10;
        }

    }
}
