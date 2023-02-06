using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class WordBank : ShiftingText, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private RawImage image;
    private Emotion selectedEmotion;
    private Color32 gray = new Color32(192, 192, 192, 255);
    [SerializeField] private Material fontRegular;
    [SerializeField] private Material fontHighlight;

    void Awake()
    {
        EventManager.GENERATE_ROOM += onRoomEnd;
        EventManager.COMMISERATE_LOSE += onCommiserateEnd;
        EventManager.COMMISERATE_WIN += onCommiserateEnd;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        tmp = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        image = GetComponent<RawImage>();
        mesh = tmp.mesh;
        setWord(Emotion.None);
    }

    // Update is called once per frame
    public override void Update()
    {
        if (selectedEmotion != Emotion.None)
        {
            animateWord();

            if (Input.GetKeyDown(KeyCode.Space) && !EventManager.COMMISERATING && EventManager.TRANSITION_COMPLETED)
            {
                GameManager.tryCommiserateEmotion(selectedEmotion);
                setHighlight(true);
            }
        }

    }

    public void setWord(Emotion emotion)
    {
        selectedEmotion = emotion;
        image.CrossFadeColor(emotion.ChordColor(), 0.2f, false, false);
        if (selectedEmotion == Emotion.None)
            base.SetText("");
        else
            base.SetText(emotion.ToString());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (EventManager.COMMISERATING || selectedEmotion == Emotion.None)
            return;
        setHighlight(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (EventManager.COMMISERATING)
            return;
        setHighlight(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (EventManager.COMMISERATING)
            return;
        GameManager.tryCommiserateEmotion(selectedEmotion);
    }

    private void setHighlight(bool highlighted)
    {
        if (highlighted)
        {
            tmp.color = Color.white;
            tmp.fontMaterial = fontHighlight;
        }
        else
        {
            tmp.color = gray;
            tmp.fontMaterial = fontRegular;
        }
    }

    void onRoomEnd()
    {
        selectedEmotion = Emotion.None;
        setWord(Emotion.None);
    }

    void onCommiserateEnd()
    {
        setHighlight(false);
    }
}
