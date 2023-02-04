using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBoard : MonoBehaviour
{

    string chosen;

    void Update() {

        if (Input.GetKeyDown(KeyCode.A)) {

            if (Input.GetKey(KeyCode.S)) {

                chosen = "Envy";

            } else if (Input.GetKey(KeyCode.D)) {

                chosen = "Aggression";

            } else if (Input.GetKey(KeyCode.F)) {

                chosen = "N/A";

            } else {

                chosen = "Anger";

            }

        }

        if (Input.GetKeyDown(KeyCode.S)) {

            if (Input.GetKey(KeyCode.A)) {

                chosen = "Envy";

            } else if (Input.GetKey(KeyCode.D)) {

                chosen = "Pessimism";

            } else if (Input.GetKey(KeyCode.F)) {

                chosen = "Despair";

            } else {

                chosen = "Sadness";

            }

        }

        if (Input.GetKeyDown(KeyCode.D)) {

            if (Input.GetKey(KeyCode.A)) {

                chosen = "Aggression";

            } else if (Input.GetKey(KeyCode.S)) {

                chosen = "Pessimism";

            } else if (Input.GetKey(KeyCode.F)) {

                chosen = "Anxiety";

            } else {

                chosen = "Anticipation";

            }

        }

        if (Input.GetKeyDown(KeyCode.F)) {

            if (Input.GetKey(KeyCode.A)) {

                chosen = "N/A";

            } else if (Input.GetKey(KeyCode.S)) {

                chosen = "Despair";

            } else if (Input.GetKey(KeyCode.D)) {

                chosen = "Anxiety";

            } else {

                chosen = "Fear";

            }

        }

        print(chosen);

    }

}