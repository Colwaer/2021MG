using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private SpriteRenderer sp;

    public float fadeTime = 2.0f;
    private float fadeTimer = 0f;

    private bool startFade = false;

    private Color color;

    private float deltaFade;


    public float value = 1;

    public bool destroy = false;

    public bool Done = false;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Done)
            return;

        if (startFade)
        {
            fadeTimer += Time.deltaTime;
            sp.color += new Color(color.r, color.g, color.b, value * deltaFade);
        }
        if (fadeTimer >= fadeTime + 0.6f)
        {
            if (destroy)
            {
                Destroy(gameObject);
            }
            else
            {
                
                Done = true;
            }
        }
    }


    public void StartFade()
    {
        color = sp.color;
        startFade = true;

        deltaFade = 1f / fadeTime * Time.deltaTime;
    }
}
