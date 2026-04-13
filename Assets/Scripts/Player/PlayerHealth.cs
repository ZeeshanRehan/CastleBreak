using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public int maxHealth = 5;
    public float invulnDuration = 1f;

    private int currentHealth;
    private bool isInvulnerable = false;
    private bool isDead = false;

    private PlayerController playerController;

    void Start()
    {
        currentHealth = maxHealth;
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(int amount)
    {
        if (isInvulnerable || isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        StartCoroutine(InvulnerabilityFrames());
    }

    void Die()
    {
        isDead = true;

        if (playerController != null)
        {
            playerController.canMove = false;
        }

        Debug.Log("Game Over");
    }

    IEnumerator InvulnerabilityFrames()
    {
        isInvulnerable = true;

        yield return new WaitForSeconds(invulnDuration);

        isInvulnerable = false;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public bool IsDead()
    {
        return isDead;
    }
}