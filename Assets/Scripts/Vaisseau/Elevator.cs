using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Collider du player
    private Collider _myCollider;

    // Collider des portes de l'etage superieur et inferieur
    private Collider _colliderPorteHaute, _colliderPorteBasse;

    // Joueur et vaisseau
    public GameObject _player, _ship;

    // Le joueur est sur l'asceseur ou non
    public bool _playerOnElevator;

    // L'ascenseur est en bas ou en haut
    public bool _elevatorDown;

    // Temps
    public float _timer;

    // Delai entre montee/descente de l'ascenseur et entree du joueur
    public float _delay;

    // Vitesse de deplacement de l'ascenseur
    public float _speed = 1f;

    void Start()
    {
        _myCollider = GetComponent<Collider>();
        _playerOnElevator = false;
        _elevatorDown = false;
        _timer = 0f;

        // Le joeuur doit rentrer dans l'ascenseur, attendre 4s, puis l'ascenseur monte ou descend
        _delay = 4f;

        _player = GameObject.Find("XR Origin (XR Rig)");
        _colliderPorteHaute = GameObject.Find("Porte Haute").GetComponent<BoxCollider>();
        _colliderPorteBasse = GameObject.Find("Porte Basse").GetComponent<BoxCollider>();
        _ship = GameObject.Find("Vaisseau Spatial");
    }

    // Si le joueur est dans l'ascenceur, le boolean playerOnElevator devient true
    void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("Player"))
            {
                _playerOnElevator = true;
            }
        }
    }

    // Sinon, il est false
    void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Player not on elevator");
                _playerOnElevator = false;
            }
        }
    }

    void Update()
    {
        if (_playerOnElevator == true)
        {
            // Si le joueur est dans l'ascenseur alors on le met fils de l'ascenseur
            _player.GetComponent<Transform>().SetParent(GetComponent<Transform>(), true);
            if (_elevatorDown == true)
            {
                // Si l'ascenseur est en bas alors on attend 4s, puis on monte
                _timer += Time.deltaTime;
                if (_timer > _delay)
                {
                    if (GetComponent<Transform>().position.y < 2.225f)
                    {
                        GetComponent<Transform>().Translate(Vector3.up * Time.deltaTime * _speed);
                        _colliderPorteHaute.enabled = false;
                    }
                    else
                    {
                        _player.GetComponent<Transform>().SetParent(null);
                        _elevatorDown = false;
                        _timer = 0;
                        _colliderPorteHaute.enabled = true;
                    }
                }
            }
            else
            {
                // Si l'ascenseur est en haut alors on descend
                _timer += Time.deltaTime;
                if (_timer > _delay)
                {
                    _player.GetComponent<Transform>().SetParent(GetComponent<Transform>(), true);
                    if (GetComponent<Transform>().position.y > -1.7f)
                    {
                        GetComponent<Transform>().Translate(Vector3.down * Time.deltaTime * _speed);
                        _colliderPorteBasse.enabled = false;
                    }
                    else
                    {
                        _player.GetComponent<Transform>().SetParent(null);
                        _elevatorDown = true;
                        _timer = 0;
                        _colliderPorteBasse.enabled = true;
                    }
                }
            }
        }
        else
        {
            // Quand le joueur sort de l'ascencseur, il redevient fils du vaisseau
            _player.GetComponent<Transform>().SetParent(_ship.transform);
        }
    }
}
