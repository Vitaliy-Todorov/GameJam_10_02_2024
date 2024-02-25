using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Health _health;

    public void Init(Hud hud)
    {
        _health.HealthAdd += hud.TakeDamage;
    }
}
