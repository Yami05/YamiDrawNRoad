using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;


    private void Start()
    {
        //offset = target.position - transform.position;
    }

    void FixedUpdate()
    {
        Vector3 desiredPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, 0.2f);
    }
}
