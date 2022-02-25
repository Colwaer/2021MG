using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour , IClickable
{

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

        public void OnMouseButtonDown()
        {
            GoBack();
        }
    public void OnMouseButtonUp()
    {
        
    }


}
