using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public int health = 2;
    public float knockbackForce = 2f;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log(gameObject.name + " HP: " + health);

        ApplyKnockback();

        if (health <= 0)
        {
            Debug.Log(gameObject.name + " died");
            Destroy(gameObject);
        }
    }

    void ApplyKnockback()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        Vector2 dir = (transform.position - player.transform.position).normalized;
        transform.position += (Vector3)(dir * knockbackForce * 0.3f);
    }
}