using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NEXT : MonoBehaviour
{
    [SerializeField] private Text[] texts;
    [SerializeField] private int Num;
    [SerializeField] private string SceneNum;
    [SerializeField] private GameObject closeScene;
    [SerializeField] private GameObject nextScene;
    private int num = 0;
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

    public void TheNEXT()
    {
        
        audioManager.PlayAudio(audioManager.click);
        if (num < Num)
        {
            texts[num].color = new Color(0f, 0f, 0f, 0f);
            texts[num+1].color = new Color(0f, 0f, 0f, 1f);
            num++;
        }
        else
        {
            if (!string.IsNullOrWhiteSpace(SceneNum))
            {
                SceneManager.LoadScene(SceneNum);
            }
            if(nextScene != null)
            {
                closeScene.SetActive(false);
                nextScene.SetActive(true);
            }
        }
    }
}
