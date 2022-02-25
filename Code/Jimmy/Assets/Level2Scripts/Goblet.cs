using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblet : MonoBehaviour
{
    public Sprite[] sprites;
    private int index = 0;
    SpriteRenderer sp;
    public bool Full => index == sprites.Length;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WineDrop"))
        {
            if (index < sprites.Length)
            {
                collision.GetComponent<WineDrop>().Disable();


                sp.sprite = sprites[index++];
            }
        }
    }





}
