using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private List<GameObject> cars = new List<GameObject>();

    public List<GameObject> Cars { get => cars; set => cars = value; }

    public int GetCarCount() => Cars.Count;

}
