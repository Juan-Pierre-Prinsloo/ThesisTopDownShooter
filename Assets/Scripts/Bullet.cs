using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;

    public Bullet(float damage)
    {
        this.Damage = damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        
        if (collisionGameObject.GetComponent<HealthScript>() != null)
        {
            collisionGameObject.GetComponent<HealthScript>().TakeDamage(Damage);
        }

        if (collisionGameObject.GetComponent<Rigidbody2D>() != null)
        {
            collisionGameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        Die();
    }

    private void OnBecameInvisible()
    {
        ///This deletes the bullet when it moves off screen
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
