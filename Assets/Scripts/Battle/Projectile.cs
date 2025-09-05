using UnityEngine;

public class Projectile : Pool
{
    [SerializeField, Min(0)] private int _damage;
    private const string PLAYER_TAG = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == PLAYER_TAG)
        {

        }
    }
}