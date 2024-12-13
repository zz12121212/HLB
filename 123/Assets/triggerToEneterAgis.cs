using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerToEneterAgis : MonoBehaviour
{
    [SerializeField] private DamageAble BigAgis;
    [SerializeField] private GameObject[] objects;
    int num;
    // Start is called before the first frame update
    
    void Start()
    {
        num = objects.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (BigAgis.Blood <= 0)
        {
            End();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < num; i += 1)
            {
                objects[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                objects[i].GetComponent<Collider2D>().isTrigger = false;
            }
        }
    }

    private void End() 
    {
        for (int i = 0; i < num; i ++)
        {
            objects[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            objects[i].GetComponent<Collider2D>().isTrigger = true;
        }
    }


}
