using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Books : MonoBehaviour
{
    AudioManager audioManager;

    public Image image;
    public Text text;
    [SerializeField] private string SceneNum;
    [SerializeField] private GameObject Setting;
    [SerializeField] private GameObject talk;

    private bool Open;
    private int OPENed;

    SpriteRenderer spr;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spr.sortingLayerName = "Layer 1";
        if (Input.GetKeyDown(KeyCode.E))
        {
            Open = true;
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            Open = false;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {  
           if (collision.CompareTag("Player")&& Open)
            {
            audioManager.PlayAudio(audioManager.CatchItem2);
            anim.SetBool("Open", true);
            for (int i = 0; i < 10; i++)
            {  AllTimeValue.Item[i]= GameObject.FindGameObjectWithTag("Player").GetComponent<CatchItems>().items[i].count; }

            if (image != null || text != null)
            {
                image.color = new Color(1f, 1f, 1f, 1f);
                text.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            }

            if(talk != null)
            {
                talk.SetActive(true);
            }
           
           if(SceneNum != null )
        {
            OPENed = 1;
            SceneManager.LoadScene(SceneNum);
        }

            if (Setting != null)
            {
                Setting.SetActive(true);
            }
    }
 }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (image != null || text != null)
        {
            if (collision.CompareTag("Player"))
            {
                audioManager.PlayAudio(audioManager.CatchItem2);
                image.color = new Color(1, 1, 1, 0f);
                text.color = new Color(0.2f, 0.2f, 0.2f, 0f);
            }
        }
    }

}
