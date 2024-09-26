using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text health_text;
    private Image health_bar;
    public static int health_max;

    void Start()
    {
        health_bar = GetComponent<Image>();
    }

    void Update()
    {
        health_bar.fillAmount = (float)PlayerHealthy.health / (float)health_max;
        health_text.text = PlayerHealthy.health.ToString() + "/" + health_max.ToString();
    }
}
