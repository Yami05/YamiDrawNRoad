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

        GameEvents.MoveTogether += OnMoveTogether;
        GameEvents.UndoForCollectables += UndoForCollectables;

    }

    public void Interact(ColorType type, bool a)
    {
        if (type == colorType)
        {
            GameEvents.WinCond?.Invoke();
            inside.SetActive(true);
            GameObject parkParticle = pool.GetFromPool(PoolItems.ParkSpot);
            parkParticle.transform.position = transform.position;
            pool.ReturnToPool(parkParticle, PoolItems.ParkSpot, 1f);
            materialManager.SetColor(colorType, inside.GetComponent<MeshRenderer>().material);
        }
    }

    public ColorType GetColorType() => colorType;

    private void OnMoveTogether()
    {
        inside.SetActive(false);
    }

    private void UndoForCollectables()
    {
        inside.SetActive(false);
    }



    private void OnDestroy()
    {
        GameEvents.MoveTogether -= OnMoveTogether;
        GameEvents.UndoForCollectables -= UndoForCollectables;
    }
}
