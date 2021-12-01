using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;

    private Rigidbody2D rigidbody;

    private Animator animator;
    
    //Random Encounter
    public LayerMask grassLayer;
    [SerializeField]
    private bool isMoving;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        if (isMoving)
        {
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                CheckEncounter();
            }
        }
    }

    private void CheckEncounter()
    {
        if (Physics2D.OverlapCircle(transform.position,0.001f,grassLayer) != null)
        {
            if (Random.Range(1, 101) <= 10)
            {
                Debug.Log("You've enter a randome encounter!");
                
                //Enter Random Encounter
                //SceneManager.LoadScene("Encounter");
            }
        }
        
        
    }

    private void Move()
    {
       
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        rigidbody.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);

        animator.SetFloat("Horizontal", rigidbody.velocity.x);
        animator.SetFloat("Vertical", rigidbody.velocity.y);
        animator.SetFloat("Speed", rigidbody.velocity.sqrMagnitude);
        if (rigidbody.velocity.sqrMagnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
       
       
    }

    
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LongGrass"))
        {
           
            Debug.Log("hello");
        }
    }*/
    

}
