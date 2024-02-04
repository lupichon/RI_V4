using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ce script permet la gestion des boutons dans le menu

public class Play : MonoBehaviour
{
    public GameObject _panel,_panelCredits,_panelScores;
    public GameObject _exit, _exit2;
    public GameObject _crewMembers, _scoreboard;
    public GameObject _lucas,_igor,_louis,_valentin,_florian;

    public void clickPlay()                 //permet le démarrage de la scène Master
    {
        SceneManager.LoadScene("Master");          
    }

    public void clickCredits()              //permet l'affichage de la fenêtre Crédits
    {
        _panelCredits.SetActive(true);
        _exit.SetActive(true);
        _crewMembers.SetActive(true);
        _lucas.SetActive(true);
        _igor.SetActive(true);
        _louis.SetActive(true);
        _valentin.SetActive(true);
        _florian.SetActive(true);

        _panel.SetActive(false);
    }

    public void clickExit()                 //permet de retourner à l'affichage initial depuis la fenêtre Crédits
    {
        _panel.SetActive(true);

        _panelCredits.SetActive(false);
        _exit.SetActive(false);
        _crewMembers.SetActive(false);
        _lucas.SetActive(false);
        _igor.SetActive(false);
        _louis.SetActive(false);
        _valentin.SetActive(false);
        _florian.SetActive(false);

    }

    public void clickScores()               //permet l'affichage de la fenêtre Scores
    {
        _panelScores.SetActive(true);
        _exit2.SetActive(true);
        _scoreboard.SetActive(true);

        _panel.SetActive(false);
    }

    public void clickExit2()                ////permet de retourner à l'affichage initial depuis la fenêtre Scores
    {
        _panel.SetActive(true);

        _panelScores.SetActive(false);
        _exit2.SetActive(false);
        _scoreboard.SetActive(false);
    }
    
}

