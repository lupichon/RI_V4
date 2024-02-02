using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Game : MonoBehaviour
{
    public BossBehavior _boss;
    void Update()
    {
        if(_boss.isDead || PlayerHpBar._playerHealth == 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
