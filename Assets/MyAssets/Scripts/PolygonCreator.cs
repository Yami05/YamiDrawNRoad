using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonCreator : Singleton<PolygonCreator>
{

    //[SerializeField] private float radius;
    //[SerializeField] private List<Vector3> edges = new List<Vector3>();
    //[SerializeField] private List<Vector3> shadowPos = new List<Vector3>();
    //[SerializeField] private float offset;
    //[SerializeField] private CannonManager cannon;
    //[SerializeField] int sides;



    //public List<Vector3> Polygon()
    //{
    //    Vector3 pos;

    //    edges.Clear();
    //    shadowPos.Clear();

    //    float TAU = 2 * Mathf.PI;

    //    int currentPoint;
    //    sides = Random.Range(2, 7);

    //    for (currentPoint = 0; currentPoint < sides; currentPoint++)
    //    {
    //        float currentRadian = ((float)currentPoint / sides) * TAU;
    //        float x = Mathf.Cos(currentRadian) * radius;
    //        float z = Mathf.Sin(currentRadian) * radius;
    //        Vector3 edge = new Vector3(x, 0, z);
    //        edges.Add(edge);
    //    }
    //    for (int i = 0; i < edges.Count; i++)
    //    {
    //        float x = -edges[i].x + edges[(i + 1) % edges.Count].x;
    //        float z = -edges[i].z + edges[(i + 1) % edges.Count].z;

    //        for (int j = 0; j < offset; j++)
    //        {
    //            pos = edges[i] + new Vector3(x / offset * j, 0, z / offset * j);
    //            shadowPos.Add(pos);
    //        }
    //    }
    //    return shadowPos;
    //}

    //public int GetShadowCount() => shadowPos.Count;


}
