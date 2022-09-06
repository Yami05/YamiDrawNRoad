using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class DrawManager : MonoBehaviour, IUndo
{
    [SerializeField] private List<Vector3> drawPoints = new List<Vector3>();
    [SerializeField] private List<Vector3> minim = new List<Vector3>();
    [SerializeField] private Transform car;

    private LineRenderer lineRenderer;
    private MaterialManager materialManager;
    private CarController carController;
    private Camera cam;

    private bool canDraw;
    private bool canMove;

    private LayerMask mask;

    private void Start()
    {
        materialManager = MaterialManager.instance;
        cam = Camera.main;

        carController = car.GetComponent<CarController>();
        lineRenderer = GetComponent<LineRenderer>();

        materialManager.SetColor(carController.GetCarColor(), lineRenderer.material);

        GameEvents.MoveTogether += FirstPosTogether;
        mask = LayerMask.GetMask("Ground", "ParkSpot");
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
        carController.OnUndo();
        canMove = true;
    }

    private void Draw()
    {

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 60, mask) && canDraw)
        {
            Vector3 desiredPos = hit.point;
            desiredPos.y = transform.position.y;
            drawPoints.Add(desiredPos);
            lineRenderer.positionCount = drawPoints.Count;
            lineRenderer.SetPositions(drawPoints.ToArray());

            if (hit.transform.gameObject.TryGetComponent<ParkSpot>(out ParkSpot spot))
            {
                if (spot.GetColorType() == carController.GetCarColor())
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
            List<float> vs = new List<float>();

            for (int i = 1; i < minim.Count; i++)
            {
                float dis = Vector3.Distance(minim[i], minim[i - 1]);
                vs.Add(dis);
            }

            float a = vs.Sum();
            carController.CarPath(minim, a / 10f);
            canMove = false;
            GameEvents.undoTest?.Invoke(this);
        }
    }

    public void OnUndo()
    {
        ClearLists();
    }


    private void OnDestroy()
    {
        GameEvents.MoveTogether -= FirstPosTogether;
    }
}
