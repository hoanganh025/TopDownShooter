using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private GameObject bodyEnemy;
    private Rigidbody2D rb;
    private float distance;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;

        if(rb.velocity.x >= 0.01f)
        {
            bodyEnemy.transform.localScale = new Vector3(3, 3, 3);
        }
        if(rb.velocity.x <= -0.01f)
        {
            bodyEnemy.transform.localScale = new Vector3(-3, 3, 3);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * speed;
    }
}
