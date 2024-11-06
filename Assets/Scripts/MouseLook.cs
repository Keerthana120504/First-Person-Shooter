using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Private
    float mouseX; 
    float mouseY;
    float xRotate = 0f;

    // Public
    public Transform playerBody;
    
    public float mouseSentivity = 500f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSentivity * Time.deltaTime; // Getting x axis Input from Mouse
        mouseY = Input.GetAxis("Mouse Y") * mouseSentivity * Time.deltaTime; // Getting y axis Input from Mouse

        xRotate -= mouseY; // Assigning y Mouse value to xRotation
        xRotate = Mathf.Clamp(xRotate, -90f, 90f); // Constraining the up and down value by -90 degree and 90 degree 
        transform.localRotation = Quaternion.Euler(xRotate, 0f, 0f); // Rotation by the Quarternion

        playerBody.Rotate(Vector3.up * mouseX); // To Rotate the Player Body in only y axis as per the Mouse going



    }
}
