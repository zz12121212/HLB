using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_Blood : MonoBehaviour
{
    public Image MonsterBlood;
    public DamageAble damageAble2;
    private float bloodPrecent;
    private float BloodBeforePercent;


    // Start is called before the first frame update
    void Start()
    {
        
        bloodPrecent = damageAble2.BloodPercent;
        BloodBeforePercent = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        bloodPrecent = damageAble2.BloodPercent;
        if (bloodPrecent != BloodBeforePercent)
        {
            MonsterBlood.fillAmount = bloodPrecent;
            BloodBeforePercent = bloodPrecent;
        }
    }
}
