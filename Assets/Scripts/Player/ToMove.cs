using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMove : MonoBehaviour
{


    public AnimationClip run;
    public float moveSpeed;
    public AnimationClip idle;
    public AnimationClip walkBack;
    public float gravity;
    public static bool IsAttacking;
    private Vector3 moveDirection;
    private Fighter playerHealth;
    public Transform player;

    public AnimationClip die;
    public float animRunLenght;
    public float animWalkBackLenght;
    public float animDieLenght;
    public AudioClip steps;
    AudioSource audiosSource;

    // Start is called before the first frame update
    void Start()
    {
        audiosSource = GetComponent<AudioSource>();
        moveSpeed = 3f;
        //gravity = 100f;
        playerHealth = player.GetComponent<Fighter>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController characterController = GetComponent<CharacterController>();
        if (!playerHealth.IsDead())
        {


            if (!IsAttacking)
            {
            
                
                moveDirection = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= moveSpeed;
                
//Si el jugador usa la tecla w o arriba 
                if (Input.GetAxis("Vertical") != 0)
                {

                    GetComponent<Animation>().CrossFade(run.name);
                    if (GetComponent<Animation>()[run.name].time > 0.70 * animRunLenght)
                    {
                   audiosSource.clip = steps;
                   audiosSource.Play();
                    }
        
                }
//Si el jugador usa la tecla s o abajo
                if (Input.GetAxis("Vertical") < 0)
                {
                    GetComponent<Animation>().Play(walkBack.name);
                     if (GetComponent<Animation>()[walkBack.name].time < 0.50 * animWalkBackLenght)
                    {
                   audiosSource.clip = steps;
                    audiosSource.Play();
                    }
                }
                //Si no pulsa ninguna tecla
                if (Input.GetAxis("Vertical") == 0)
                {
                    GetComponent<Animation>().CrossFade(idle.name);
                }
                moveDirection.y -= gravity * Time.deltaTime;
                characterController.Move(moveDirection * Time.deltaTime);
                //Rotate Player
                transform.Rotate(0f, moveSpeed * Input.GetAxis("Horizontal"), 0f);
            }
        }
        else
        {
            GetComponent<Animation>().Play(die.name);
            if (GetComponent<Animation>()[die.name].time > 0.99 * animDieLenght)
            {
                Destroy(gameObject);
            }
        }

    }

}
