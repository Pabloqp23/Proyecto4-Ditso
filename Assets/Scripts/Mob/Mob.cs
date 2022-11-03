using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float speed;
    public float range;
    public float visionRange;
    public CharacterController controller;
    public Transform player;
    public AnimationClip idle;
    public AnimationClip attack;
    public AnimationClip move;
    public double impactTime;
    public float damage;
    public bool impacted;
    private Fighter opponent;

    public AnimationClip die;
    private EnemyHealth enemyHealth;
    public Transform enemy;
    public float animLenght;
    public float animDieLenght;
    public AudioClip growl;
    AudioSource audiosSource;

    // Start is called before the first frame update
    void Start()
    {
        audiosSource = GetComponent<AudioSource>();
        opponent = player.GetComponent<Fighter>();
        enemyHealth = enemy.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyHealth.IsDead())
        {

            if (player != null)
            {
                if (!inRange())
                { 

                   
                    if (Vector3.Distance(transform.position, player.position) < visionRange)
                    {
                    
                        chase();
                
                    } 
                    else
                    {  
                   
                        GetComponent<Animation>().Play(idle.name);
                    }

                    if (Vector3.Distance(transform.position, player.position) >= visionRange) 
                    {
                     PlayAudio();
                    }
                    
                    
                }
                else
                {
                      
                    if (GetComponent<Animation>()[attack.name].time > 0.90 * animLenght)
                    {
                        impacted = false;
                    }
                    GetComponent<Animation>().Play(attack.name);
                    inAttack();

                }

            }
            else
            {
                GetComponent<Animation>().Play(idle.name);
            }
        }
        else
        {
            GetComponent<Animation>().Play(die.name);
            if (GetComponent<Animation>()[die.name].time > 0.90 * animDieLenght)
            {
                Destroy(gameObject);
            }
        }
    }
    void inAttack()
    {
        if (GetComponent<Animation>()[attack.name].time > GetComponent<Animation>()[attack.name].time * impactTime && !impacted && GetComponent<Animation>()[attack.name].time < 0.90 * animLenght)
        {
            opponent.DecreaseHealth(damage);
            impacted = true;
        }
    }
    public bool inRange()
    {

        if (Vector3.Distance(transform.position, player.position) < range)
        {
            
            return true;
            //GetComponent<Animation>().CrossFade(attack.name);
        }
        else
        {
            return false;

        }
    }
    void chase()
    {
                    
        transform.LookAt(player.position);
        controller.SimpleMove(transform.forward * speed);
        GetComponent<Animation>().CrossFade(move.name);
        

    }
     void PlayAudio()
    {
        audiosSource.clip = growl;
        audiosSource.Play();
    }

}
