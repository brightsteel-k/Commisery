using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class WordBank : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private TextMeshProUGUI tmp;
    private RawImage image;
    private Mesh mesh;
    private Vector3[] originalVertices;
    private Vector3[] vertices;
    private float tick = 0;
    private Emotion selectedEmotion;
    private Color32 gray = new Color32(192, 192, 192, 255);
    [SerializeField] private Material fontRegular;
    [SerializeField] private Material fontHighlight;

    void Awake()
    {
        EventManager.START_COMMISERATE += onCommiserateStart;
        EventManager.GENERATE_ROOM += onRoomEnd;
    }

    // Start is called before the first frame update
    void Start()
    {
        tmp = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        image = GetComponent<RawImage>();
        mesh = tmp.mesh;
        setWord(Emotion.None);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedEmotion != Emotion.None)
        {
            vertices = mesh.vertices;
            animateWord();
        }
    }

    public void setWord(Emotion emotion)
    {
        selectedEmotion = emotion;
        image.CrossFadeColor(emotion.ChordColor(), 0.2f, false, false);
        if (selectedEmotion == Emotion.None)
            tmp.SetText("");
        else
            tmp.SetText(emotion.ToString());

        tmp.ForceMeshUpdate();
        originalVertices = mesh.vertices; 
    }

    private void animateWord()
    {
        tick += Time.deltaTime;
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = wobble(tick + i, 8f, 6f);
            vertices[i] = originalVertices[i] + offset;
        }

        mesh.vertices = vertices;
        tmp.canvasRenderer.SetMesh(mesh);
    }

    private Vector2 wobble(float time, float x, float y)
    {
        return new Vector2(Mathf.Sin(time * x) * 2f, Mathf.Cos(time * y) * 2f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (EventManager.COMMISERATING || selectedEmotion == Emotion.None)
            return;
        tmp.color = Color.white;
        tmp.fontMaterial = fontHighlight;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (EventManager.COMMISERATING)
            return;

        tmp.color = gray;
        tmp.fontMaterial = fontRegular;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (EventManager.COMMISERATING)
            return;
        GameManager.tryCommiserateEmotion(selectedEmotion);
    }

    void onRoomEnd()
    {
        selectedEmotion = Emotion.None;
        setWord(Emotion.None);
    }

    void onCommiserateStart(Emotion emotion)
    {

    }
}
