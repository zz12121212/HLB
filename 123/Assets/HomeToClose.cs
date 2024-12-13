using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeToClose : MonoBehaviour
{
    [SerializeField] private GameObject menuList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToClose()
    {
        menuList.SetActive(false);
    }
}
