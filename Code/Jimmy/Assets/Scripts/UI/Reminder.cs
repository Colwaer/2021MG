using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reminder : MonoBehaviour, IClickable
{
    // Start is called before the first frame update
    private new SpriteRenderer renderer;
    public float waitTime;
    public Reminder next;
    public float startTime;

    private void Awake()
    {
        startTime = Time.time;
        renderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
        Color color = renderer.color;
        color.a = Mathf.Sin(Time.time * 2) / 2 + 0.5f;
        renderer.color = color;
        Debug.Log(renderer.color.a);
    }

    public void OnMouseButtonDown()
    {
        if (Time.time - startTime >= waitTime)
        {
            next.gameObject.SetActive(true);
        }
        
    }

    public void OnMouseButtonUp()
    {
        
    }
}
