using System;
using System.Collections;
using UnityEngine;

public class BasicMovementBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float rotationSpeed;
    public float jumpForce;
    private bool canJump;

    private Vector3 resetTrans;
    
    public float particleCountDown;
    
    public Event_System.Event showAllParticles;
    
    public Event_System.Event hideAllParticles;

    public Event_System.Event decrementText;

    private Animator animator;

    private bool countDownPassed;
    
    private bool canShowParticles;

    private int particleUses;

    private float inputTimer;

    private bool isColliding;

    // Start is called before the first frame update
    void Awake()
    {
        HideParticles();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -20, 0);
        resetTrans = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        particleCountDown = 0;
        canShowParticles = true;
        countDownPassed = true;

        particleUses = 5;

        animator = GetComponent<Animator>();

        inputTimer = 0;
        
        HideParticles();

    }

    void Update()
    {
        inputTimer += Time.deltaTime;
        
        if (!countDownPassed) //if particles is still on cool down (if its false)
        {
            if (particleCountDown >= 2) //if the cooldown if over with
            {
                //reset cooldown
                countDownPassed = true;
                canShowParticles = true;
                particleCountDown = 0;
                
                HideParticles();
            }

            //only increments if its on cooldown
            particleCountDown += Time.deltaTime;
        }
        
        if (canShowParticles)
        {
            Debug.Log("Can show particles:: " + canShowParticles);
            if (particleUses > 0)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    canShowParticles = false;
                    Debug.Log("Click Recieved");
                    particleUses -= 1;
                    ShowParticles();
                    decrementText.Raise();
                }
            }
        }


        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (isColliding)
            {
                animator.SetTrigger("walk");
            }
            transform.position += transform.forward * speed * Time.deltaTime;
            inputTimer = 0;
        }

        if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (isColliding)
            {
                animator.SetTrigger("walk");
            }
            transform.position += -transform.forward * speed * Time.deltaTime;
            inputTimer = 0;
        }

        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (isColliding)
            {
                animator.SetTrigger("walk");
            }
            transform.Rotate(-Vector3.up);
            inputTimer = 0;
        }

        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (isColliding)
            {
                animator.SetTrigger("walk");
            }
            transform.Rotate(Vector3.up);
            inputTimer = 0;
        }

        if (Input.GetKey(KeyCode.Space))//jump
        {

            StartCoroutine("Jump");
        }

        if (inputTimer > 0)
        {
            animator.SetBool("idle bool", true);
        }
        else
        {
            animator.SetBool("idle bool", false);
        }
    }

    private void ShowParticles()
    {
        if (countDownPassed)
        {
            showAllParticles.Raise();
            countDownPassed = false;
        }
        
 
    }

    private void HideParticles()
    {
        hideAllParticles.Raise();
    }


    private void OnCollisionEnter(Collision other)
    {
        isColliding = true;
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            animator.SetTrigger("idle");
            canJump = true;
        }

        if (other.gameObject.CompareTag("death"))
        {
            transform.position = resetTrans;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        isColliding = false;
    }

    IEnumerator Jump()
    {
        if (canJump)
        {
            inputTimer = 0;
            animator.SetTrigger("jump");
            rb.AddForce(-Physics.gravity.normalized * jumpForce);
            canJump = false;
            yield return jumpForce;
        }
    }
}



























//TODO:: GOTTA IMPLEMENT A LIST OF HOTSPOT SOURCE, THEN FIND A WAY TO DISPLAY A DIRECTION TO THEM
