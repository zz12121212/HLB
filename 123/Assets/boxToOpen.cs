using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxToOpen : MonoBehaviour
{
    private bool Find = false;

    [SerializeField] private Player_Move player;
    [SerializeField] private GameObject talk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = (player.transform.position - transform.position).magnitude;

        if(distance <= 3.3f && !Find)
        {
            talk.SetActive(true);
            Find = true;
        }

    }
}
