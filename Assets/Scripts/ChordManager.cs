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
    public static bool INTERACTABLE = true;

    private static AudioClip soundFail;

    static ChordManager INSTANCE;
    public static Color32 CURRENT_COLOR = Color.white;


    private void Awake()
    {
        EventManager.START_COMMISERATE += onCommiserateStart;
        EventManager.GENERATE_ROOM += disableInteraction;
        EventManager.GENERATE_ROOM += enableInteraction;
    }

    // Start is called before the first frame update
    void Start()
    {
        INSTANCE = GetComponent<ChordManager>();
        resetChordColors();
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

    public static void resetChordColors()
    {
        INSTANCE.chordImages[0].CrossFadeColor(Emotion.Anger.ChordColor(), 0.5f, false, false);
        INSTANCE.chordImages[1].CrossFadeColor(Emotion.Sadness.ChordColor(), 0.5f, false, false);
        INSTANCE.chordImages[2].CrossFadeColor(Emotion.Anticipation.ChordColor(), 0.5f, false, false);
        INSTANCE.chordImages[3].CrossFadeColor(Emotion.Fear.ChordColor(), 0.5f, false, false);
    }

    void strumChord(int index)
    {
        if (!INTERACTABLE)
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
        INSTANCE.chordAudios[index].PlayOneShot(soundFail, 1.5f);
        Image i = INSTANCE.chordImages[index];
        i.CrossFadeColor(Color.black, 0f, false, false);
        i.CrossFadeColor(CURRENT_COLOR, 1f, false, false);
        DotManager.missDot();
    }

    public static void enableInteraction()
    {
        INTERACTABLE = true;
    }

    public static void disableInteraction()
    {
        INTERACTABLE = false;
    }
}
