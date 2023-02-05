using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image black;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fading());
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Load scene with fading
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(()=>black.color.a==1);
    }
}
