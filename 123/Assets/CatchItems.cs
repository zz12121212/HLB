using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] // 使得结构体可以在 Unity 编辑器中作为字段显示
public struct Item
{
    public string name;
    public int count;
    public Text displayText;


    public Item(string name, int initialCount, Text displayText)
    {
        this.name = name;
        this.count = initialCount;
        this.displayText = displayText;
    }
}

public class CatchItems : MonoBehaviour
{
    public bool Change;

    AudioManager audioManager;

    public Item[] items; // 手动赋值
    [SerializeField] private GameObject FindBibleTalk;

    [SerializeField] private bool FindBilble;

    [SerializeField] GameObject HaveNoMoney;

    [SerializeField] GameObject ring;
    private void Start()//刚开始获取上一幕的数据
    { 

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        for (int i = 0; i <10; i++)
        {
            items[i].count =AllTimeValue.Item[i] ;
            if (items[i].count != 0)
            {
                items[i].displayText.text = ": " + items[i].count.ToString(); // 更新显示文本
                items[i].displayText.color = new Color(0, 0, 0, 1);
            }
        }

        if(items[9].count != 0)
        {
            ring.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (!FindBilble)
        {
            if (items[0].count == 1)
            {
                FindBibleTalk.SetActive(true);
                FindBilble = true;
            }
        }
        for (int i = 0; i < 10; i++)
        {
            AllTimeValue.Item[i]
        = GameObject.FindWithTag("Player").GetComponent<CatchItems>().items[i].count ;}

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tagName = collision.tag; // 获取碰撞物体的标签

        // 查找匹配的标签
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].name.Equals(tagName, System.StringComparison.OrdinalIgnoreCase)) // 不区分大小写比较
            {
                audioManager.PlayAudio(audioManager.CatchItem);
                items[i].count++; // 增加匹配物品的数量
                if (items[i].displayText != null)
                {
                    items[i].displayText.text = ": " +items[i].count.ToString(); // 更新显示文本
                    items[i].displayText.color = new Color(0, 0, 0, 1); 
                }
                Destroy(collision.gameObject);
                break; 
            }
        }
  }

    public void ChangeTheObjects( int Money,int Num,  int item , int num)
    {
        if (items[Money].count - Num >= 0)
        {
            items[Money].count -= Num;
            items[item].count += num;

            items[Money].displayText.text =  ": " + items[Money].count.ToString(); // 更新显示文本
            items[item].displayText.text = ": " + items[item].count.ToString(); // 更新显示文本
            items[item].displayText.color = new Color(0, 0, 0, 1);
        }
        else
        {
            HaveNoMoney.SetActive(true);
        }

    } 


}
