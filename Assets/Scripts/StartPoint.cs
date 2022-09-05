using UnityEngine;
using DG.Tweening;

public class StartPoint : MonoBehaviour
{
    [SerializeField] private Transform torus;

    private DrawManager drawManager;
    private UndoButton undo;
    private DrawManager manager;
    private CarController carController;

    private void Start()
    {
        undo = UndoButton.instance;
        manager = transform.GetChild(0).GetComponent<DrawManager>();
        carController = transform.GetChild(1).GetComponent<CarController>();

        drawManager = GetComponentInChildren<DrawManager>();
        torus.gameObject.SetActive(false);
        TorusMovement();
    }

    private void OnMouseDown()
    {
        drawManager.SetCanDraw();
        drawManager.ClearLists();
        GameEvents.MoveTogether?.Invoke();  
        torus.gameObject.SetActive(true);
    }

    private void TorusMovement()
    {
        torus.DOScale(torus.localScale / 2, 1f).SetLoops(-1, loopType: LoopType.Yoyo);
    }

}
