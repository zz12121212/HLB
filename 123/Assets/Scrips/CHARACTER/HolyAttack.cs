using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class HolyAttack : MonoBehaviour
{
 
    public GameObject HolyAttacks;

    // Start is called before the first frame update
    void Start()
    {
      //因为要锁定怪物放技能，所以脚本不如直接挂怪物上，再调用Player的Magic
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void TheHolyAttack()
    {
         Vector2 position= transform.position;
        Instantiate(HolyAttacks, position, Quaternion.identity);//角度不变
        
    }

}
