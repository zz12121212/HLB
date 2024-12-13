using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOrNot : MonoBehaviour
{
    CatchItems item;
    [SerializeField] private GameObject talk;
    [SerializeField] private  GameObject globallight;
    [SerializeField] private GameObject GlobalLight;


    // Start is called before the first frame update
    void Start()
    {
        item = GameObject.FindGameObjectWithTag("Player").GetComponent<CatchItems>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToPut()
    {
        item.ChangeTheObjects(4 ,1 ,0 ,0);
        globallight.SetActive(true);
        GlobalLight.GetComponent<Animator>().SetBool("LightUp", true);
        talk.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToGo()
    {
        talk.SetActive(false);
        Time.timeScale = 1;
    }
}
