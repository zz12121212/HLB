using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{

    GameObject fader;
    // Start is called before the first frame update
    void Start()
    {
        fader = GameObject.FindWithTag("Fader");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fader.GetComponent<Animator>().SetBool("Out" , true);
        }
    }
}
