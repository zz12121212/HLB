using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightControl : MonoBehaviour
{
    private float time;
    Animator anim;
    private bool lightedOn = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightedOn)
        {
            time += Time.deltaTime;
            if (time > 6)
            {
                anim.SetTrigger("Spark");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        anim.SetTrigger("light") ;
        lightedOn = true;
    }

}
