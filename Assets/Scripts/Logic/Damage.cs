using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out Health health)) 
            health.TakeDamage(_damage);
    }
}
