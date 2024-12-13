using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToBeFence : MonoBehaviour
{
    public TriggerToControlTheFence theTrigger;

    public float Position_x;
    public float Position_y;

    private float x_difference;
    private float y_difference;

    public float AllTime  = 2f;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        x_difference =  Position_x - transform.position.x;
        y_difference = Position_y - transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (theTrigger.start)
        {
            if(transform.position.x != Position_x)
            {
                transform.position = new Vector3(transform.position.x+Time.deltaTime * Speed ,transform.position.y ,transform.position.z);
            }
            else if(transform.position.y != Position_y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * Speed, transform.position.z);
            }
        }
    }

    
}
