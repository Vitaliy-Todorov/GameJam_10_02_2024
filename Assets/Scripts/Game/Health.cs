using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private int _value;

    public void TakeDamage(int damage)
    {
        _value -= damage;
        
        if(_value <= 0)
            Destroy(gameObject);
    }
}
