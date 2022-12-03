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
    public float Radius;
    
    [Header("Components")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField]private AnimationControl animationControl;
    [SerializeField]private LayerMask playerLayer;
    private Player player;
    private bool detectPlayer;

    



    void Start()
    {
        currentHealth = totalHealth;

        player = FindObjectOfType<Player>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    void Update()
    {
       if(!isDead && detectPlayer)
        {
            agent.isStopped = false;
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
            //enxergou o player
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
    
    private void FixedUpdate()
    {
        DetectPlayer();
    }
    
    public void DetectPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, Radius, playerLayer);

        if(hit != null)
        {
            //esta vendo o player
            detectPlayer = true;
        }
        else
        {
            //nao esta vendo o player
            detectPlayer = false;
            animationControl.PlayAnim(0);
            agent.isStopped = true;
        }

    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

}
