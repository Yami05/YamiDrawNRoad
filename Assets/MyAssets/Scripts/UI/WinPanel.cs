using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] Button button;

    void Start()
    {
        button.onClick.AddListener(NextLevel);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(0);
    }
}
