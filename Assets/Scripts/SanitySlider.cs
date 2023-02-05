using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SanitySlider : MonoBehaviour
{
    public static float TOTAL_SANITY = 1f;
    private Slider slider;

    private void Awake()
    {
        EventManager.INSANIFY += insanify;
    }

    // Start is called before the first frame update
    private void Start()
    {

        slider = GetComponent<Slider>();

    }

    private void Update() {

        if (slider.value >= 1.0f) {

            EventManager.EndGame();

        }

    }

    public float getSanityLevel() {

        return slider.value;

    }

    public void setSanityLevel(float newVal) {

        slider.value = newVal;

    }

    // :)
    public void insanify(float n) {

        LeanTween.cancel(gameObject);
        float startValue = slider.value;
        TOTAL_SANITY = Mathf.Max(0f, TOTAL_SANITY - n);

        LeanTween.value(gameObject, startValue, 1f - TOTAL_SANITY, 3.3f)
                     .setEase(LeanTweenType.easeOutQuint)
                     .setOnUpdate((float val) => slider.value = val);
    }
}
