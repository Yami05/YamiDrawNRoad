using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    private int winCounter;


    private void counter(int a)
    {
        winCounter = a;
    }

    private void CheckIt()
    {
        if (winCounter == 2)
        {
            GameEvents.Win?.Invoke();
        }
    }

}
