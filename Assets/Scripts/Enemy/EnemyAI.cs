using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private bool isShootable = false;
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private GameObject targetBullet;
    [SerializeField] private Transform firePos;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float timeBtwFire;
    private float timeBtwFireCounter;
    
    void Start()
    {
        
    }

    void Update()
    {
        timeBtwFireCounter -= Time.deltaTime;
        if(timeBtwFireCounter < 0 && isShootable)
        {
            EnemyFire();
        }
    }

    private void EnemyFire()
    {
        timeBtwFireCounter = timeBtwFire;
        GameObject bulletTmp = Instantiate(enemyBullet, firePos.position, Quaternion.identity);

        Rigidbody2D rbTmp = bulletTmp.GetComponent<Rigidbody2D>();
        Vector2 direction = targetBullet.transform.position - this.transform.position;

        rbTmp.AddForce(direction * bulletSpeed, ForceMode2D.Impulse);
    }
}
