using UnityEngine;

public class ToolController : MonoBehaviour
{
    public float range = 1.5f;

    public void UseTool(ToolItem tool)
    {
        Collider2D hit = Physics2D.OverlapCircle(
            transform.position,
            range
        );

        if (hit == null) return;

        IDamageable damageable =
            hit.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(tool.power, gameObject);
        }
    }
}