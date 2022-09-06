using UnityEngine;
using DG.Tweening;

public class StartPoint : MonoBehaviour, IInteract
{
    [SerializeField] private Transform torus;

    private DrawManager drawManager;

    private bool isDraw = true;

    private void Start()
    {
        drawManager = GetComponentInChildren<DrawManager>();
        GameEvents.Win += () => isDraw = false;
        torus.gameObject.SetActive(false);
        TorusMovement();
    }

    private void OnMouseDown()
    {
        if (isDraw)
        {
            drawManager.SetCanDraw();
            drawManager.ClearLists();
            GameEvents.MoveTogether?.Invoke();
            GameEvents.UndoForCollectables.Invoke();
            torus.gameObject.SetActive(true);

        }
    }

    private void TorusMovement()
    {
        torus.DOScale(torus.localScale / 2, 1f).SetLoops(-1, loopType: LoopType.Yoyo);
    }

    public void Interact(ColorType type, bool a)
    {
        a = false;
    }
}
