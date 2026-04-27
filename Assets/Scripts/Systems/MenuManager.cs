using UnityEngine;
using UnityEngine.SceneManagement;

public GameObject mainMenuUI;
public GameObject classSelectUI;
public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject classSelectUI;

    private int selectedClass = 0; // 0 = Assassin, 1 = Mage

    void Start()
    {
        mainMenuUI.SetActive(true);
        classSelectUI.SetActive(false);
    }

    public void OpenClassSelect()
    {
        mainMenuUI.SetActive(false);
        classSelectUI.SetActive(true);
    }

    public void NextClass()
    {
        selectedClass = (selectedClass + 1) % 2;
        UpdateClass();
    }

    public void PrevClass()
    {
        selectedClass = (selectedClass - 1 + 2) % 2;
        UpdateClass();
    }

    void UpdateClass()
    {
        if (selectedClass == 0)
        {
            // Assassin
            PlayerData.maxHealth = 3;
            PlayerData.moveSpeed = 7f;
            Debug.Log("Assassin Selected");
        }
        else
        {
            // Mage
            PlayerData.maxHealth = 6;
            PlayerData.moveSpeed = 4f;
            Debug.Log("Mage Selected");
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Floor1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}