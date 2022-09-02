using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private DrawManager drawManager;

    private void Start()
    {
        drawManager = GetComponentInChildren<DrawManager>();
    }

    private void OnMouseDown()
    {
        drawManager.SetCanDraw();
        drawManager.ClearLists();
        GameEvents.MoveTogether?.Invoke();
        UndoButton.instance.Actions.Clear();
        UndoButton.instance.SetCount();
    }
}
