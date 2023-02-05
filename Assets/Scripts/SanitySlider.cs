using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SanitySlider : MonoBehaviour
{

    Slider slider;

    // Start is called before the first frame update
    void Start()
    {

        slider = GetComponent<Slider>();

        slider.value = 0;

    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.L)) {

            insanify(1.0f);

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

        LeanTween.value(gameObject, 0, Math.Abs(n), 400.0f)
                     .setEase(LeanTweenType.linear)
                     .setOnUpdate((float val) =>
            {
                
                print(val);
                slider.value += n > 0 ? val : -val;

            });

    }
    
}
