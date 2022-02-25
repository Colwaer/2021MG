using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexAdjust : MonoBehaviour
{
    [SerializeField]
    public int sceneIndex = 0;

    private void Start()
    {
        MySceneManager.Instance.sceneIndex = sceneIndex;
    }
}
