using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteOrOthers : MonoBehaviour
{
    [SerializeField] GameObject[] texts;
    [SerializeField] GameObject talk;
    CatchItems item;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        item = GameObject.FindGameObjectWithTag("Player").GetComponent<CatchItems>();
    }

    // Update is called once per frame
    void Update()
    {
        item = GameObject.FindGameObjectWithTag("Player").GetComponent<CatchItems>();
    }

   public void ToGo()
    {
        Time.timeScale = 1;
        talk.SetActive(false);
    }

    public void GiveNote()
    {   int num = item.items[9].count;
        item.ChangeTheObjects(2,1,9,1);
        int num1 = item.items[9].count;
 
        if (num != num1)
        {
            texts[0].SetActive(false);
            texts[1].SetActive(false);
            texts[2].SetActive(true); 
        }
    }

    public void GiveBible()
    {
        int num = item.items[3].count;
        item.ChangeTheObjects(0,1,3,1);
        int num1 = item.items[3].count;
        if (num != num1)
        {
            texts[0].SetActive(false);
            texts[1].SetActive(false);
            texts[2].SetActive(true);
        }
    }
}
