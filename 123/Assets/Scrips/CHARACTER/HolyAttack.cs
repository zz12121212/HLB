using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class HolyAttack : MonoBehaviour
{
 
    public GameObject HolyAttacks;

    // Start is called before the first frame update
    void Start()
    {
      //��ΪҪ��������ż��ܣ����Խű�����ֱ�ӹҹ����ϣ��ٵ���Player��Magic
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    public void TheHolyAttack()
    {
         Vector2 position= transform.position;
        Instantiate(HolyAttacks, position, Quaternion.identity);//�ǶȲ���
        
    }

}
