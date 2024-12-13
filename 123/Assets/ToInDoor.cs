using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToInDoor : MonoBehaviour
{
    // Start is called before the first frame update
    CatchItems item;
    int Candy;

    [SerializeField] private GameObject NextDoor;
    [SerializeField] private GameObject globallight;
    [SerializeField] private GameObject CandyImage;
    [SerializeField] private GameObject E;

    bool end = false;
    bool start = false;


    void Start()
    {
        item = GameObject.FindGameObjectWithTag("Player").GetComponent<CatchItems>();
        Candy = item.items[4].count;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            start = true;
            
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            start = false;
            
        }
        if(globallight.activeInHierarchy == true)
        {
            end = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        CandyImage.SetActive(true);
                        if (start && !end)
                        {
                        
                        NextDoor.SetActive(true);
                        }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
                CandyImage.SetActive(false);
        }
    }

}
