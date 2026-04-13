using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public TextMeshProUGUI hpText;

    void Update()
    {
        hpText.text = "HP: " + playerHealth.GetCurrentHealth();
    }
}