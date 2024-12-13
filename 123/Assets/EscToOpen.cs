using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscToOpen : MonoBehaviour
{
    [SerializeField] private GameObject menuList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuList.SetActive(true);
        }
    }
}
