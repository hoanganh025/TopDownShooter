using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Start")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer bodySprites;
    private Rigidbody2D rb;

    [Header("Roll")]
    [SerializeField] private float rollTime;
    [SerializeField] private float rollCooldown;
    [SerializeField] private float rollSpeed = 8f;
    private bool canRoll = true;
    private bool isRoll;

    [Header("Move")]
    [SerializeField] private float moveSpeedStart = 5f;
    private float inputX, inputY;
    private Vector2 movement;
    private float moveSpeed;


    private float rollCounter = 10;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = moveSpeedStart;
    }

    private void Update()
    {
        ProcessInput();
        StartCoroutine(PlayerRoll());
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInput()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        //movement = new Vector2(inputX, inputY).normalized;

        movement = new Vector2(inputX, inputY);

        if (movement.magnitude > 1f)
        {
            movement = movement.normalized;
        }

        //flip sprites with mouse in weapon.cs

        //flip sprites with move
/*        if(movement.x != 0)
        {
            if(movement.x > 0)
            {
                bodySprites.transform.localScale = new Vector3(3, 3, 3);
            }
            else if(movement.x < 0)
            {
                bodySprites.transform.localScale = new Vector3(-3, 3, 3);
            }
        }*/

        //set animation
        animator.SetBool("Walk", movement.x != 0 || movement.y !=0);
    }

    private void Move()
    {
        rb.velocity = movement * moveSpeed;
    }

    /*private void PlayerRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canRoll)
        {
            canRoll = false;
            //moveSpeed += rollSpeed;
            //rb.velocity = movement * (moveSpeed + rollSpeed);
            moveSpeed = rollSpeed;
            rollCounter = 0;
            isRoll = true;
            Debug.Log("keydown space");
        }

        rollCounter += Time.deltaTime;

        if(rollCounter > rollCooldown)
        {
            canRoll = true;
            //moveSpeed -= rollSpeed;
            moveSpeed = 5f; 
        }
    }*/

    private IEnumerator PlayerRoll()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            canRoll = false;
            isRoll = true;
            moveSpeed = rollSpeed;
            animator.SetBool("Roll", isRoll);
            yield return new WaitForSeconds(rollTime);
            isRoll = false;
            animator.SetBool("Roll", isRoll);
            yield return new WaitForSeconds(rollCooldown);
            moveSpeed = moveSpeedStart;
            canRoll = true;
        }
    }
}
