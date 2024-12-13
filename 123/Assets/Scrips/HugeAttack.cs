using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeAttack : MonoBehaviour
{
    [SerializeField] private float t;
    Vector3 step = new Vector3(1 , 0, 0); 
    // Start is called before the first frame update
    private void BackOneStep()
    {   
        Vector3 TargetPosition = transform.position + step;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition , t);
    }
}
