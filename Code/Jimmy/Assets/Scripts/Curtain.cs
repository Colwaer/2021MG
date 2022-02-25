using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Curtain : MonoBehaviour
{
    private bool chooseLevel = false;
    private int levelIndex = 0;
    public void ChooseScene(int num)
    {
        chooseLevel = true;
        levelIndex = num;
    }

    //动画事件
    public void NextLevel()
    {
        if(chooseLevel)
        {
            SceneManager.LoadScene(levelIndex);
            return ;
        }

        MySceneManager.Instance.EnterNextScene();
    }
}
