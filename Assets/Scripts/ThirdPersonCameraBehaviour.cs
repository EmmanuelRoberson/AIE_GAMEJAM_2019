using UnityEngine;

//This is a camera script made by Haravin (Daniel Valcour).
//This script is public domain, but credit is appreciated!

[RequireComponent(typeof(Camera))]
public class ThirdPersonCameraBehaviour : MonoBehaviour
{

    public GameObject objectToFollow;
    public GameObject viewReferenceObject;

    public float mouseSensitivity;
    public bool invertMouse;
    public bool autoLockCursor;
    
    public float turnSpeed = 4.0f;

    private Vector3 offset;

    private Camera cam;

    public float cameraDistance;

    void Awake()
    {
        cam = this.gameObject.GetComponent<Camera>();
        this.gameObject.name = "SpectatorCamera";
        Cursor.lockState = (autoLockCursor) ? CursorLockMode.Locked : CursorLockMode.None;
        
        offset = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y + 2.0f, objectToFollow.transform.position.z + -3.0f);
    }

    void Update()
    {

        this.gameObject.transform.Rotate(Input.GetAxis("Mouse Y") * mouseSensitivity * ((invertMouse) ? 1 : -1), Input.GetAxis("Mouse X") * mouseSensitivity * ((invertMouse) ? -1 : 1), 0);
        this.gameObject.transform.localEulerAngles = new Vector3(this.gameObject.transform.localEulerAngles.x, this.gameObject.transform.localEulerAngles.y, 0);
        

        if (Cursor.lockState == CursorLockMode.None && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (Cursor.lockState == CursorLockMode.Locked && Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
        
        offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = objectToFollow.transform.position + offset/4;
        transform.position += Vector3.up*2;
        transform.LookAt(objectToFollow.transform.position);
    }
}