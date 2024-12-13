using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frame : MonoBehaviour
{
    // Start is called before the first frame update
    private float time =0;
    AudioManager audioManager;
    Animator anim;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= 1)
        {
            audioManager.PlayEnemyAudio(audioManager.EnemyAttack1);
            anim.SetTrigger("Fire");
            time = 0;
        }
         
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerAttack>(out PlayerAttack player))
        {
            player.BloodWillBe -= 10;
        }
    }
}
