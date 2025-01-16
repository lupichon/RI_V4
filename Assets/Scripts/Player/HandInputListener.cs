using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandInputListener : MonoBehaviour
{
    public InputActionProperty _Shoot;
    public Animator _handAnimator;

    // Update is called once per frame
    void Update()
    {
        float _gripValue = _Shoot.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", _gripValue);
        Debug.Log("Test");
    }
}
