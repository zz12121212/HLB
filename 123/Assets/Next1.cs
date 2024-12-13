using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NEXT1 : MonoBehaviour
{
    [SerializeField] private Text[] texts;
    private int Num;
    [SerializeField] private GameObject CloseTheTalk;
    [SerializeField] private GameObject Book;
    public GameObject NextTalk;
    [SerializeField] private string NextScene;

    private int num = 0;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        Num = texts.Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TheNEXT()
    {
        audioManager.PlayAudio(audioManager.click2);
        if (num < Num-1)
        {
            texts[num].color = new Color(0f, 0f, 0f, 0f);
            num += 1;
            texts[num].color = new Color(texts[num].color.r, texts[num].color.g, texts[num].color.b, 1f);

        } 
        
        else
        {
            Time.timeScale = 1f;
            CloseTheTalk.SetActive(false);
            if(NextScene != null)
                 {
                    Time.timeScale = 1f;
                    SceneManager.LoadScene(NextScene);
                 }
          if(NextTalk != null)
            {
                NextTalk.SetActive(true);
            }

            if(Book != null)
            {
                Book.SetActive(false);
            }

           
        }
    }
}

