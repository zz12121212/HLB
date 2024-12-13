using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goballight : MonoBehaviour
{
    public float time;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime ;
        if (time >= 6)
        {
            anim.SetTrigger("Spark");
            time = 0;
        }

    }
    
}
