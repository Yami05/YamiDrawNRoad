using UnityEngine;
using System;

interface IInteract
{
    void Interact(ColorType type);
}

public interface IUndo
{
    void OnUndo();
}

public class Interfaces : MonoBehaviour
{

}
