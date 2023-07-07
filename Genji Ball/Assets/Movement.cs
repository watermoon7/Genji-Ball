using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform transform;
    public float Speed;
    public float jumpHeight;
    public bool onFloor = false;
    public bool doubleUsed = false;
    public float time = 0;
    public GameObject thing1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform thing = thing1.transform;
        //transform.rotation = thing.rotation;
        if (transform.position.y == 2.5f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            onFloor = true;
            doubleUsed = false;
        }
        else 
        {
            rb.AddForce(0, -150 * Time.deltaTime, 0, ForceMode.VelocityChange);
            onFloor = false;
        }

        float moveX = Input.GetAxis("Vertical") * Speed;
        float moveY = Input.GetAxis("Horizontal") * Speed;

        Vector3 forward = thing.transform.forward;
        Vector3 right = thing.transform.right;

        forward.y = 0;
        right.y = 0;

        forward = forward.normalized;
        forward = forward.normalized;

        Vector3 forwardRelativeInput = moveX * forward;
        Vector3 rightRelativeInput = moveY * right;

        Vector3 cameraRelativeMovement = forwardRelativeInput + rightRelativeInput;
        cameraRelativeMovement.y = rb.velocity.y;

        rb.velocity = cameraRelativeMovement;

        if (Input.GetKey("space") & onFloor == true)
        {
            rb.AddForce(0, jumpHeight, 0, ForceMode.VelocityChange);
            time = 0.2f;
        }
        if (Input.GetKey("space") & doubleUsed == false & time < 0)
        {
            rb.AddForce(0, jumpHeight, 0, ForceMode.VelocityChange);
            doubleUsed = true;
        }
        if (time > -0.1f)
        {
            time -= (1 * Time.deltaTime);
        }
    }
}
