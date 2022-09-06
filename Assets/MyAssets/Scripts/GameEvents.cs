using System;
using UnityEngine;

public static class GameEvents
{
    public static Action Start;
    public static Action GameOver;
    public static Action Win;
    public static Action<ColorType> StartMove;
    public static Action MoveTogether;
    public static Action<ContactPoint> Explode;
    public static Action<IUndo> undoTest;
    public static Action UndoForCollectables;
    public static Action CarMovement;
    public static Action WinCond;
}
