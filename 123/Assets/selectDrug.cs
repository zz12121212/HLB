using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectDrug : MonoBehaviour
{
    AudioManager audioManager;
    PlayerAttack player;
    [SerializeField] private CatchItems catchItems;

    

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
   public void UsingRed ()
{
        audioManager.PlayAudio(audioManager.click);
        if (catchItems.items[6].count >0)
        {
            catchItems.items[6].count -= 1;
            player.BloodWillBe += 90;
            catchItems.items[6].displayText.text = ": " + catchItems.items[6].count.ToString();
        }
    }

    public void UsingBlue()
    {
        audioManager.PlayAudio(audioManager.click);
        if (catchItems.items[7].count > 0)
        {
            catchItems.items[7].count -= 1;
            player.MagicWillBe += 90;
            catchItems.items[7].displayText.text = ": " + catchItems.items[7].count.ToString();
        }
    }

    public void Usingyellow()
    {
        audioManager.PlayAudio(audioManager.click);
        if (catchItems.items[8].count > 0)
        {
            catchItems.items[8].count -= 1;
            player.time1 = player.time2 = player.time3 = 10f;
            catchItems.items[8].displayText.text = ": " + catchItems.items[8].count.ToString();
        }
    }

}
