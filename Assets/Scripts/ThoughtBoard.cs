using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBoard : MonoBehaviour
{
    [SerializeField] WordBank wordBank;
    Emotion chosen;

    void Update()
    {
        if (!EventManager.COMMISERATING)
        {
            chosen = readInitialChordInput();

            if (chosen != Emotion.None)
                wordBank.setWord(chosen);
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


}