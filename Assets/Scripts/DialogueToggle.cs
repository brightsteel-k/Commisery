using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueToggle : MonoBehaviour
{

    TMP_Text dialogue;

    float displacement;

    // Start is called before the first frame update
    void Start()
    {

        dialogue = transform.GetChild(1).gameObject.GetComponent(typeof(TMP_Text)) as TMP_Text;

        openDialogueBox();

        EventManager.GENERATE_ROOM += closeDialogueBox;

    }


    void Update() {

        if (EventManager.TRANSITION_COMPLETED) {
            GameManager.TRANSITION_COND_2 = true;
            openDialogueBox();
        }

    }


    void openDialogueBox() {

        generateRandomSymbols();

        LeanTween.scale(this.gameObject, new Vector3(0.9f, 0.9f, 0.9f), 1.0f)
                 .setEase( LeanTweenType.easeOutQuint );

    }

    void closeDialogueBox() {

        LeanTween.scale(this.gameObject, new Vector3(0, 0, 0), 1.0f)
                 .setEase( LeanTweenType.easeInBack )
                 .setOnComplete(() => { 

                    dialogue.text = "";

                 });

        LeanTween.moveX(this.gameObject, -0.0015f, 4.0f)
                 .setEase(LeanTweenType.easeInOutCubic)
                 .setOnComplete(() => {

                    transform.position = new Vector3(1170.1f, 678.78f, 0f);

                 });

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
