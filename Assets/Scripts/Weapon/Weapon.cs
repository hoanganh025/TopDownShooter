using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer bodySprites;

    [Header("Fire")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject[] bulletInList;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private Transform firePos;
    [SerializeField] private float timeBtwFire = 0.2f;
    [SerializeField] private float bulletForce;
    private float timeBtwFireCounter = 0;


    void Update()
    {
        RotateGun();
        RotatePlayer();

        timeBtwFireCounter -= Time.deltaTime;
        if(Input.GetMouseButton(0) && timeBtwFireCounter < 0)
        {
            FireBullet();
        }
    }

    private void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotationWeapon = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotationWeapon;

        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }

    private void RotatePlayer()
    {
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            bodySprites.transform.localScale = new Vector3(-3, 3, 3);
            bodySprites.sortingOrder = 2;
        }
        else
        {
            bodySprites.transform.localScale = new Vector3(3, 3, 3);
            bodySprites.sortingOrder = 0;
        }
    }

    private void FireBullet()
    {
        timeBtwFireCounter = timeBtwFire;
        GameObject bulletTmp = Instantiate(bullet, firePos.position, Quaternion.identity);
        GameObject muzzleTmp = Instantiate(muzzle, firePos.position, transform.rotation, transform);

        Rigidbody2D rbBullet = bulletTmp.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);

    }

}
