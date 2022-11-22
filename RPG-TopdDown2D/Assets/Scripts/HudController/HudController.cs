using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    private PlayerItems playerItems;

    private Player player;

    [Header("Items")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

    [Header("Tools")]
    // [SerializeField] private Image axeUI;
    // [SerializeField] private Image shovelUI;
    // [SerializeField] private Image bucketUI;

    public List <Image> ToolsUI = new List<Image>();
    [SerializeField] private Color colorImage;
    [SerializeField] private Color alphaColor;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        player = FindObjectOfType<Player>();
    }
    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;

    }

    void Update()
    {
        waterUIBar.fillAmount = playerItems.currentWater / playerItems.waterLimit;
        woodUIBar.fillAmount = playerItems.totalWood / playerItems.woodLimit;
        carrotUIBar.fillAmount = playerItems.totalCarrot / playerItems.carrotLimit;

        //ToolsUI[player.handlingObj].color = colorimage;

        for(int i = 0; i < ToolsUI.Count; i++)
        {
            if(i == player.handlingObj)
            {
                ToolsUI[i].color = colorImage;
            }
            else
            {
                ToolsUI[i].color = alphaColor;
            }
        }

    }





}