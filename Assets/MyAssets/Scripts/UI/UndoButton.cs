using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UndoButton : Singleton<UndoButton>
{

    [SerializeField] private Button button;

    public List<IUndo> actions = new List<IUndo>();


    private bool canUndo = true;

    private void Start()
    {
        button.onClick.AddListener(Undo);
        GameEvents.undoTest += OnUndo;
        GameEvents.Win += () => canUndo = false;
    }

    private void OnUndo(IUndo obj)
    {
        actions.Add(obj);
    }

    public void Undo()
    {
        if (canUndo)
        {

            if (actions.Count == 0)
            {
                return;
            }

            GameEvents.UndoForCollectables?.Invoke();
            actions[0].OnUndo();
            actions.Remove(actions[0]);
        }


    }

}

