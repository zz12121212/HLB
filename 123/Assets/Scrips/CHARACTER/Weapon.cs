using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public float offset;

    public GameObject projectile;
    public Transform shotPoint;
    public GameObject ThirdAttacks;
    // Start is called before the first frame update
  /*  public float AllTime;
    public float time;


    public float TimePercent;*/

    void Start()
    {
/*        AllTime = time;
        TimePercent = time / AllTime;*/
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //mousePosition����Vector3    ScreenToWorldPoint������Ļ���������λ��   Carema.mainָmaincarema
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //Mathf.Atan2(y, x) �������ڼ���y����x��֮��Ƕȵķ�����ֵ,Mathf.Rad2Deg����ת��Ϊ��
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);//Quaternion.Euler����һ����ʾŷ����ת����Ԫ����Quaternion��
 
    }
    public void OnAttack()
    {
       Instantiate(projectile, shotPoint.position, transform.rotation);
    }
    public void TheThirdAttack()
    {
        Instantiate(ThirdAttacks, transform.position, transform.rotation);
        
    }
}
