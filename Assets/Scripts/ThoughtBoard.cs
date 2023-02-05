using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThoughtBoard : MonoBehaviour
{
    [SerializeField] WordBank wordBank;
    [SerializeField] Button sb;
    [SerializeField] GameObject sanityOverlay;
    [SerializeField] GameObject nebula;
    Emotion chosen;

    void Start() {

        EventManager.GENERATE_ROOM += disableBoard;

    }

    void Update()
    {

        if (!EventManager.COMMISERATING && EventManager.TRANSITION_COMPLETED)
        {
            chosen = readInitialChordInput();

            if (chosen != Emotion.None)
                wordBank.setWord(chosen);
        }

        if (EventManager.TRANSITION_COMPLETED) {

            GameManager.TRANSITION_COND_1 = true;
            sb.enabled = true;
            nebula.transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
            nebula.transform.GetChild(1).gameObject.GetComponent<Image>().color = Color.white;
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
        sb.enabled = false;
        print(nebula.transform.GetChild(0).gameObject.GetComponent<Image>().color);
        nebula.transform.GetChild(0).gameObject.GetComponent<Image>().color = new Color(29f/255f, 29f/255f, 29f/255f, 255f);
        nebula.transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(29f/255f, 29f/255f, 29f/255f, 255f);
        sanityOverlay.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);

    }


}