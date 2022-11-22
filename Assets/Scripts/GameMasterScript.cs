using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameMasterScript : MonoBehaviour
{
    public Texture2D Cursor;
    public int Score = 0;
    public GameObject Enemy;
    public int MaxEnemyCount = 1;
    public float SpawnCooldown = 3f;
    public bool gameOver = false;

    private Text ScoreText;
    private GameObject Player;
    private int EnemyCount = 0;
    private bool CanSpawnEnemy;
    private string Difficulty;

    void Start()
    {
        UnityEngine.Cursor.SetCursor(Cursor, new Vector2(16f, 16f), CursorMode.ForceSoftware);

        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();

        Player = GameObject.FindWithTag("Player");

        CanSpawnEnemy = true;

        Difficulty = MainMenu.Difficulty;

        SetDificulty();
    }
    
    void FixedUpdate()
    {
        if (gameOver)
        {
            return;
        }

        if (CanSpawnEnemy)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    public void AddScore(int scoreIncrease)
    {
        Score += scoreIncrease;

        ScoreText.text = $"Score : {Score}";
    }

    public IEnumerator SpawnEnemy()
    {
        CanSpawnEnemy = false;

        yield return new WaitForSeconds(SpawnCooldown);

        if (EnemyCount < MaxEnemyCount && !gameOver)
        {
            //var randomSpawnLocation = new Vector2(Random.Range(-10, 11), Random.Range(-10, 11));
            var randomSpawnLocation = (Vector2)Camera.main.ViewportToWorldPoint(new Vector2(Random.value,Random.value));

            Instantiate(Enemy, randomSpawnLocation, Quaternion.identity);

            EnemyCount++;
        }

        CanSpawnEnemy = true;
    }

    public void EnemyRemoved()
    {
        if (EnemyCount > 0)
        {
            EnemyCount--;
        }
    }

    public void GameOver()
    {
        gameOver = true;

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemies.ToList().ForEach(e => Destroy(e));

        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Player.GetComponent<PlayerController>().enabled = false;
    }

    public void SetDificulty()
    {
        switch (Difficulty)
        {
            case "Easy":

                MaxEnemyCount = 1;
                SpawnCooldown = 3f;
                Player.GetComponent<HealthScript>().StartHealth = 15f;

                EnemyAi.attackCooldown = 1.5f;
                EnemyAi.speed = 10;
                EnemyAi.retreatDistance = 3;

                break;

            case "Normal":

                MaxEnemyCount = 2;
                SpawnCooldown = 2.4f;
                Player.GetComponent<HealthScript>().StartHealth = 10f;

                EnemyAi.attackCooldown = 0.9f;
                EnemyAi.speed = 15;
                EnemyAi.retreatDistance = 4;

                break;

            case "Hard":

                MaxEnemyCount = 3;
                SpawnCooldown = 1.8f;
                Player.GetComponent<HealthScript>().StartHealth = 5f;

                EnemyAi.attackCooldown = 0.6f;
                EnemyAi.speed = 20;
                EnemyAi.retreatDistance = 4;

                break;

            default:
                break;
        }
    }
}
