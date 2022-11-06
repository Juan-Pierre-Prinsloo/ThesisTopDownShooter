using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();

        //this is where we detect if we hit an enemy

        //also damage enemy if they are hit etc etc
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
