using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChordManager : MonoBehaviour
{

    Animator chord1;
    Animator chord2;
    Animator chord3;
    Animator chord4;

    // Start is called before the first frame update
    void Start()
    {

        chord1 = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        chord2 = gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>();
        chord3 = gameObject.transform.GetChild(2).gameObject.GetComponent<Animator>();
        chord4 = gameObject.transform.GetChild(3).gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
            chord1.SetTrigger("Strummed");

        if (Input.GetKeyDown(KeyCode.S))   
            chord2.SetTrigger("Strummed");

        if (Input.GetKeyDown(KeyCode.D))
            chord3.SetTrigger("Strummed");

        if (Input.GetKeyDown(KeyCode.F))
            chord4.SetTrigger("Strummed");
        
    }
}
