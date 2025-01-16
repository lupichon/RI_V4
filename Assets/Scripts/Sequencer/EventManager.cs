using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, Action<EventParam>> eventDictionary;
    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManager script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }
            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, Action<EventParam>>();
        }
    }

    public static void StartListening(string eventName, Action<EventParam> listener)
    {
        Action<EventParam> thisEvent;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //Add more event to the existing one
            thisEvent += listener;

            //Update the Dictionary
            instance.eventDictionary[eventName] = thisEvent;
        }
        else
        {
            //Add event to the Dictionary for the first time
            thisEvent += listener;
            instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void StopListening(string eventName, Action<EventParam> listener)
    {
        if (eventManager == null) return;
        Action<EventParam> thisEvent;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            //Remove event from the existing one
            thisEvent -= listener;
            if (thisEvent == null)
            {
                instance.eventDictionary.Remove(eventName);
            }
            else
            {
                //Update the Dictionary
                instance.eventDictionary[eventName] = thisEvent;
            }

        }
    }

    public static void TriggerEvent(string eventName, EventParam eventParam)
    {
        Action<EventParam> thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(eventParam);
            // OR USE  instance.eventDictionary[eventName](eventParam);
        }
    }

    internal static void TriggerEvent(string v)
    {
        TriggerEvent(v, null);
    }
}
public interface EventParam
{

}
public class EventParamShoot : EventParam
{
    private GameObject _bullet;
    private GameObject _tower;
    private GameObject _parentShoot;
    private float _compteur = 0f;
    private float _timer = 1f;
    private float _speedBullet = 10f;
    public EventParamShoot(GameObject Bullet, GameObject Tower, GameObject Parent, float Compteur, float Timer, float SpeedBullet)
    {
       this._bullet=Bullet;
       this._tower=Tower;
       this._parentShoot = Parent;
       this._compteur=Compteur;
       this._timer=Timer;
       this._speedBullet=SpeedBullet;
    }

    public GameObject Bullet { get => _bullet; set => _bullet = value; }
    public GameObject Tower { get => _tower; set => _tower = value; }
    public GameObject Parent { get => _parentShoot; set => _parentShoot = value; }
    public float Compteur { get => _compteur; set => _compteur = value; }
    public float Timer { get => _timer; set => _timer = value; }
    public float SpeedBullet { get => _speedBullet; set => _speedBullet = value; }
}

