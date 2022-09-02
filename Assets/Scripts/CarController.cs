using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    [SerializeField] private ColorType carColor;

    private MeshRenderer meshRenderer;
    private MaterialManager materialManager;
    private Rigidbody rb;
    private ObjectPool pool;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pool = ObjectPool.instance;

        SetLine();
        transform.DOShakeScale(0.2f, 0.07f, 8, 0).SetLoops(-1);
        GameEvents.Explode += Explode;
    }

    private void SetLine()
    {
        materialManager = MaterialManager.instance;
        meshRenderer = GetComponent<MeshRenderer>();
        materialManager.SetColor(carColor, meshRenderer.material);
    }


    public void CarPath(List<Vector3> vectors)
    {
        transform.DOPath(vectors.ToArray(), vectors.Count * 0.15f).SetLookAt(lookAhead: 0).SetId("Car");
    }

    public ColorType SetLineColor() => carColor;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.Interact(carColor);

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
    }
}


