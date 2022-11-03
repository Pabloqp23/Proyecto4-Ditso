using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    #region Singleton
    public static Fighter instance;
    void Awake()
    {
        instance= this;
    }
    #endregion
   
    public double ImpactTime;
    public AnimationClip attack;
    public GameObject AttackEffect;
    public GameObject enemy;
    
    public float maxHealth = 100;
    public float currentHealth;
    public GameObject healthBar;
    public float damage;
    public bool impacted;
    public float range;
    public float animLenght;
    private float AttackDirection;
    public AudioClip hit;
    AudioSource audiosSource;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        audiosSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy = FindClosestEnemy();
       

        if (Input.GetKey(KeyCode.Space))
        {
           
            GetComponent<Animation>().Play(attack.name);
            ToMove.IsAttacking = true;
           
            /* if (enemy!= null)
             {
                 transform.LookAt(enemy.transform.position);

             }*/
          if (!inRange() && !GetComponent<Animation>().IsPlaying(attack.name))
            {
                ToMove.IsAttacking = false;
            }
        }
        
         if (GetComponent<Animation>()[attack.name].time > 0.90 * animLenght)
        {
            ToMove.IsAttacking = false;
            impacted = false;
        }
        IsImpacted();
    }
    void IsImpacted()
    {
        if (enemy != null && GetComponent<Animation>().IsPlaying(attack.name) && !impacted && inRange())
        {
            if ((GetComponent<Animation>()[attack.name].time) > ImpactTime * (GetComponent<Animation>()[attack.name].time) && GetComponent<Animation>()[attack.name].time < 0.90 * animLenght)
            {
                Instantiate(AttackEffect,new Vector3(enemy.transform.position.x,enemy.transform.position.y,enemy.transform.position.z), enemy.transform.rotation);
                 audiosSource.clip = hit;
                    audiosSource.Play();
                enemy.GetComponent<EnemyHealth>().DecreaseHealth(damage);
                impacted = true;
            }
           
            
        }
    }
     public GameObject FindClosestEnemy()
    {
        GameObject[] targets;
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject target in targets)
        {
            Vector3 diff = target.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = target;
                distance = curDistance;
            }
        }
        return closest;
    }
    bool inRange()
    {
Vector3 direction=(enemy.transform.position-transform.position).normalized;
AttackDirection= Vector3.Dot(direction,transform.forward);

        if (Vector3.Distance(enemy.transform.position, transform.position) <= range  && AttackDirection > 0.90 && AttackDirection < 0.99)
        {
            
            return true;
            //GetComponent<Animation>().CrossFade(attack.name);
        }
        else
        {
            Debug.Log(AttackDirection);
            return false;
        }
    }
    public void DecreaseHealth(float damage)
    {

        currentHealth -= damage;
       float calculateHealth = currentHealth / maxHealth;
        SetHealthBar(calculateHealth);
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        

    }
    public void IncrementHealth(float healthUp)
    {

     if (currentHealth < maxHealth)
        {
        currentHealth += healthUp;
        float calculateHealth = currentHealth / maxHealth;
          SetHealthBar(calculateHealth); 
        }
        /* else
        {

        calculateHealth=maxHealth;
        SetHealthBar(calculateHealth);
        }*/
        

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

    /*void OnTriggerStay(Collider collider)

    {
        if (collider.name == "Enemy")
        {
            DecreaseHealth();
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }

        }
    }*/
}


