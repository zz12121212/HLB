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
        //mousePosition返回Vector3    ScreenToWorldPoint返回屏幕在世界里的位置   Carema.main指maincarema
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //Mathf.Atan2(y, x) 函数用于计算y轴与x轴之间角度的反正切值,Mathf.Rad2Deg弧度转换为度
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);//Quaternion.Euler创建一个表示欧拉旋转的四元数（Quaternion）
 
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
