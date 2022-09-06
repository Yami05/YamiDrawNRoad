using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class CarController : MonoBehaviour, IUndo
{
    [SerializeField] private ColorType carColor;

    private MeshRenderer meshRenderer;
    private MaterialManager materialManager;
    private Rigidbody rb;
    private ObjectPool pool;

    private Vector3 firstPos;

    private bool canCollect;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pool = ObjectPool.instance;

        SetLine();
        transform.DOShakeScale(0.2f, 0.07f, 8, 0).SetLoops(-1);
        GameEvents.Explode += Explode;
        GameEvents.CarMovement += CarMovenet;

        firstPos = transform.eulerAngles;
    }

    public Vector3 firstRot() => firstPos;

    private void SetLine()
    {
        materialManager = MaterialManager.instance;
        meshRenderer = GetComponent<MeshRenderer>();
        materialManager.SetColor(carColor, meshRenderer.material);
    }


    public void CarPath(List<Vector3> vectors, float time)
    {
        GameEvents.undoTest?.Invoke(this);
        transform.DOPath(vectors.ToArray(), time).SetLookAt(lookAhead: 0).SetId("Car").SetEase(Ease.Linear);
        canCollect = true;

    }

    public ColorType GetCarColor() => carColor;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(carColor, canCollect);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<CarController>())
        {

            for (int i = 0; i < collision.contactCount; i++)
            {
                GameEvents.Explode?.Invoke(collision.GetContact(i));
            }
        }
    }

    private void Explode(ContactPoint contact)
    {
        DOTween.Kill("Car");
        rb.AddForceAtPosition(contact.point * 5, -contact.point);
        GameObject cloud = pool.GetFromPool(PoolItems.Crash);
        cloud.transform.position = contact.point;
        pool.ReturnToPool(cloud, PoolItems.Crash, 2f);
        rb.constraints = RigidbodyConstraints.None;

    }

    public void OnUndo()
    {
        GameEvents.CarMovement?.Invoke();
    }

    private void CarMovenet()
    {
        DOTween.Kill("Car");
        transform.DOMove(transform.parent.position, 0.3f);
        transform.DORotate(firstPos, 0.3f);
        canCollect = false;
        rb.freezeRotation = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;

    }

    private void OnDestroy()
    {
        GameEvents.Explode -= Explode;
    }

}


