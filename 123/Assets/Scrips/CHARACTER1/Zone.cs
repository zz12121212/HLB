using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public float viewRadius;
    public LayerMask PlayerLayerMask;
    public Collider2D detectedObjs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position,viewRadius,PlayerLayerMask);
        //Բ�ģ��뾶����Ӧ�ĸ�layer

        if(collider != null){
         Collider2D   detectedObjs = collider;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position , viewRadius);//��Ȧ
    }



}
