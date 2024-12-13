using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingImage : MonoBehaviour
{
    private bool Change = false;
    Image image;
    CatchItems item;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        item = GameObject.FindGameObjectWithTag("Player").GetComponent<CatchItems>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Change && item.items[9].count > 0)
        {
            image.color = new Color(1, 1, 1, 1);
            Change = true;
        }
    }
}
