using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBoard : MonoBehaviour
{
    [SerializeField] WordBank wordBank;
    string chosen;

    void Update()
    {
        chosen = readChordInput();

        if (chosen != "")
            wordBank.setWord(chosen);

    }

    string readChordInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.S))
                return "Envy";
            else if (Input.GetKey(KeyCode.D))
                return "Aggression";
            else if (Input.GetKey(KeyCode.F))
                return "N/A";
            else
                return "Anger";
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
                return "Envy";
            else if (Input.GetKey(KeyCode.D))
                return "Pessimism";
            else if (Input.GetKey(KeyCode.F))
                return "Despair";
            else
                return "Sadness";
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
                return "Aggression";
            else if (Input.GetKey(KeyCode.S))
                return "Pessimism";
            else if (Input.GetKey(KeyCode.F))
                return "Anxiety";
            else
                return "Anticipation";
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Input.GetKey(KeyCode.A))
                return "N/A";
            else if (Input.GetKey(KeyCode.S))
                return "Despair";
            else if (Input.GetKey(KeyCode.D))
                return "Anxiety";
            else
                return "Fear";
        }

        return "";
    }
}