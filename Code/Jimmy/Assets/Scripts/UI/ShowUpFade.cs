using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUpFade : MonoBehaviour
{
    public float FadeTime = 0.5f;

    SpriteRenderer sp;
    Color alpha1;
    Color alpha0;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        alpha1 = new Color(sp.color.r, sp.color.g, sp.color.b, 1f);
        alpha0 = new Color(sp.color.r, sp.color.g, sp.color.b, 0f);


    }

    private void OnEnable()
    {
        StartCoroutine(IFade(alpha1));
    }
    IEnumerator IFade(Color color)
    {
        Color originColor = sp.color;
        float timer = 0f;

        while (timer < FadeTime)
        {
            timer += Time.deltaTime;

            sp.color = Color.Lerp(originColor, color, timer / FadeTime);

            yield return null;
        }
        
    }


}
