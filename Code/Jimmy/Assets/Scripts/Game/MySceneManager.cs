using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : Singleton<MySceneManager>
{


    public int sceneIndex = 0;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(this.gameObject);
    }


    public void EnterNextScene()
    {
        sceneIndex++;
        SceneManager.LoadScene(sceneIndex);
    }
     
    public void EnterScene(int index)
    {
        sceneIndex = index;
        SceneManager.LoadScene(index);
    }









}
