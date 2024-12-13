using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndMove : MonoBehaviour
{

    public float vertical;
    public float horizontal;      //ˮƽ��ֱ������ֵ
    private float PlayerSpeed;  //ת��Speed
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 Speed;  //��ȡ��ɫʵ���ٶ�
    public float speed;     //������ԣ����Ըı��speed
    private Vector2 givedirection;  //��װ��ȡ��ˮƽ��ֱ�����γ�����

    private bool OnWalk = false;

    public Transform PlayerTransform;
    [SerializeField] private PlayerAttack playerAttack;
    AudioManager audioManager;
    // Start is called before the first frame update

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        PlayerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        MoveAnim();
        Move();

        if (PlayerSpeed > 0.1 && !OnWalk)
        {
            MoveAudio();
        }

    }

    private void MoveAnim()
    {
        Speed = rb.velocity;
        PlayerSpeed = Speed.magnitude;

        anim.SetFloat("Vertical", vertical);
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Speed", PlayerSpeed);

    }

    private void Move()
    {
        givedirection = new Vector2(horizontal, vertical);
        rb.velocity = givedirection * speed;

    }

    IEnumerator WalkAudioWait()
    {
        OnWalk = true;
        audioManager.PlayAudio(audioManager.Walk);
        yield return new WaitForSeconds(0.3f);
        OnWalk = false;
    }

    private void MoveAudio()
    {
        StartCoroutine(WalkAudioWait());
    }

    private void Damage()
    {
        Destroy(gameObject);
    }
}
