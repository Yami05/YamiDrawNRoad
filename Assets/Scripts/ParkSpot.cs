using UnityEngine;

public class ParkSpot : MonoBehaviour, IInteract
{
    [SerializeField] private ColorType colorType;
    [SerializeField] private GameObject inside;

    private MaterialManager materialManager;
    private ObjectPool pool;
    private MeshRenderer[] renderers;


    private void Start()
    {
        materialManager = MaterialManager.instance;
        pool = ObjectPool.instance;
        renderers = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++)
        {
            materialManager.SetColor(colorType, renderers[i].material);
        }

        GameEvents.MoveTogether += () => inside.SetActive(false);
        GameEvents.UndoButton += () => inside.SetActive(false);
    }

    public void Interact(ColorType type)
    {
        if (type == colorType)
        {
            inside.SetActive(true);
            GameObject parkParticle = pool.GetFromPool(PoolItems.ParkSpot);
            parkParticle.transform.position = transform.position;
            pool.ReturnToPool(parkParticle, PoolItems.ParkSpot, 1f);
            materialManager.SetColor(colorType, inside.GetComponent<MeshRenderer>().material);
        }
    }

    public ColorType GetColorType() => colorType;
}
