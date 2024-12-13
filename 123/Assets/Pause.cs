using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private bool pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ToPause()
    {
            Time.timeScale = 0;
    }

    public void ToContinue()
    {
            Time.timeScale = 1;
    }



}
