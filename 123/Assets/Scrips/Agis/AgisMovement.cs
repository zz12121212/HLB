using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgisMovement : MonoBehaviour
{
    public Player_Move player;
    private float time;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Move>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PlayerPosition = player.transform.position;
        time += Time.deltaTime;

        if (player.vertical != 0 || player.horizontal != 0)
        {
            Vector2 direction = player.horizontal * Vector2.right + player.vertical * Vector2.up;

            if (time <= 4.5 && time >= 4)
            {
                transform.position = PlayerPosition - direction;
            }

            else if (time > 4.5 && time <= 6)
            {
                rb.velocity = direction * 1.5f;
            }

            else if (time > 6)
            {
                rb.velocity = Vector2.zero;
                time = 0;
                transform.position = new Vector3(82f, -85f, 0f);
            }
        }
        else
        {
            if (time <= 4.5 && time >= 4)
            {
                transform.position = PlayerPosition - Vector2.right * 2;
            }
            else if (time > 4.5 && time <= 6)
            {
                rb.velocity = Vector2.right * 2.5f;
            }

            else if (time > 6)
            {
                rb.velocity = Vector2.zero;
                time = 0;
                transform.position = new Vector3(82f, -85f, 0f);
                GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            }
        }



    }
}
