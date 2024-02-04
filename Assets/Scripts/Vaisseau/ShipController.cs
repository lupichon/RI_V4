using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ShipController : MonoBehaviour
{
    // Voici les 3 elements avec lesquels on interagit, un joystick, un knob et un slider
    public XRJoystick navJoystick;
    public XRKnob sideMovementWheel;
    public XRSlider upMovementSlider;

    // Vitesses de translation d'avant en arriere et sur le cote
    private float forwardSpeed;
    private float sideSpeed;

    // Orientation du vaisseau
    private Quaternion orientation;

    void Start()
    {
        // Initialisation des vitesses et de l'orientation
        forwardSpeed = 30;
        sideSpeed = 50;
        orientation.eulerAngles = new Vector3(0, -90, 0);
    }

    void Update()
    {
        // Recuperation des valeurs des differents elements d'interaction et translation/rotation en fonction
        float upwardVelocity = forwardSpeed * navJoystick.value.x;
        float forwardVelocity = forwardSpeed * navJoystick.value.y;
        float upVelocity = forwardSpeed * (upMovementSlider.value - 0.5f);
        float wheelValue = sideMovementWheel.value * sideSpeed;

        orientation.eulerAngles = new Vector3(0, -90 + wheelValue, 0);

        transform.position += -upwardVelocity*transform.forward * Time.deltaTime;
        transform.position += -forwardVelocity * transform.right * Time.deltaTime;
        transform.position += -upVelocity * transform.up * Time.deltaTime;
        
        transform.localRotation = orientation;
    }
}
