using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PF_Props_Statue : MonoBehaviour
{
    private bool storage = false;
    [SerializeField] private GameObject TheLight;

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!storage) {
            if (collision.TryGetComponent<PlayerAttack>(out PlayerAttack player))
            {
                audioManager.PlayEnemyAudio(audioManager.Storage);
                TheLight.SetActive (true);
                player.position = transform.position + Vector3.down;
                storage = true;
            }
        }
    }
}
