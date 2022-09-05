using UnityEngine;

public class CanvasManager : Singleton<CanvasManager>
{
    [SerializeField] private Menu[] menus;


    private void Start()
    {
        GameEvents.GameOver += Gameover;
        GameEvents.Win += NextLevel;
        GameEvents.Start += StartGame;
    }


    private void Gameover()
    {
        OpenMenu(MenuTag.Lose);
    }

    private void NextLevel()
    {
        OpenMenu(MenuTag.Win);
    }

    private void StartGame()
    {
        OpenMenu(MenuTag.Idle);
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

    private void OnDestroy()
    {
        GameEvents.GameOver -= Gameover;
        GameEvents.Win -= NextLevel;
        GameEvents.Start -= StartGame;
    }
}


