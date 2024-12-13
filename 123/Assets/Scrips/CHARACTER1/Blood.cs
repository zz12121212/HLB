using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood : MonoBehaviour
{
    public PlayerAttack playerAttack;
    public Weapon weapon;

    public Image Magic;
    public Image blood;
    public Image Time1;
    public Image Time2;
    public Image Time3;

    private int HeartNum;
    [SerializeField] private Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        HeartNum = playerAttack.Heart;
    }

    // Update is called once per frame
    void Update()
    {
        
        blood.fillAmount = playerAttack.BloodPercent;
        Magic.fillAmount = playerAttack.MagicPercent;
        Time1.fillAmount =playerAttack.TimePercent1;
        Time2.fillAmount = playerAttack.TimePercent2;
        Time3.fillAmount = playerAttack.TimePercent3;

        if(HeartNum != playerAttack.Heart)
        {
            hearts[HeartNum].color = new Color(1,1,1,0);
            HeartNum = playerAttack.Heart;
        }

    }




}
