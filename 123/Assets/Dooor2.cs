using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dooor2 : MonoBehaviour
{
    GameObject enemy;
    [SerializeField] private GameObject Trigger;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null)
        {
            Trigger.SetActive(true);
        }

        else
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
    }



}
