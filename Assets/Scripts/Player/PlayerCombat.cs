using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    public GameObject attackHitbox;
    public float attackDuration = 0.2f;
    public float cooldown = 0.4f;
    public float attackDistance = 1.25f;

    private bool canAttack = true;
    private PlayerController controller;
    private PlayerHealth playerHealth;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (!canAttack) return;
        if (playerHealth != null && playerHealth.IsDead()) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;

        Vector2 dir = controller.LastDirection;
        if (dir == Vector2.zero)
        {
            dir = Vector2.right;
        }

        attackHitbox.transform.localPosition = new Vector3(
            dir.x * attackDistance,
            dir.y * attackDistance,
            0f
        );

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        attackHitbox.transform.localRotation = Quaternion.Euler(0, 0, angle);

        attackHitbox.SetActive(true);

        yield return new WaitForSeconds(attackDuration);

        attackHitbox.SetActive(false);

        yield return new WaitForSeconds(cooldown);

        canAttack = true;
    }
}