using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;

    private Rigidbody2D rigidbody;

    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        rigidbody.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
        
        animator.SetFloat("Horizontal", rigidbody.velocity.x);
        animator.SetFloat("Vertical", rigidbody.velocity.y);
        animator.SetFloat("Speed",rigidbody.velocity.sqrMagnitude);

    }
}
