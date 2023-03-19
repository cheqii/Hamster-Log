using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private LogControl _logControl;
    private LevelSelect _levelSelect;
    private GameManager _gameManager;
    
    [Header("Start Button")] 
    [SerializeField] private GameObject[] St_Close;
    [SerializeField] private GameObject[] St_Open;
    
    [Header("Shop Button")] 
    [SerializeField] private GameObject[] Sh_Close;
    [SerializeField] private GameObject[] Sh_Open;

    [Header("Start Game Button")] 
    [SerializeField] private GameObject[] Sg_Close;
    [SerializeField] private GameObject[] Sg_Open;
    
    [Header("You Win Ui")] 
    [SerializeField] private GameObject[] Uw_Close;
    [SerializeField] private GameObject[] Uw_Open;

    
    private void Start()
    {
        _logControl = FindObjectOfType<LogControl>().GetComponent<LogControl>();
        _levelSelect= FindObjectOfType<LevelSelect>().GetComponent<LevelSelect>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    public void StartButton()
    {
        OpenAndClose(St_Close, St_Open);
    }
    
    public void ShopButton()
    {
        OpenAndClose(Sh_Close, Sh_Open);
        
    }


    public void StartGame()
    {
        OpenAndClose(Sg_Close, Sg_Open);
        _logControl.HamsterStart();
    }

    public void YouWin()
    {
        OpenAndClose(Uw_Close, Uw_Open);

    }
    
    

    private void OpenAndClose(GameObject[] close, GameObject[] open)
    {
        foreach (var i in close)
        {
            i.SetActive(false);
        }
        foreach (var i in open)
        {
            i.SetActive(true);
        }
    }
}
