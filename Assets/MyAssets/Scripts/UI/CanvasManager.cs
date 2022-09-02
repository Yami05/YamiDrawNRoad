using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private Menu[] menus;


    private void Start()
    {
        GameEvents.GameOver += () => OpenMenu(MenuTag.Lose);
        GameEvents.Win += () => OpenMenu(MenuTag.Win);
        GameEvents.Start += () => OpenMenu(MenuTag.Idle);
    }

    public void OpenMenu(MenuTag tag)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].tag == tag)
            {
                menus[i].Open();
            }
            else if (menus[i].open)
            {
                menus[i].Close();
            }
        }
    }

}


