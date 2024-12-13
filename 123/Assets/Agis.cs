using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agis : MonoBehaviour
{
    [SerializeField] private DamageAble BigAgis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { bool hurt = false;

        if(GetComponent<DamageAble>().Blood <= 1 && !hurt)
        {
            BigAgis.Blood -= 1.5f;
            hurt = true;
        }
   
    if( BigAgis == null)
        {
            Destroy(gameObject);
        }
    }
    
}
