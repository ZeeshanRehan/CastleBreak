using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2f;
    public int contactDamage = 1;

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector2 dir = (player.position - transform.position).normalized;
        transform.position += (Vector3)(dir * speed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable dmg = collision.gameObject.GetComponent<IDamageable>();

            if (dmg != null)
            {
                dmg.TakeDamage(contactDamage);
            }
        }
    }
}