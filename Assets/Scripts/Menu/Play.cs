using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public GameObject _panel,_panelCredits,_panelScores;
    public GameObject _exit, _exit2;
    public GameObject _crewMembers, _scoreboard;
    public GameObject _lucas,_igor,_louis,_valentin,_florian;

    public void clickPlay()
    {
        SceneManager.LoadScene("Master");
    }

    public void clickCredits()
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

    public void clickExit()
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

    public void clickScores()
    {
        _panelScores.SetActive(true);
        _exit2.SetActive(true);
        _scoreboard.SetActive(true);

        _panel.SetActive(false);
    }

    public void clickExit2()
    {
        _panel.SetActive(true);

        _panelScores.SetActive(false);
        _exit2.SetActive(false);
        _scoreboard.SetActive(false);
    }
    
}

