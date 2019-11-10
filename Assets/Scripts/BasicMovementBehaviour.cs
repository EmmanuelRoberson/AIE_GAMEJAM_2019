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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -20, 0);
        resetTrans = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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

        if (other.gameObject.CompareTag("death"))
        {
            transform.position = resetTrans;
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
