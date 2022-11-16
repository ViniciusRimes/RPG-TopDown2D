using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriterenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private int digAmount; //quantidade de vezes para escavar
    private int initialDigAmount;

    private bool isDig;

    private void Start()
    {
        initialDigAmount = digAmount;
    }
    

    public void OnHit()
    {
        digAmount--;

        if(digAmount < initialDigAmount / 2)
        {
            //escavando o buraco
            spriterenderer.sprite = hole;
        }

        /*if (digAmount < 0)
        {
            //plantar cenoura
            spriterenderer.sprite = carrot;
        }*/
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dig") && !isDig)
        {
            OnHit();
        }
    }
}
