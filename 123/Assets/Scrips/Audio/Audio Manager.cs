using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource Bgm;
    [SerializeField] AudioSource Sfx;
    [SerializeField] AudioSource Enemy;

    public AudioClip bgm;
    public AudioClip Walk;
    public AudioClip Attack1;
    public AudioClip Attack2;
    public AudioClip Attack3_1;
    public AudioClip Attack3_2;
    public AudioClip Damaged;
    public AudioClip death;
    public AudioClip CatchItem;
    public AudioClip CatchItem2;
    public AudioClip click;
    public AudioClip click2;

    public AudioClip EnemyAttack1;
    public AudioClip EnemyAttack2;
    public AudioClip EnemyAttack3;
    public AudioClip Damage;
    public AudioClip Die;


    public AudioClip Cure;
    public AudioClip Storage;
    // Start is called before the first frame update
    void Start()
    {
        Bgm.clip = bgm;
        Bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioClip clip)
    {
        Sfx.PlayOneShot(clip);
    }

    public void PlayEnemyAudio(AudioClip clip)
    {
        Enemy.PlayOneShot(clip);
    }

}
