using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChordManager : MonoBehaviour
{
    [SerializeField] private Animator[] chordAnimators;
    [SerializeField] private Image[] chordImages;
    public static Action[] CHORD_STRUMMED = new Action[4];
    
    static ChordManager INSTANCE;
    public static Color32 CURRENT_COLOR = Color.white;


    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = GetComponent<ChordManager>();
        EventManager.START_COMMISERATE += onCommiserateStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            strumChord(0);

        if (Input.GetKeyDown(KeyCode.S))
            strumChord(1);

        if (Input.GetKeyDown(KeyCode.D))
            strumChord(2);

        if (Input.GetKeyDown(KeyCode.F))
            strumChord(3);
    }

    void strumChord(int index)
    {
        chordAnimators[index].SetTrigger("Strummed");
        CHORD_STRUMMED[index]?.Invoke();
    }

    void onCommiserateStart(Emotion emotion)
    {
        CURRENT_COLOR = emotion.ChordColor();
        foreach (Image img in chordImages)
        {
            LeanTween.value(img.gameObject, img.color, CURRENT_COLOR, 1.5f)
                .setEaseOutSine()
                .setOnUpdateColor(c => img.color = c);
        }
    }

    public static void chordFailure(int index)
    {
        Image i = INSTANCE.chordImages[index];
        i.color = Color.black;
        LeanTween.value(i.gameObject, Color.black, CURRENT_COLOR, 1f)
            .setEaseOutQuad()
            .setOnUpdateColor(c => i.color = c);
    }
}
