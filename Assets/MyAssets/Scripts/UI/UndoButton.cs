using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UndoButton : Singleton<UndoButton>
{
    private int count = 0;

    [SerializeField] private Button button;
    [SerializeField] private List<Action> actions = new List<Action>();

    public List<Action> Actions { get => actions; set => actions = value; }

    private void Start()
    {
        button.onClick.AddListener(Undo);
    }

    public void Undo()
    {

        if (actions.Count == 0)
        {
            return;
        }

        Debug.Log(actions.Count);
        Actions[count].Invoke();
        count++;
    }

    public int SetCount() => count = 0;
}

