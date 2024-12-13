using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private bool[] endImage;//调试方便，暂时放出来
    [SerializeField] private GameObject[] Images;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < 3; i++)
        {
            endImage[i] = AllTimeValue.EndImage[i];
            Images[i].SetActive(endImage[i]);
        }

        if (endImage[0] == true && endImage[1] == true && endImage[2] == true)
        {
            Images[3].SetActive(true);
        }
    }
}
