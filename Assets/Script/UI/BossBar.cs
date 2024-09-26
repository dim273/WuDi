using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public static int boss_health;
    private int health_max = 100;
    private Image boss_health_show;
    private Image health_bar;
    private Enemy enemy;
    
    void Start()
    {
        health_bar = transform.Find("BossBarShow").GetComponent<Image>();
        boss_health_show = GetComponent<Image>();
        health_bar.enabled = false;
        boss_health_show.enabled = false;   
    }

    void Update()
    {
        if (Game.game_begin)
        {
            boss_health_show.enabled = true;
            health_bar.enabled = true;
        }
        health_bar.fillAmount = (float)boss_health / (float)health_max;
    }
}
