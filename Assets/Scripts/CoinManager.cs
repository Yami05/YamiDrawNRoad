using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinManager : MonoBehaviour, IInteract
{
    public void Interact(ColorType type)
    {
        gameObject.SetActive(false);
        GameEvents.UndoForCollectables += () => gameObject.SetActive(true);
    }

    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);
    }
}
