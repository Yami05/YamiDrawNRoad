using UnityEngine;
using DG.Tweening;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private Transform torus;

    private DrawManager drawManager;

    private void Start()
    {
        drawManager = GetComponentInChildren<DrawManager>();
        torus.gameObject.SetActive(false);
        TorusMovement();
    }

    private void OnMouseDown()
    {
        drawManager.SetCanDraw();
        drawManager.ClearLists();
        GameEvents.MoveTogether?.Invoke();
        GameEvents.UndoForCollectables.Invoke();
        torus.gameObject.SetActive(true);
    }

    private void TorusMovement()
    {
        torus.DOScale(torus.localScale / 2, 1f).SetLoops(-1, loopType: LoopType.Yoyo);
    }
}
