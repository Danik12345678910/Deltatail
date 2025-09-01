using UnityEngine;

public class Projectile : Pool
{
    [SerializeField, Min(0)] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}