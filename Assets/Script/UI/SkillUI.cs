using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public static int skill_enenge;
    public Image black;
    public Text num_show;
    private int skill_id;

    void Start()
    {
        skill_enenge = 0;
        skill_id = 10;
    }

    void Update()
    {
        num_show.text = skill_enenge.ToString() + "/" + skill_id;
        if(skill_enenge == skill_id ) 
        {
            black.enabled = false;
        }
        else
        {
            black.enabled = true;
        }
    }
}
