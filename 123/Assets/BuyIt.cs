using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyIt : MonoBehaviour
{
    [SerializeField] private CatchItems catchItems;
    [SerializeField] private int Money;
    [SerializeField] private int MoneyNum;
    [SerializeField] private int Item;
    [SerializeField] private int ItemNum;


    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Buying()
    {
        audioManager.PlayAudio(audioManager.click);

        catchItems.ChangeTheObjects(Money, MoneyNum, Item, ItemNum);

    }
}
