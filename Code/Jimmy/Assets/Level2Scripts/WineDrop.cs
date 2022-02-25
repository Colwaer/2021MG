using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineDrop : MonoBehaviour
{
    SpriteRenderer sp;
    public float FadeTime = 0.5f;

    Rigidbody2D rb;

    Color alpha1;
    Color alpha0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        alpha1 = new Color(sp.color.r, sp.color.g, sp.color.b, 1f);
        alpha0 = new Color(sp.color.r, sp.color.g, sp.color.b, 0f);
    }


    private void OnEnable()
    {
        StartCoroutine(IFade(alpha1));
        rb.velocity = Vector2.zero;
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
        if (color == alpha0)
            gameObject.SetActive(false);
    }
    public void Disable()
    {
        StartCoroutine(IFade(alpha0));
    }



}
