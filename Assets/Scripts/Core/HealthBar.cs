using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private Image currentHealthBar;
    
    void Start()
    {
        currentHealthBar.fillAmount = health.currentHealth / 100;
    }

    void Update()
    {
        currentHealthBar.fillAmount = health.currentHealth / 100;
    }
}
