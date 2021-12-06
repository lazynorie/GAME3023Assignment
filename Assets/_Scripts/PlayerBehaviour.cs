using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerBehaviour : MonoBehaviour
{

    public bool isInGrass;
    [SerializeField] private float moveSpeed = 1.0f;

    private Rigidbody2D rigidbody;

    private Animator animator;
    
    //Random Encounter
    [Header("Random Encounter")]
    public LayerMask grassLayer;
    [SerializeField]
    private bool isMoving;
    [SerializeField] 
    [Range(0,100)]
    private int encounterchance;

    private bool inEncouter;

    public UnityEvent OnEnterEncounterEvent;
    public UnityEvent OnExitBattleEvent;
    
    
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inEncouter = false;
        isInGrass = false;
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
        if (!inEncouter)
        {
            if (Physics2D.OverlapCircle(transform.position,0.01f,grassLayer) != null)
            {
                if (Random.Range(1, 101) <= encounterchance)
                {
                    Debug.Log("You've enter a randome encounter!");
                    inEncouter = true;
                    //Enter Random Encounter
                    StartCoroutine(BattleEntrySequence());

                }
            }
        }
    }
    
    IEnumerator BattleEntrySequence()
    {
        //OnEnterEncounterEvent.Invoke();
        yield return new WaitForSeconds(2.0f);
        //inEncouter = false;
        SceneManager.LoadScene("BattleScene");
    }

    private void Move()
    {
      
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
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
        if (!inEncouter)
        {
            rigidbody.velocity = new Vector2(inputX * moveSpeed, inputY * moveSpeed);
        }
       
    }

    public void OnExitButtonPressed()
    {
        //BGM event
        OnExitBattleEvent.Invoke();
        //Switch Scene
        SceneManager.LoadScene("TestScene");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.CompareTag("LongGrass");
        Debug.Log("In Grass");
        isInGrass = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        other.gameObject.CompareTag("LongGrass");
        Debug.Log("Out of Grass");
        isInGrass = false;
    }
}
