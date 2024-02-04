using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pointRadar : MonoBehaviour
{
    public List<GameObject> objListe;
    public Transform _tfShip;
    private Transform _tfAv;
    private Transform _tfAr;
    private float majRate = 5f;
    private float nextMaj = 0f;

    List<Vector2> coordAr = new List<Vector2>();
    List<Vector2> coordAv = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        objListe = GameObject.Find("Radar").GetComponent<_detectionRadar>().objList;
        _tfShip = GameObject.FindWithTag("PlayerShip").GetComponent<Transform>();
        _tfAv = GameObject.Find("radarAvant").GetComponent<Transform>();
        _tfAr = GameObject.Find("radarAriere").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > nextMaj)
        {
            while (_tfAr.childCount > 0)
            {
                DestroyImmediate(_tfAr.GetChild(0).gameObject);
            }
            while (_tfAv.childCount > 0)
            {
                DestroyImmediate(_tfAv.GetChild(0).gameObject);
            }
            nextMaj = Time.time+majRate;
        }
    }

    void majRad()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        GameObject tmpAv = Instantiate(GameObject.Find("Empty"));
        tmpAv.transform.SetParent(_tfAv, false);
        GameObject tmpAr = Instantiate(GameObject.Find("Empty"));
        tmpAr.transform.SetParent(_tfAr, false);

        foreach (var obj in objListe)
        {
            if ((_tfShip.rotation.eulerAngles.y > -90 && _tfShip.rotation.eulerAngles.y < 90))
            {
                if ((obj.transform.position.z - _tfShip.position.z) > 0)
                {
                    coordAv.Add(new Vector2((obj.transform.position.x), (obj.transform.position.y)));
                }
                else
                {
                    coordAr.Add(new Vector2((obj.transform.position.x), (obj.transform.position.y)));
                }
            }
            else
            {
                if ((obj.transform.position.z - _tfShip.position.z) > 0)
                {
                    coordAr.Add(new Vector2((obj.transform.position.x), (obj.transform.position.y)));
                }
                else
                {
                    coordAv.Add(new Vector2((obj.transform.position.x), (obj.transform.position.y)));
                }
            }
        }

        foreach (var obj in coordAr)
        {
            GameObject o = Instantiate(GameObject.Find("blue_dot_radar"), new Vector3(obj.x + _tfAr.position.x, obj.y + _tfAr.position.y, _tfAr.position.z), _tfAr.rotation);
            o.transform.SetParent(tmpAv.transform, false);
        }
        foreach (var obj in coordAv)
        {
            GameObject o = Instantiate(GameObject.Find("blue_dot_radar"), new Vector3(obj.x + _tfAv.position.x, obj.y + _tfAv.position.y, _tfAv.position.z), _tfAv.rotation);
            o.transform.SetParent(tmpAr.transform, false);
        }
        nextMaj = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Right Controller")
        {
            //Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            majRad();
        }
    }
}
