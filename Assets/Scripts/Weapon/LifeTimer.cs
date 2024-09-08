using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimer : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    //private float lifeTimerCounter = 0 ;

    void Update()
    {
        Destroy(this.gameObject, lifeTime);
    }
}
