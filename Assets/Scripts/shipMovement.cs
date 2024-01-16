using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class followLevier : MonoBehaviour
{
    private GameObject RotLevier;
    private GameObject RotParent;
    private Transform _tfRotLevier;

    public bool contact;

    private GameObject TranslationLevier;
    private Transform _tfTranslationLevier;
    
    private Transform _tfShip;
    private Rigidbody _rbShip;

    private float rotationSpeed = 0.1f;
    private float movementSpeed = 1.0f;
    private float totalRotationUp;
    private float totalRotationRoll;
    Vector3 rot = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        RotParent = GameObject.Find("RotationLever");
        RotLevier = GameObject.FindWithTag("RotationLever");
        _tfRotLevier = RotLevier.GetComponent<Transform>();
        TranslationLevier = GameObject.FindWithTag("TranslationLever");
        _tfTranslationLevier = TranslationLevier.GetComponent<Transform>();
        _tfShip = GetComponent<Transform>();
        _rbShip = GetComponent<Rigidbody>();

        //  _grab = GameObject.FindWithTag("main").GetComponent<handInputsListener>()._gripValue;

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 rotationUp = Vector3.right;
        if(totalRotationUp < 0.75 || Mathf.Sin(_tfRotLevier.eulerAngles.x- _tfShip.eulerAngles.x * Mathf.PI / 180)<0)
        {
            totalRotationUp += Mathf.Log(Mathf.Abs(rotationSpeed * Mathf.Sin((_tfRotLevier.eulerAngles.x-_tfShip.eulerAngles.x) * Mathf.PI / 180) * Time.deltaTime +1f)); 
        }
        else if(totalRotationUp > -0.75 || Mathf.Sin(_tfRotLevier.eulerAngles.x - _tfShip.eulerAngles.x * Mathf.PI / 180) > 0)
        {
            totalRotationUp -= Mathf.Log(Mathf.Abs(rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.x - _tfShip.eulerAngles.x * Mathf.PI / 180) * Time.deltaTime + 1f));
        }

        Vector3 rotationRoll = Vector3.forward;
        if (totalRotationRoll < 0.75 || Mathf.Sin((_tfRotLevier.eulerAngles.x - _tfShip.eulerAngles.x) * Mathf.PI / 180) < 0)
        {
            totalRotationRoll += Mathf.Log(Mathf.Abs(rotationSpeed * Mathf.Sin((_tfRotLevier.eulerAngles.x - _tfShip.eulerAngles.z) * Mathf.PI / 180) * Time.deltaTime + 1f));
        }
        else if (totalRotationRoll > -0.75 || Mathf.Sin((_tfRotLevier.eulerAngles.x - _tfShip.eulerAngles.z) * Mathf.PI / 180) > 0)
        {
            totalRotationRoll -= Mathf.Log(Mathf.Abs(rotationSpeed * Mathf.Sin((_tfRotLevier.eulerAngles.z - _tfShip.eulerAngles.z) * Mathf.PI / 180) * Time.deltaTime + 1f));
        }


        _tfShip.RotateAround(_tfShip.position, rotationUp, totalRotationUp);
        _tfShip.RotateAround(_tfShip.position, rotationRoll, totalRotationRoll);

       // Debug.Log("AAAAAAAAAA : " + totalRotation);
        /*
        rot.x += rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.x) * Time.deltaTime;
        rot.z += rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.z) * Time.deltaTime;
        
        _tfShip.Rotate(rot.x, rot.y, rot.z, Space.Self);
        */

        _tfShip.position = _tfShip.position + new Vector3(-Mathf.Sin(_tfTranslationLevier.eulerAngles.z * Mathf.PI / 180) * movementSpeed * Time.deltaTime, 0, Mathf.Sin(_tfTranslationLevier.eulerAngles.x * Mathf.PI / 180) * movementSpeed * Time.deltaTime);
       // Debug.Log("Rot : " + rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.x) * Time.deltaTime + " ; " + rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.z) * Time.deltaTime);
        //Debug.Log("AAAAAAAAAA : " + rot.x + " ; " + rot.z);
    }

}
