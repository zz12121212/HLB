using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickOpen : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TheOpen()
    {
        menu.SetActive(true);
    }
}
