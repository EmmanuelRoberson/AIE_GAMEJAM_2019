using System.Collections;
using UnityEngine;

public class BasicMovementBehaviour : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float rotationSpeed;
    public float jumpForce;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (!canJump)
        {
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.LeftShift))
            {
                transform.position += -transform.forward * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(-Vector3.up);
            }

            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift))
            {
                transform.Rotate(Vector3.up);
            }
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine("Jump");
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Debug.Log("Touching ground");
            canJump = true;
        }
    }
    
    

    IEnumerator Jump()
    {
        if (canJump)
        {
            rb.AddForce(-Physics.gravity.normalized * jumpForce);
            canJump = false;
            yield return jumpForce;
        }
    }
    
    
}



























//TODO:: GOTTA IMPLEMENT A LIST OF HOTSPOT SOURCE, THEN FIND A WAY TO DISPLAY A DIRECTION TO THEM
