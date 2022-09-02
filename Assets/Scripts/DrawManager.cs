using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DrawManager : MonoBehaviour
{
    [SerializeField] private List<Vector3> drawPoints = new List<Vector3>();
    [SerializeField] private List<Vector3> minim = new List<Vector3>();
    [SerializeField] private Transform car;

    private LineRenderer lineRenderer;
    private MaterialManager materialManager;
    private CarController carController;
    private Camera cam;
    private UndoButton undo;

    private LayerMask layerMask;

    private bool canDraw;
    private bool canMove;

    private void Start()
    {
        materialManager = MaterialManager.instance;
        undo = UndoButton.instance;
        cam = Camera.main;

        carController = car.GetComponent<CarController>();
        lineRenderer = GetComponent<LineRenderer>();

        materialManager.SetColor(carController.SetLineColor(), lineRenderer.material);

        layerMask = LayerMask.GetMask("Ground");

        GameEvents.MoveTogether += FirstPosTogether;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Draw();
        }

        if (Input.GetMouseButtonUp(0))
        {
            canDraw = false;
            MinimIt();
            MoveCar();
        }
    }

    public bool SetCanDraw() => canDraw = true;

    public void ClearLists()
    {
        lineRenderer.positionCount = 1;
        drawPoints.Clear();
    }

    private void FirstPosTogether()
    {
        minim.Clear();
        car.transform.DOMove(transform.parent.position, 0.3f);
        DOTween.Kill("Car");
        canMove = true;
    }

    private void Draw()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 60) && canDraw)
        {
            Vector3 desiredPos = hit.point;
            desiredPos.y = transform.position.y;
            drawPoints.Add(desiredPos);
            lineRenderer.positionCount = drawPoints.Count;
            lineRenderer.SetPositions(drawPoints.ToArray());

            if (hit.transform.gameObject.TryGetComponent<ParkSpot>(out ParkSpot spot))
            {
                if (spot.GetColorType() == carController.SetLineColor())
                {
                    canDraw = false;
                }
            }
        }
    }

    private void MinimIt()
    {

        for (int i = 1; i < drawPoints.Count; i++)
        {
            float dis = Vector3.Distance(drawPoints[i], drawPoints[i - 1]);
            if (dis > 0.1f)
            {
                minim.Add(drawPoints[i]);
            }
        }
    }

    public void MoveCar()
    {
        if (canMove)
        {
            carController.CarPath(minim);
            undo.Actions.Add(GameEvents.MoveTogether);
            undo.Actions.Add(ClearLists);
            canMove = false;


        }
    }

}
