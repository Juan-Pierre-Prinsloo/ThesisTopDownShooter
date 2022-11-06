using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    ///this is the rigid body component of the player
    public Rigidbody2D rb;
    ///this is the weapon component of the player
    public Weapon weapon;

    private Vector2 moveDirection;
    private Vector2 mousePosition;

    
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        ///if the player left clicks fire a bullet
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //can replace camera.main with a camera component if a spesific camera is required
    }

    private void FixedUpdate()
    {
        ///move the player based on inputs captured during update
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        Vector2 aimDirection = mousePosition - rb.position;

        ///capturing the degrees to rotate the weapon to face the mouse popinter
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

        ///rotating the weapon to face the mouse position
        rb.rotation = aimAngle;
    }
}
