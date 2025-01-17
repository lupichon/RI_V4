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
public class EventTest : EventParam
{
    private GameObject _prefabAsterOr;
    

    public EventTest(GameObject PrefabAsterOr)
    {
       this._prefabAsterOr = PrefabAsterOr;

    }

    public GameObject PrefabAsterOr { get => _prefabAsterOr; set => _prefabAsterOr = value; }

}
public class EventMinageOn : EventParam
{
    private GameObject _prefabAsterOr;
    private int _maxRaycastMinageDistance;
    private int _tempsRecolte;
    private int _stateAction;

    public EventMinageOn(GameObject PrefabAsterOr, int MaxRaycastMinageDistance,int TempsRecolte,int StateAction)
    {
       this._prefabAsterOr = PrefabAsterOr;
       this._maxRaycastMinageDistance = MaxRaycastMinageDistance;
       this._tempsRecolte = TempsRecolte;
       this.StateAction = StateAction;
    }

    public GameObject PrefabAsterOr { get => _prefabAsterOr; set => _prefabAsterOr = value; }
    public int MaxRaycastMinageDistance { get => _maxRaycastMinageDistance; set => _maxRaycastMinageDistance = value; }
    public int TempsRecolte { get => _tempsRecolte; set => _tempsRecolte = value; }
    public int StateAction { get => _stateAction; set => _stateAction = value; }
}
public class EventGoldReçu : EventParam
{
    private int _stockGold;


    public EventGoldReçu(int StockGold)
    {
        this.StockGold = StockGold;

    }

    public int StockGold { get => _stockGold; set => _stockGold = value; }
}

