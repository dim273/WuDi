using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float smooth;
    public Transform target;

    public Vector2 min_pos;
    public Vector2 max_pos;
    void Start()
    {
        
    }
    public void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 target_pos = target.position;
                target_pos.x = Mathf.Clamp(target_pos.x, min_pos.x, max_pos.x);
                target_pos.y = Mathf.Clamp(target_pos.y, min_pos.y, max_pos.y);
                transform.position = Vector3.Lerp(transform.position, target_pos, smooth);
            }
        }
    }
    public void SetLimitPos(Vector2 MinPos, Vector2 MaxPos)
    {
        min_pos = MinPos;
        max_pos = MaxPos;
    }
}
