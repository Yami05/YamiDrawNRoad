using UnityEngine;

public class StartPanel : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameEvents.Start();
        }
    }
}
