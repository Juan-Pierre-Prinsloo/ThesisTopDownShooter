using System.Collections;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private Transform player;
    private float distToPlayer;
    private bool canAttack;

    public Weapon weapon;
    public float range, attackCooldown;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position,player.position);

        if (distToPlayer <= range)//Combat logic
        {
            //move towards player slowly
            rb.AddForce(this.transform.up * 0.25f, ForceMode2D.Force);
            
            FacePlayer();

            if (canAttack == true)
            {
                StartCoroutine(Attack());
            }
        }
        else//non-combat logic
        {
            //move towards player quickly until in combat range
            rb.AddForce(this.transform.up * 0.5f, ForceMode2D.Force);
        }
    }

    /// <summary>
    /// Rotate enemy so barrel face the player
    /// </summary>
    void FacePlayer()
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
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Die();
    }
}
