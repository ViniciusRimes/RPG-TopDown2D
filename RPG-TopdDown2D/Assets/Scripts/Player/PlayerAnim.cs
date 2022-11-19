using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    
    
    
    private void AWake()
    {
    }
    void Start()
    {
        anim = GetComponent<Animator>();
         player = GetComponent<Player>();
       
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


}
