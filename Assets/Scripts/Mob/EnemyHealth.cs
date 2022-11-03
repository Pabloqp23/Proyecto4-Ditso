using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public GameObject healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DecreaseHealth(float damage)
    {

        currentHealth = currentHealth - damage;
        float calculateHealth = currentHealth / maxHealth;
        SetHealthBar(calculateHealth);
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

    }

    public void SetHealthBar(float health)

    {

        healthBar.transform.localScale = new Vector3(Mathf.Clamp(health, 0f, 1f), healthBar.transform.localScale.y, transform.localScale.z);
    }
    public bool IsDead()
    {
        if (currentHealth<=0)
        {
            return true;

        }
        else
        {
            return false;
        }
    }
}
