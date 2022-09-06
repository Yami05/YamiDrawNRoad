using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinManager : MonoBehaviour, IInteract
{
    private ObjectPool pool;

    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
        pool = ObjectPool.instance;
        GameEvents.UndoForCollectables += UndoForCollectables;
    }

    public void Interact(ColorType type, bool canCollect)
    {
        if (canCollect)
        {
            GameObject particle = pool.GetFromPool(PoolItems.Coin);
            particle.transform.position = transform.position;
            pool.ReturnToPool(particle, PoolItems.Coin, 1f);

            gameObject.SetActive(false);

        }
    }

    private void UndoForCollectables()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvents.UndoForCollectables -= UndoForCollectables;
    }
}
