using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDoor : MonoBehaviour
{
    [SerializeField] private GameObject TheNextTalk;
    [SerializeField] private CatchItems item;
    [SerializeField] private NEXT1 next1;
    // Start is called before the first frame update
    void Start()
    {
        if(item.items[4].count > 0)
        {
            next1.NextTalk = TheNextTalk;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (item.items[4].count > 0)
        {
            next1.NextTalk = TheNextTalk;
        }
    }
}
