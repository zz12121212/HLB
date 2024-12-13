using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToExit : MonoBehaviour
{
    GameObject enemy;
    [SerializeField]Collider2D TheCollider;
    SpriteRenderer spr;
    [SerializeField] private GameObject Light;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        /*TheCollider = GetComponent<Collider2D>();*/
        spr = GetComponent< SpriteRenderer > ();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(enemy == null)
        {
            TheCollider.isTrigger = true;
            spr.sortingLayerName = "Layer 1";
            Light.SetActive(true);
        }

        else
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
    }

    

}
