using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish_StartControllerScript : MonoBehaviour
{
    public GameObject StartgamePanel;

    public GameObject EndgamePanel;

    public GameObject IngamePanel;

    public Transform characterSpawmPoint;
    public GameObject tempCharacter;

    public Transform EnmySpawmPoint;
    public GameObject tempEnemy;

    public TextMeshProUGUI lifecount;

    private GameObject CharacterGO;
    private GameObject EnemyGO;

    private void Start()
    {
        StartgamePanel.SetActive(true);
        IngamePanel.SetActive(false);
        EndgamePanel.SetActive(false);
    }

    public void SetLifeCount(string text)
    {
        lifecount.text = text;
    }

    public void StartGame()
    {
        EndgamePanel.SetActive(false);
        StartgamePanel.SetActive(false);
        IngamePanel.SetActive(true);

        CharacterGO = Instantiate(tempCharacter, characterSpawmPoint);
        EnemyGO = Instantiate(tempEnemy, EnmySpawmPoint);
    }

    public void EndGame()
    {
        IngamePanel.SetActive(false);        
        EndgamePanel.SetActive(true);

        Destroy(CharacterGO);
        Destroy(EnemyGO);
    }

    public void RespawnCharacter()
    {
        StartGame();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
