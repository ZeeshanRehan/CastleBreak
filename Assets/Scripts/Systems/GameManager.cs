using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject winUI;
    public GameObject loseUI;

    private bool gameEnded = false;

    void Awake()
    {
        Instance = this;
    }

    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;

        if (winUI != null)
            winUI.SetActive(true);
    }

    public void LoseGame()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;

        if (loseUI != null)
            loseUI.SetActive(true);
    }
}