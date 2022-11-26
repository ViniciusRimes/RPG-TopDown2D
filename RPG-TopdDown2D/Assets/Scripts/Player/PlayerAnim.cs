using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;
    private Casting casting;

    private House house;

    
    void Start()
    {
    
        anim = GetComponent<Animator>();
        player = GetComponent<Player>();
        casting = FindObjectOfType<Casting>();
        house = FindObjectOfType<House>();
       
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
        
    
    }

    #region Movement
    
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0 )
        {
            if (player.isRolling) //rolar
            {
                anim.SetTrigger("isRoll");
            }
            else
            {   
                anim.SetInteger("Transition", 1); //andar
            }
            
        }
        else
        {
            anim.SetInteger("Transition", 0); //iddle
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0,0); //direcao
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0,180f); //direcao rotacionando
        }

        if(player.isCutting)
        {
            anim.SetInteger("Transition", 3); //cortar arvore
            
        }

        if(player.isDigging)
        {
            anim.SetInteger("Transition", 4); //escavar
        }

        if(player.isWatering)
        {
            anim.SetInteger("Transition", 5); //encher regador
            
        }

        if(player.isRuning == true) //correr
        {
            anim.SetInteger("Transition", 2);
        }
    }



    #endregion
    
    //é chamado quando o jogador pressiona o botao de acao na agua
    public void OnCastingStarted()
    {
        anim.SetTrigger("IsCasting");
        player.isPaused = true;
    }   
    // chamado quando termina a animacao de pescar
    public void OnCastingEndend()
    {
        casting.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted()
    {
        anim.SetBool("isHammering", true);
    }
    public void OnHammeringEnded()
    {
        anim.SetBool("isHammering", false);
    }

}