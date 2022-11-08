using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float StartHealth;
    public GameObject DiePEffect;

    private float Hp;



    // Start is called before the first frame update
    void Start()
    {
        Hp = StartHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        //Debug.Log($"{this.gameObject.name} took {damage} damage and has {Hp} hp left");

        Hp -= damage;

        if (Hp <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (DiePEffect != null)
        {
            Instantiate(DiePEffect, transform.position, Quaternion.identity);
        }

        if (gameObject.name != "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            //gameover
        }

    }
}
