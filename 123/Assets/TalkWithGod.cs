using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkWithGod : MonoBehaviour
{
    [SerializeField] private GameObject[] TheTalkWithGod;
    private bool HaveBible = false;
    private bool HaveRing = false;
    CatchItems player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<CatchItems>();

        if(player.items[9].count != 0)
        {
            HaveRing = true;
        }
        if (player.items[0].count != 0)
        {
            HaveBible = true;
        }

        for (int i = 0; i < 6; i++)
        {
            AllTimeValue.Item[i] = 0;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.items[9].count != 0)
        {
            HaveRing = true;
        }
        if (player.items[0].count != 0)
        {
            HaveBible = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (HaveBible)
            { 
                TheTalkWithGod[0].SetActive(true);
            }
            else if (HaveRing)
            {
                TheTalkWithGod[1].SetActive(true);
            }
            else
            {
                TheTalkWithGod[2].SetActive(true);
            }
        }
    }
}
