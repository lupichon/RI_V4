using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    Animator anim;
    float _DeathLength = 3f, _deathTimer = 0; 
    public AudioClip mortBoss;
    public AudioSource XR;
    bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Torpille"))
        {
            anim.SetBool("isDead", true);
            
            XR.PlayOneShot(mortBoss);
            Destroy(other.gameObject);
            isDead = true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            _deathTimer += Time.deltaTime;
            if(_deathTimer > _DeathLength)
            {
                Destroy(GetComponent<Transform>().gameObject);
            }
        }
    }
}
