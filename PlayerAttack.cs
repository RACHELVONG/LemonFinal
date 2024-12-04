using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public ParticleSystem attackEffect; // Assign the particle effect in the Inspector
    public float attackRange = 5f;      // Range within which enemies are destroyed
    public LayerMask enemyLayer;        // Layer of enemy objects
    private bool hasUsedAttack = false; // Tracks if the ability is already used

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasUsedAttack)
        {
            PerformAttack();
            hasUsedAttack = true; // Mark the ability as used
        }
    }

    void PerformAttack()
    {
        // Trigger the particle effect
        if (attackEffect != null)
        {
            attackEffect.Play();
        }

        // Detect and destroy enemies within range
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);
        foreach (Collider enemy in enemies)
        {
            Destroy(enemy.gameObject); // Destroy enemy GameObject
        }
    }

    // Visualize the attack range in the Editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Debug.Log("PerformAttack called!");
    }

}
