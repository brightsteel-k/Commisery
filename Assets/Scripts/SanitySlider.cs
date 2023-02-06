using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SanitySlider : MonoBehaviour
{
    public static float TOTAL_SANITY;
    private Slider slider;

    private void Awake()
    {
        EventManager.INSANIFY += insanify;
    }

    // Start is called before the first frame update
    private void Start()
    {
        slider = GetComponent<Slider>();
        TOTAL_SANITY = 1f;
        slider.value = 0f;

    }

    public float getSanityLevel() {

        return slider.value;

    }

    public void setSanityLevel(float newVal) {

        slider.value = newVal;

    }

    // :)
    public void insanify(float n) {

        if (slider.value + n >= 0.99f) {

            EventManager.EndGame();
            return;

        }

        LeanTween.cancel(gameObject);
        float startValue = slider.value;
        TOTAL_SANITY = Mathf.Max(0f, TOTAL_SANITY - n);

        LeanTween.value(gameObject, startValue, 1f - TOTAL_SANITY, 3.3f)
                     .setEase(LeanTweenType.easeOutQuint)
                     .setOnUpdate((float val) => slider.value = val);
    }
}
