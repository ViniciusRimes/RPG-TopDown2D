 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("Stats")]
    public float currentHealth = 100;
    [SerializeField] public Image HealthBar;
    public float totalHealth;
    public bool isDead;
    
    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField]private AnimationControl animationControl;
    private Player player;



    void Start()
    {
        currentHealth = totalHealth;

        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    void Update()
    {
        if(!isDead)
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
            HealthBar.transform.eulerAngles = new Vector2(0,0);
        }
        else //esquerda
        {
            transform.eulerAngles = new Vector2 (0,180);
            HealthBar.transform.eulerAngles = new Vector2(0,180);
        }
       
        }
    }
       

}
