using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxVida(float Vida)
    {
        slider.maxValue = Vida;
        slider.value = Vida;
    }

    public void SetVida(float Vida)
    {
        slider.value = Vida;
    }
}
