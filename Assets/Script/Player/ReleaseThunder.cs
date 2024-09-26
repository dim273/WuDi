using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseThunder : MonoBehaviour
{
    public GameObject enemy;
    public GameObject thunder;
    public void Thunder()
    {
        SkillUI.skill_enenge = 0;
        Vector3 real_position = new Vector3(enemy.transform.position.x, -4f, 0f);
        Instantiate(thunder, real_position, Quaternion.identity);
    }
}
