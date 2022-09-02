using UnityEngine;
using System;

interface IInteract
{
    void Interact(ColorType type);
}

public interface ICommand
{
    void Undo();
}

public class Interfaces : MonoBehaviour
{

}
