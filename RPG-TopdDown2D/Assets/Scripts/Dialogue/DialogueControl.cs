using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt, 
        eng, 
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; //janela do diálogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; // texto da fala
    public Text actorNameText; //nome do Npc


    [Header("Setting")]
    public float typingSpeed; // velocidade da fala

    //Variáveis de controle;
    private bool _isShowing; //se a janela está visível
    private int index; //variável de controle de um loop de repetição das falas
    private string[] sentences;

    public static DialogueControl instance;

    public bool isShowing
    {
        get{return _isShowing;}
        set{_isShowing = value;}
    }

    public void Awake() //Awake é chamado antes de todos os Start() na hierarquia da execucao dos scripts
    {
        instance = this;
    }
    
    
    
    void Start() //executado ao iniciar
    {
        
    }


    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void Speech(string[] txt) //chamar a fala
    {
        if(!_isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            _isShowing = true;
        }
    }

    public void NextSentence() // pular para a próxima fala
    {
        if(speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else //quando termina a frase
            {
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                _isShowing= false;


            }
        }
    }



}
