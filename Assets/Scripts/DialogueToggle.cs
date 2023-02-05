using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueToggle : MonoBehaviour
{

    bool toggled;

    TMP_Text dialogue;

    // Start is called before the first frame update
    void Start()
    {

        toggled = false;

        dialogue = transform.GetChild(1).gameObject.GetComponent(typeof(TMP_Text)) as TMP_Text;

        dialogue.text = "";

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J)) {

            toggled = toggled ? false : true;

            if (toggled)
                LeanTween.scale(this.gameObject, new Vector3(1, 1, 1), 1.0f).setEase( LeanTweenType.easeOutQuint );
            else
                LeanTween.scale(this.gameObject, new Vector3(0, 0, 0), 1.0f).setEase( LeanTweenType.easeOutQuint );

        }

        if (toggled && Input.GetKeyDown(KeyCode.K)) {

            generateRandomSymbols();

        }

    }

    void generateRandomSymbols() {

        string result = "";

        for (int i = 0; i < 6; i++) {

            result += (char) (65 + Random.Range(0, 14));

        }

        dialogue.text = result;

        LeanTween.value(this.gameObject, 0f, dialogue.text.Length, dialogue.text.Length * 0.05f)
                 .setOnUpdate(e => dialogue.maxVisibleCharacters = (int)e);

    }

}
