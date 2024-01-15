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

    private float rotationSpeed = 0.2f;
    private float movementSpeed = 1.0f;

    Vector3 rot = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        RotParent = GameObject.Find("RotationLever");
        RotLevier = GameObject.FindWithTag("RotationLever");
        _tfRotLevier = RotLevier.GetComponent<Transform>();
        TranslationLevier = GameObject.FindWithTag("TranslationLever");
        _tfTranslationLevier = TranslationLevier.GetComponent<Transform>(); ;
        _tfShip = GetComponent<Transform>();
        _rbShip = GetComponent<Rigidbody>();

        //  _grab = GameObject.FindWithTag("main").GetComponent<handInputsListener>()._gripValue;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Rotation : " + _tfRotLevier.eulerAngles.x +" ; "+  0 +" ; "+ _tfRotLevier.eulerAngles.z);
        //_tfShip.Rotate((_tfRotLevier.eulerAngles.x) *rotationSpeed* Time.deltaTime,  0, (_tfRotLevier.eulerAngles.z) * rotationSpeed * Time.deltaTime);
        // -_tfShip.eulerAngles.z

        /*
        Quaternion rotation = _tfShip.rotation;
        //Vector3 direction = _tfShip.position;//_tfTranslationLevier.position - 
        //Quaternion lookRotation = Quaternion.LookRotation(direction);

        Quaternion avantRotation = Quaternion.AngleAxis(rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.x), Vector3.right);
        Quaternion coteRoatation = Quaternion.AngleAxis(rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.z), Vector3.forward);
        Quaternion combinedRotations = avantRotation * coteRoatation;

        Quaternion finalRotation = combinedRotations;// * lookRotation;
        _tfShip.rotation = Quaternion.RotateTowards(rotation, finalRotation, 0.1f);
        */
        contact = RotLevier.GetComponent<contactHandLever>().contact;
        if(contact)
        {
            rot.x += rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.x) * Time.deltaTime;
            rot.z += rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.z) * Time.deltaTime;
        }
        else
        {
            _tfRotLevier.position = Vector3.zero;
            _tfRotLevier.rotation = Quaternion.identity;
        }
        
        Debug.Log(" ______________________ : " + RotParent.GetComponent<contactHandLever>().contact);
        _tfShip.Rotate(rot.x, rot.y, rot.z, Space.Self);


        _tfShip.position = _tfShip.position + new Vector3(-Mathf.Sin(_tfTranslationLevier.eulerAngles.z * Mathf.PI / 180) * movementSpeed * Time.deltaTime, 0, Mathf.Sin(_tfTranslationLevier.eulerAngles.x * Mathf.PI / 180) * movementSpeed * Time.deltaTime);
        Debug.Log("Rot : " + rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.x) * Time.deltaTime + " ; " + rotationSpeed * Mathf.Sin(_tfRotLevier.eulerAngles.z) * Time.deltaTime);
        Debug.Log("AAAAAAAAAA : " + rot.x + " ; " + rot.z);
    }

}
