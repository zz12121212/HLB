using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class blockEffect : MonoBehaviour
{ 
       private Tilemap Spr ;
    private Collider2D collider;
    public Collider2D PlayerCollider;

    // Start is called before the first frame update
    void Awake()
    {
        Spr = GetComponent<Tilemap>();
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision == PlayerCollider)
        {
            Spr.color = new(Spr.color.r, Spr.color.g, Spr.color.b, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == PlayerCollider)
        {
            Spr.color = new(Spr.color.r, Spr.color.g, Spr.color.b, 1f);
        }
    }
}
