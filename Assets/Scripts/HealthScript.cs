using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float StartHealth;
    
    public GameObject DiePEffect;

    public GameOverScreen GameOver;

    public GameMasterScript GameMaster;

    private Text HealthText;

    private float Hp;
    private bool IsPlayer = false;


    // Start is called before the first frame update
    void Start()
    {
        GameMaster = GameObject.FindWithTag("MainCamera").GetComponent<GameMasterScript>();

        Hp = StartHealth;

        IsPlayer = gameObject.name == "Player";

        HealthText = GameObject.FindWithTag("HealthText").GetComponent<Text>(); 

        SetPlayerHealth();
    }

    public void TakeDamage(float damage, string bulletOwner)
    {
        if (bulletOwner == "Player")//player shot bullet
        {
            GameMasterScript.PlayerShotsHit++;
        }

        if (bulletOwner == "Enemy")//enemy shot bullet
        {
            GameMasterScript.PlayerHitsTaken++;
        }

        SetPlayerHealth();

        if (Hp > 0f && Hp < damage)
        {
            Hp = 0f;
        }

        if (Hp > 0f)
        {
            Hp -= damage;
        }

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
            GameOver.Setup(GameMaster.Score);
        }
        else
        {
            GameMaster.AddScore(10);
            Destroy(gameObject);
        }

    }
}
