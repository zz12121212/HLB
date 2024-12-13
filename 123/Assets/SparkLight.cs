using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkLight : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    private float time =0 ;
    void Start()
    {
        anim = GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 3.5f)
        {
            anim.SetTrigger("Spark");
            time = 0;
        }
    }


}
