using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI t;

    private void Awake() {

        t = GetComponent<TextMeshProUGUI>();
        t.text = "You helped " + GameManager.TOTAL_SUCCESSES + " people.";

    }

}
