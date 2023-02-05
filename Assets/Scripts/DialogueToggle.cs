using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueToggle : MonoBehaviour
{

    Animator animator;

    TMP_Text dialogue;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        dialogue = transform.GetChild(0).gameObject.GetComponent(typeof(TMP_Text)) as TMP_Text;

        dialogue.text = "";

        Debug.Log(animator.GetBool("keyPressed"));

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J)) {

            Debug.Log(animator.GetBool("keyPressed"));
            animator.SetBool( "keyPressed", animator.GetBool("keyPressed") ? false : true );

        }

        if (animator.GetBool("keyPressed") && Input.GetKeyDown(KeyCode.K)) {

            generateRandomSymbols();

        }

    }

    void generateRandomSymbols() {

        string result = "";

        for (int i = 0; i < 6; i++) {

            result += (char) (65 + Random.Range(0, 14));

        }

        dialogue.text = result;

    }

}
