using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChordManager : MonoBehaviour
{
    [SerializeField] private Animator[] chordAnimators;
    [SerializeField] private Image[] chordImages;
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
            chordAnimators[0].SetTrigger("Strummed");

        if (Input.GetKeyDown(KeyCode.S))
            chordAnimators[1].SetTrigger("Strummed");

        if (Input.GetKeyDown(KeyCode.D))
            chordAnimators[2].SetTrigger("Strummed");

        if (Input.GetKeyDown(KeyCode.F))
            chordAnimators[3].SetTrigger("Strummed");
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
