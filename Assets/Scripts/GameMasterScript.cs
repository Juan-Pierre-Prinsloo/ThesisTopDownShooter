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

    void Start()
    {
        UnityEngine.Cursor.SetCursor(Cursor, new Vector2(16f, 16f), CursorMode.ForceSoftware);

        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();

        Player = GameObject.FindWithTag("Player");

        CanSpawnEnemy = true;
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

        Debug.Log(enemies.Count());

        enemies.ToList().ForEach(e => Destroy(e));

        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Player.GetComponent<PlayerController>().enabled = false;
    }
}
