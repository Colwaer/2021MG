using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject wineDrop;
    WineDrop wineDropScript;

    public float timeVal = 2.0f;
    public float disableWaitVal = 0.6f;
    float timer = 0f;

    public Transform spawnPoint;

    bool disable = false;

    private void Awake()
    {
        wineDropScript = wineDrop.GetComponent<WineDrop>();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeVal && !disable)
        {
            disable = true;
            

            wineDropScript.Disable();
            
        }
        else if (timer >= timeVal + disableWaitVal)
        {
            disable = false;
            timer = 0f;
            wineDrop.SetActive(true);
            wineDrop.transform.position = spawnPoint.position;
        }
    }
}
