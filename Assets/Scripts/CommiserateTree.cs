using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommiserateTree : MonoBehaviour
{
    [SerializeField] RawImage darkOverlay;
    [SerializeField] GameObject background;
    [SerializeField] RawImage[] chords;
    static CommiserateTree INSTANCE;
    private Color32 overlayColor = new Color(0, 0, 0, 0.65f);

    private void Awake()
    {
        EventManager.START_COMMISERATE += onCommiserateStart;
    }

    // Start is called before the first frame update
    void Start()
    {
        background.transform.position += new Vector3(0, 800, 0);
        transform.position += new Vector3(0, -1080, 0);
        INSTANCE = GetComponent<CommiserateTree>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void easeTreeIn() {

        LeanTween.move(background.gameObject, background.transform.position + new Vector3(0f, -800f, 0f), 3.3f).setEase(LeanTweenType.easeOutQuad);
        LeanTween.move(gameObject, transform.position + new Vector3(0f, 1080f, 0f), 2.0f)
            .setEase(LeanTweenType.easeOutSine);

    }

    private void onCommiserateStart(Emotion e)
    {
        setOverlayActive(true);
        easeTreeIn();
        LeanTween.delayedCall(2.2f, c => DotManager.startCommiserate(e));
    }

    private void setOverlayActive(bool active)
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
        EventManager.Insanify(despair ? 0.4f : 0.1f);
    }
}
