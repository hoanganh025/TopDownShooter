using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float maxHealth;
    public float currentHealth { get; private set; }
    private bool isDead;

    //[SerializeField] public UnityEvent onDeath;
    [SerializeField] private UnityEvent onDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    private void OnEnable()
    {
        onDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        onDeath.RemoveListener(Death);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    private void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);

        if(currentHealth <= 0)
        {
            onDeath.Invoke();
            isDead = true;
        }
    }

    public void Death()
    {
        if(gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
