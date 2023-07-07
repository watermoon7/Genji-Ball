using UnityEngine;

public class Camera : MonoBehaviour
{
    public float xSensitivity = 2f;
    public float ySensitivity = 2f;
    public Transform playerOrientation;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * ySensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;
        //yRotation = Mathf.Clamp(-, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerOrientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
