using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalEndSpark : MonoBehaviour
{
    private float time = 2f;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 3)
        {
            anim.SetTrigger("Spark");
            time = 0;
        }

    }
}
