using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonMasher : MonoBehaviour
{
    int buttonMashCount = 0;
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value == slider.maxValue)
        {
            PersitentData.Instance.outcome = 1;
            //Load random scene
        }
    }

    void OnBabyButtonMash()
    {
        slider.value = buttonMashCount++;
    }
}
