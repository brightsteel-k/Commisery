using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueToggle : MonoBehaviour
{
    TMP_Text dialogue;

    private void Awake()
    {
        EventManager.GENERATE_ROOM += closeDialogueBox;
        EventManager.START_ROOM += openDialogueBox;
        EventManager.COMMISERATE_LOSE += showCorrectAnswer;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogue = transform.GetChild(1).gameObject.GetComponent(typeof(TMP_Text)) as TMP_Text;

        openDialogueBox();
    }


    void openDialogueBox() {

        generateRandomSymbols();

        LeanTween.scale(gameObject, new Vector3(0.8f, 0.8f, 0.8f), 1.0f)
                 .setEase( LeanTweenType.easeOutQuint );

    }

    void closeDialogueBox() {

        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 2.0f)
                 .setEase( LeanTweenType.easeInBack )
                 .setOnComplete(() => { 

                    dialogue.text = "";

                 });

        LeanTween.moveX(gameObject, -0.0015f, 6.0f)
                 .setEase(LeanTweenType.easeInOutCubic)
                 .setOnComplete(() => {

                    transform.position = new Vector3(1170.1f, 678.78f, 0f);

                 });

    }

    void generateRandomSymbols() {

        string result = "";

        for (int i = 0; i < 6; i++) {

            result += (char) (70 + Random.Range(0, 10));

        }

        dialogue.text = result;

        LeanTween.value(gameObject, 0f, dialogue.text.Length, dialogue.text.Length * 0.05f)
                 .setOnUpdate(e => dialogue.maxVisibleCharacters = (int)e);

    }


    void showCorrectAnswer() {

        string result = "";

        char anger = (char) 66;
        char fear = (char) 67;
        char sadness = (char) 68;
        char anticipation = (char) 69;

        switch (GameManager.FAILED_EMOTION) {

            case Emotion.Sadness:
                result = storeInString(sadness);
                break;

            case Emotion.Anger:
                result = storeInString(anger);
                break;

            case Emotion.Fear:
                result = storeInString(fear);
                break;

            case Emotion.Anticipation:
                result = storeInString(anticipation);
                break;

            case Emotion.Envy:
                result = storeInString(sadness, anger);
                break;

            case Emotion.Pessimism:
                result = storeInString(sadness, anticipation);
                break;

            case Emotion.Anxiety:
                result = storeInString(anticipation, fear);
                break;

            case Emotion.Aggression:
                result = storeInString(anger, anticipation);
                break;

            case Emotion.Despair:
                result = storeInString(sadness, fear);
                break;

            case Emotion.Powerless:
                result = storeInString(anger, fear);
                break;

            default:
                print("error");
                break;

        }

        dialogue.text = result;

    }

    string storeInString(char c) {

        string result = "";

        for (int i = 0; i < 6; i++) {

            result += c;

        }

        return result;

    }

    string storeInString(char c1, char c2) {

        string result = "";

        for (int i = 0; i < 6; i++) {

            if (i % 2 == 0)
                result += c1;
            else   
                result += c2;

        }

        return result;

    }

}
