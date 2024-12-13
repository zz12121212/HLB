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

    public IEnumerator In()//从黑到白
    {
        isFading = true;
        anim.SetTrigger("in");

        while (isFading)
        {
            yield return null; // 协程在这里挂起，直到下一帧
        }
    }

    public IEnumerator Out()//从白到黑
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
