using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustDirection : MonoBehaviour
{
    Transform parent;
    Vector3 originScale;
    private void Awake()
    {
        parent = transform.parent;

        originScale = transform.localScale;
    }
    void Update()
    {
        if (parent.localScale.x > 0.1f)
            transform.localScale = originScale;
        else
            transform.localScale = new Vector3(-originScale.x, originScale.y, originScale.z);
    }
}
