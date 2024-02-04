using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ShipController : MonoBehaviour
{
    public XRJoystick navJoystick;
    public XRKnob sideMovementWheel;
    public XRSlider upMovementSlider;

    private float forwardSpeed;
    private float sideSpeed;

    private Quaternion orientation;
    //private float direction;
    // Start is called before the first frame update
    void Start()
    {
        forwardSpeed = 30;
        sideSpeed = 50;
        //direction = -90;
        orientation.eulerAngles = new Vector3(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float upwardVelocity = forwardSpeed * navJoystick.value.x;
        float forwardVelocity = forwardSpeed * navJoystick.value.y;
        float upVelocity = forwardSpeed * (upMovementSlider.value - 0.5f);
        float wheelValue = sideMovementWheel.value * sideSpeed;
        orientation.eulerAngles = new Vector3(0, -90 + wheelValue, 0);
       // Vector3 velocity = new Vector3(upwardVelocity, upVelocity, -forwardVelocity);
        transform.position += -upwardVelocity*transform.forward * Time.deltaTime;
        transform.position += -forwardVelocity * transform.right * Time.deltaTime;
        transform.position += -upVelocity * transform.up * Time.deltaTime;

       
        transform.localRotation = orientation;
    }
}
