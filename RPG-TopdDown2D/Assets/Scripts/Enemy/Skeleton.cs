 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton : MonoBehaviour
{
    [Header("Stats")]
    public float Health = 100;
    
    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField]private AnimationControl animationControl;
    private Player player;



    void Start()
    {
        player = FindObjectOfType<Player>();
        animationControl = FindObjectOfType<AnimationControl>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    void Update()
    {

        agent.SetDestination(player.transform.position); //seguir o player

        if(Vector2.Distance(transform.position, player.transform.position) < agent.stoppingDistance)
        {
        //chegou no limite de distancia // skeleton para
        animationControl.PlayAnim(2); //attack

        }
        else
        {
        //skeleton segue o player
        animationControl.PlayAnim(1); //walking
        }

        float posX = player.transform.position.x - transform.position.x;
          
        if(posX > 0) //direita
        {
            transform.eulerAngles = new Vector2(0,0);
        }
        else //esquerda
        {
            transform.eulerAngles = new Vector2 (0,180);
        }
       
    }

}
