using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    private int winCounter;

    private void Start()
    {
        GameEvents.WinCond += WinCheck;
        GameEvents.UndoForCollectables += () => winCounter = 0;
    }

    private void WinCheck()
    {
        winCounter++;
        if (winCounter == 2)
        {
            GameEvents.Win?.Invoke();
        }
    }

}
