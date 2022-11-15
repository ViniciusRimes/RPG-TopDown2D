using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{

    public float dialogueRange;
    public LayerMask playerLayer;

    public bool playerHit;

    public DialogueSettings Dialogue;

    private List<string> sentences = new List<string>();


    // Start is called before the first frame update
    private  void Start()
    {
        GetNPCInfo();
    }

    void Update() //chamado a cada frame
    {
        if(Input.GetKeyDown(KeyCode.E) && playerHit)
        {
            DialogueControl.instance.Speech(sentences.ToArray());;
        }
    }

    void GetNPCInfo()
    {
        for(int i = 0; i < Dialogue.Dialogues.Count; i++)
        {
            switch(DialogueControl.instance.language)
            {
                case DialogueControl.idiom.pt:
                sentences.Add(Dialogue.Dialogues[i].sentence.portuguese);
                break;
                
                case DialogueControl.idiom.eng:
                sentences.Add(Dialogue.Dialogues[i].sentence.english);
                break;

                case DialogueControl.idiom.spa:
                sentences.Add(Dialogue.Dialogues[i].sentence.spanish);
                break;

            }
            
        }
    }

    
    void FixedUpdate() //usado pela física
    {
        ShowDialogue();
    }

    void ShowDialogue()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            playerHit = true;

        }
        else
        {
            playerHit = false;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
        
    }

}