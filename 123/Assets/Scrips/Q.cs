using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool DownQ = false;

    float time;
    [SerializeField]Text text;
    [SerializeField] GameObject TheTime;
  

    AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        text = TheTime.GetComponent<Text>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; 
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DownQ = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            DownQ = false;
        }

        if(time <= 0)
        {
            time = 0;
            text.color = new Color(0, 0, 0, 0);
        }

        else if(time > 0)
        {
            
            time -= Time.deltaTime;
            text.text = time.ToString("F2");
        }
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        text.color = new Color(1, 1, 1, 1);
        if (time <=0) {
            if (other.TryGetComponent<PlayerAttack>(out PlayerAttack player))
            {
                spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // 设置为不透明  

                if (DownQ)
                {
                    audioManager.PlayAudio(audioManager.Cure);
                    player.BloodWillBe += 30;
                    time = 9f;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && spriteRenderer != null)
        {
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // 设置为透明  
            text.color = new Color(1,1,1,0);
        }
    }
}