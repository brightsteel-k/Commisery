using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChordManager : MonoBehaviour
{
    [SerializeField] private Animator[] chordAnimators;
    [SerializeField] private Image[] chordImages;
    [SerializeField] private AudioSource[] chordAudios;
    public static Action[] CHORD_STRUMMED = new Action[4];

    private static AudioClip soundFail;

    static ChordManager INSTANCE;
    public static Color32 CURRENT_COLOR = Color.white;


    private void Awake()
    {
        EventManager.START_COMMISERATE += onCommiserateStart;
    }

    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = GetComponent<ChordManager>();
        ResetChordColors();
        soundFail = Resources.Load<AudioClip>("Sounds/Mistake");
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

    void ResetChordColors()
    {
        chordImages[0].CrossFadeColor(Emotion.Anger.ChordColor(), 0.5f, false, false);
        chordImages[1].CrossFadeColor(Emotion.Sadness.ChordColor(), 0.5f, false, false);
        chordImages[2].CrossFadeColor(Emotion.Anticipation.ChordColor(), 0.5f, false, false);
        chordImages[3].CrossFadeColor(Emotion.Fear.ChordColor(), 0.5f, false, false);
    }

    void strumChord(int index)
    {
        if (!EventManager.TRANSITION_COMPLETED)
            return;

        chordAnimators[index].SetTrigger("Strummed");
        if (!EventManager.COMMISERATING)
        {
            chordAudios[index].Play();
        }
        else
        {
            if (DotManager.checkChordStrum(index))
                chordAudios[index].Play();
            else
                chordFailure(index);
        }
    }

    void onCommiserateStart(Emotion emotion)
    {
        CURRENT_COLOR = emotion.ChordColor();
        foreach (Image img in chordImages)
        {
            img.CrossFadeColor(CURRENT_COLOR, 1.5f, false, false);
        }
    }

    public static void chordFailure(int index)
    {
        INSTANCE.chordAudios[index].PlayOneShot(soundFail);
        Image i = INSTANCE.chordImages[index];
        i.CrossFadeColor(Color.black, 0f, false, false);
        i.CrossFadeColor(CURRENT_COLOR, 1f, false, false);
        DotManager.missDot();
    }
}
