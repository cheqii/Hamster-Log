using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private BlockGenerate1 startBlock;
    [SerializeField] private int lv;


    private void Start()
    {
        ChangeLevel(lv-1);
    }

    public void ChangeLevel(int _level)
    {
        startBlock.SetLevel(_level,GameData.Instance.GetLaneSwitch(_level));
    }
}
