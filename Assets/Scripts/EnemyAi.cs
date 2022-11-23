using System.Collections;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private Transform player;
    private float distToPlayer;
    private bool canAttack;
    private GameMasterScript GameMaster;


    public Weapon weapon;
    public float stoppingDistance, range;
    public static float attackCooldown, speed = 5f, retreatDistance = 3f;
    public Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        GameMaster = GameObject.FindWithTag("MainCamera").GetComponent<GameMasterScript>();

        canAttack = true;
    }

    private void Update()
    {
        FacePlayer();

        distToPlayer = Vector2.Distance(transform.position, player.position);
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * speed * Time.deltaTime);
        }

        if (distToPlayer <= range)
        {
            if (canAttack == true)
            {
                StartCoroutine(Attack());
            }
        }
    }

    /// <summary>
    /// Rotate enemy so barrel face the player
    /// </summary>
    public void FacePlayer()
    {
        Vector2 aimDirection = (Vector2)player.position - rb.position;

        ///capturing the degrees to rotate the weapon to face the mouse popinter
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

        ///rotating the weapon to face the mouse position
        rb.rotation = aimAngle;
    }

    IEnumerator Attack()
    {
        canAttack = false;

        yield return new WaitForSeconds(attackCooldown);
        weapon.Fire();
        
        canAttack = true;
    }

    void Die()
    {
        GameMaster.EnemyRemoved();
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Die();
    }
}
