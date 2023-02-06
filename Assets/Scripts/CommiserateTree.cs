using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommiserateTree : MonoBehaviour
{
    [SerializeField] RawImage darkOverlay;
    [SerializeField] GameObject background;
    [SerializeField] RawImage[] chords;
    static AudioSource audioSource;
    static CommiserateTree INSTANCE;
    private Color32 overlayColor = new Color(0, 0, 0, 0.65f);

    private void Awake()
    {
        EventManager.START_COMMISERATE += onCommiserateStart;
        EventManager.COMMISERATE_WIN += succeedCommiserate;
    }

    // Start is called before the first frame update
    void Start()
    {
        background.transform.position += new Vector3(0, 800, 0);
        audioSource = GetComponent<AudioSource>();
        transform.position += new Vector3(0, -1080, 0);
        INSTANCE = GetComponent<CommiserateTree>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void easeTreeIn() {

        LeanTween.move(gameObject, transform.position + new Vector3(0f, 1080f, 0f), 2.0f)
            .setEase(LeanTweenType.easeOutSine);
        LeanTween.move(background.gameObject, background.transform.position - new Vector3(0f, 800f, 0f), 3.3f).setEase(LeanTweenType.easeOutQuad)
            .setOnComplete(ChordManager.enableInteraction);
    }
    void easeTreeOut()
    {
        LeanTween.move(gameObject, transform.position - new Vector3(0f, 1080f, 0f), 0.1f);
        LeanTween.move(background.gameObject, background.transform.position + new Vector3(0f, 800f, 0f), 0.2f).setEase(LeanTweenType.easeOutSine);
    }

    private void onCommiserateStart(Emotion e)
    {
        setOverlayActive(true);
        ChordManager.disableInteraction();
        easeTreeIn();
        LeanTween.delayedCall(2.2f, c => DotManager.startCommiserate(e));
    }

    public void setOverlayActive(bool active)
    {
        if (active)
        {
            darkOverlay.color = Color.clear;
            darkOverlay.gameObject.SetActive(true);
            LeanTween.value(darkOverlay.gameObject, Color.clear, overlayColor, 2.4f)
                .setOnUpdate(u => darkOverlay.color = u)
                .setEaseOutQuad();
        }
        else
        {
            LeanTween.value(darkOverlay.gameObject, overlayColor, Color.clear, 1.2f)
                .setOnUpdate(u => darkOverlay.color = u)
                .setEaseOutQuad()
                .setOnComplete(e => darkOverlay.gameObject.SetActive(false));
        }
    }

    public static void failCommiserate(bool despair)
    {
        INSTANCE.easeTreeOut();
        INSTANCE.setOverlayActive(false);
        ChordManager.resetChordColors();
        GameManager.FAILED_EMOTION = DotManager.CURRENT_EMOTION;
        EventManager.Insanify(despair ? 0.4f : 0.1f);
        EventManager.CommiserateLose();
    }

    public static void succeedCommiserate()
    {
        INSTANCE.easeTreeOut();
        INSTANCE.setOverlayActive(false);
        audioSource.Play();
        ChordManager.resetChordColors();
        ChordManager.disableInteraction();
    }
}
