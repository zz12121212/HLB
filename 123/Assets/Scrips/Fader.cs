using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    Animator anim;
    bool isFading = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public IEnumerator In()//�Ӻڵ���
    {
        isFading = true;
        anim.SetTrigger("in");

        while (isFading)
        {
            yield return null; // Э�����������ֱ����һ֡
        }
    }

    public IEnumerator Out()//�Ӱ׵���
    {
        isFading = true;
        anim.SetTrigger("out");

        while (isFading)
        {
            yield return null;
        }
    }

    void AnimComplete()
    {
        isFading = false;
    }

}
