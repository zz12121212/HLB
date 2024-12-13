using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReLive : MonoBehaviour
{
    public PlayerAttack Player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { float distance = (transform.position - Player.transform.position).magnitude;
        if(distance <=0.2&&Player.position != transform.position)
        {
            Player.position = transform.position;
            anim.SetTrigger("ChangePosition");
        }
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if(TryGetComponent<PlayerAttack>(out PlayerAttack player))
        {
            player.position = transform.position;
            anim.SetTrigger("ChangePosition");
        }
    }*/
}
