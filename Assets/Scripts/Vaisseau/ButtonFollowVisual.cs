using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    // Script gerant le comportement du bouton de lancement de la torpille
    public Transform visualTarget;
    private XRBaseInteractable interactable;
    public Vector3 initialLocalPos;
    public float resetSpeed = 5;
    private bool freeze = false;
    private Vector3 offset;
    public float followAngleTreshold;
    public Vector3 localAxis;
    private Transform pokeAttachTransform;
    private bool isFollowing = false;
    private GameObject Vaisseau;
    private ParticleSystem ps;

    void Start()
    {
        initialLocalPos = visualTarget.localPosition;
        interactable = GetComponent<XRBaseInteractable>();

        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(Reset);
        interactable.selectEntered.AddListener(Freeze);

        // On cherche le vaisseau
        Vaisseau = GameObject.Find("Vaisseau Spatial");

        // On cherche et on desactive le particle system sur la torpille
        ps = GameObject.Find("Pa").GetComponent<ParticleSystem>();
        var em = ps.emission;
        em.enabled = false;
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            isFollowing = true;
            freeze = false;
            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));

            if (pokeAngle < followAngleTreshold)
            {
                isFollowing = true;
                freeze = false;
            }
        }
    }

    public void Reset(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            isFollowing = false;
            freeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            freeze = true;
        }
    }
    // Update is called once per frame
    void Update()
    {   
        // Quand le bouton est enfonce, on entre dans le if (freeze) et on autorise le tir et l'emission de particules
        if (freeze)
        {
            Vaisseau.GetComponent<TorpedoToTarget>().isShooting();
            var em = ps.emission;
            em.enabled = true;
            return;
        }

        if (isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialLocalPos, Time.deltaTime * resetSpeed);
        }
    }
}
