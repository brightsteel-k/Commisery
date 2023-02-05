using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThoughtBoard : MonoBehaviour
{
    [SerializeField] WordBank wordBank;
    [SerializeField] ChordManager cm;
    [SerializeField] Button sb;
    [SerializeField] GameObject sanityOverlay;
    Emotion chosen;

    void Start() {

        EventManager.GENERATE_ROOM += disableBoard;

    }

    void Update()
    {

        if (!EventManager.COMMISERATING)
        {
            chosen = readInitialChordInput();

            if (chosen != Emotion.None)
                wordBank.setWord(chosen);
        }

        if (EventManager.TRANSITION_COMPLETED == true) {

            GameManager.TRANSITION_COND_1 = true;
            wordBank.gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
            wordBank.enabled = true;
            sb.enabled = true;
            cm.enabled = true;
            sanityOverlay.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);

        }

    }

    Emotion readInitialChordInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.S))
                return Emotion.Envy;
            else if (Input.GetKey(KeyCode.D))
                return Emotion.Aggression;
            else if (Input.GetKey(KeyCode.F))
                return Emotion.Powerless;
            else
                return Emotion.Anger;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
                return Emotion.Envy;
            else if (Input.GetKey(KeyCode.D))
                return Emotion.Pessimism;
            else if (Input.GetKey(KeyCode.F))
                return Emotion.Despair;
            else
                return Emotion.Sadness;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
                return Emotion.Aggression;
            else if (Input.GetKey(KeyCode.S))
                return Emotion.Pessimism;
            else if (Input.GetKey(KeyCode.F))
                return Emotion.Anxiety;
            else
                return Emotion.Anticipation;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Input.GetKey(KeyCode.A))
                return Emotion.Powerless;
            else if (Input.GetKey(KeyCode.S))
                return Emotion.Despair;
            else if (Input.GetKey(KeyCode.D))
                return Emotion.Anxiety;
            else
                return Emotion.Fear;
        }

        return Emotion.None;
    }


    void disableBoard() {

        wordBank.enabled = false;
        wordBank.gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        sb.enabled = false;
        cm.enabled = false;
        sanityOverlay.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);

    }


}