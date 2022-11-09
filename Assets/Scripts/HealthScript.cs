using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float StartHealth;
    public GameObject DiePEffect;

    private Text HealthText;

    private float Hp;
    private bool IsPlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        Hp = StartHealth;

        IsPlayer = gameObject.name == "Player";

        HealthText = GameObject.FindWithTag("HealthText").GetComponent<Text>(); 

        Debug.Log(HealthText.text);

        SetPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        SetPlayerHealth();

        Hp -= damage;

        if (Hp <= 0f)
        {
            Die();
        }
    }

    void SetPlayerHealth()
    {
        if (IsPlayer)
        {
            HealthText.text = $"Player Health: {Hp}" ;
        }
    }

    void Die()
    {
        if (DiePEffect != null)
        {
            Instantiate(DiePEffect, transform.position, Quaternion.identity);
        }

        if (IsPlayer)
        {
            //gameover
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
