using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SanitySlider : MonoBehaviour
{

    private Slider slider;

    private void Awake()
    {
        EventManager.INSANIFY += insanify;
    }

    // Start is called before the first frame update
    private void Start()
    {

        slider = GetComponent<Slider>();

        slider.value = 0;

    }

    private void Update() {

    }

    public float getSanityLevel() {

        return slider.value;

    }

    public void setSanityLevel(float newVal) {

        slider.value = newVal;

    }

    // :)
    public void insanify(float n) {

        float startValue = slider.value;

        LeanTween.value(gameObject, 0, Math.Abs(n), 3.3f)
                     .setEase(LeanTweenType.linear)
                     .setOnUpdate((float val) => {
                slider.value = startValue + (n > 0 ? val : -val);
            });
    }
}
