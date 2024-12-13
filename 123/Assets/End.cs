using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    [SerializeField] private GameObject talk;
    [SerializeField] private GameObject Book;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TheEnd()
    {
        Time.timeScale = 1f;
        talk.SetActive(false);
        Book.SetActive(false);
    }


}
