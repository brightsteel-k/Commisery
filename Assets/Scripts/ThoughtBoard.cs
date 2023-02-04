using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBoard : MonoBehaviour
{

    /** Anger, Sadness, Fear, Anticipation */
    bool[] current = {false, false, false, false};

    string chosen;

    void Update() {

        checkKeyPress();

        if (checkCombinations() != null) {

            chosen = checkCombinations();

        }

        print(chosen);
        
    }

    void checkKeyPress() {

        if (Input.GetKeyDown(KeyCode.A)) {

            current[0] = true;
            chosen = "Anger";

        }

        if (Input.GetKeyDown(KeyCode.S)) {

            current[1] = true;
            chosen = "Sadness";

        }

        if (Input.GetKeyDown(KeyCode.D)) {

            current[2] = true;
            chosen = "Fear";

        }

        if (Input.GetKeyDown(KeyCode.F)) {

            current[3] = true;
            chosen = "Anticipation";

        }

    }

    string checkCombinations() {

        string res;

        if (current[0] && current[1]) {

            res = "Envy";

        } else if (current[0] && current[2]) {

            res = "Undefined";

        } else if (current[0] && current[3]) {

            res = "Aggression";

        } else if (current[1] && current[2]) {

            res = "Despair";

        } else if (current[1] && current[3]) {

            res = "Pessimism";

        } else if (current[2] && current[3]) {

            res = "Anxiety";

        } else {

            res = null;

        }

        return res;

    }

}
