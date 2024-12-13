using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOrNot : MonoBehaviour
{
    // Start is called before the first frame update
    CatchItems catchItems;
    [SerializeField] GameObject ring;

    void Start()
    {
        catchItems = GameObject.FindGameObjectWithTag("Player").GetComponent<CatchItems>();
        if(catchItems.items[9].count != 0)
        {
            ring.SetActive (true);
        }
        else
        {
            ring.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
