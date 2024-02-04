/*
   Script qui permet de détruire les alliés du boss
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LeftRayCastShooter : MonoBehaviour
{
    LineRenderer _aim;
    Material _matRock;
    public InputActionProperty _grip;
    public InputActionProperty _primButton;
    bool _rayOn = true;
    Vector3 _directionRay;
    Vector3 _positionDepart;
    Transform _tfHand;
    public static float _shootCooldown = 1.5f;
    public static float _shootTimer = 0;
    int _weaponType = 0;
    float _weaponChangeTimer = 0;
    float _weaponChangeCooldown = 1f;
    int _nbWeaponType = 3;

    public AudioClip destruitrock;

    public AudioSource XR;
    // Start is called before the first frame update
    void Start()
    {
        _tfHand = GetComponent<Transform>();
        _matRock = Resources.Load<Material>("Assets/Assets/Rock/texture/Materials/Stone_specular.mat");
        _aim = GetComponent<LineRenderer>();
        _aim.startWidth = 0.05f;
        _aim.endWidth = 0.05f;

    }




    //gestion du tir 
    void _shootAttempt()
    {
        //On augmente le timer pour savoir si l'on peut tiré
        _shootTimer += Time.deltaTime;

        // On récupére la valeur du grip
        float _gripState = _grip.action.ReadValue<float>();

        RaycastHit hit;
        _positionDepart = _tfHand.position;
        _directionRay = -_tfHand.up;
        //Debug.DrawRay(_positionDepart, _directionRay, Color.green);

        if (_gripState > 0.5)
        {
            //On test si l'on peut tirer
            if (Physics.Raycast(_positionDepart, _directionRay, out hit, 100) && _rayOn && _shootTimer >= _shootCooldown)
            {
                Transform _tfHit = hit.collider.GetComponent<Transform>();
                // On test si l'on touche la cible avec le bon type d'arme correspondant a sa faiblesse 
                if (_tfHit.tag == "WeakToPlasma" && _weaponType == 0)
                {
                    XR.PlayOneShot(destruitrock);

                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    if (_tfHit.tag == "WeakToIon" && _weaponType == 1)
                    {
                        XR.PlayOneShot(destruitrock);

                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        if (_tfHit.tag == "creepMob" && _weaponType == 2)
                        {
                            hit.collider.gameObject.GetComponent<Animator>().SetBool("isDead", true);
                            hit.collider.gameObject.GetComponent<_creepMobBehavior>().isDead = true;
                        }
                    }

                }
                _shootTimer = 0;

            }

        }
    }
    // On change de type d'arme si l'on ne l'a pas fait avant
    void _weaponTypeChange()
    {
        
        float _primbuttonvalue = _primButton.action.ReadValue<float>();
        
        _weaponChangeTimer += Time.deltaTime;
        if (_primbuttonvalue > 0.5f && _weaponChangeTimer > _weaponChangeCooldown)
        {
            Debug.Log("X");
            _weaponType = (_weaponType+1)%_nbWeaponType;
            _weaponChangeTimer=0;
        }
    }
    // on utilise un line renderer afin de crée un laser d'aide a la visée selon le type d'arme 
    void _weaponAimDraw()
    {
        
        _aim.SetPosition(0, _positionDepart);
        _aim.SetPosition(1, _positionDepart + 1000 * _directionRay);
        switch (_weaponType)
        {
            case 0:
                _aim.startColor = Color.black;
                _aim.endColor = Color.black;
                break;
            case 1:
                _aim.startColor = Color.red;
                _aim.endColor = Color.red;
                break;
            case 2:
                _aim.startColor = Color.green;
                _aim.endColor = Color.green;
                break;
            default:
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {
        _shootAttempt();
        _weaponTypeChange();
        _weaponAimDraw();
    }
    }
