using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField] private PlayerAttack player;
    [SerializeField] private CatchItems Item;

    [SerializeField] private GameObject NoteNextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)//结束获取这一幕数据
    {
        if (collision.CompareTag("Player")) {

            AllTimeValue.Blood_ = player.BloodWillBe ;
            AllTimeValue.Magic_ = player.MagicWillBe ;

           for(int i = 0; i <9; i++)
            {
                AllTimeValue.Item[i] = Item.items[i].count;
            }
            NoteNextScene.SetActive(true);
        }
    }
}
