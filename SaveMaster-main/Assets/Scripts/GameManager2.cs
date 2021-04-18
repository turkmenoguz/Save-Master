using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public GameObject startingPanel;

    public GameObject joystickPanel;

    public GameObject closePanel;

    private bool levelCheck;

    BusController busController;

    private void Awake()
    {
        Time.timeScale = 0;

        Application.targetFrameRate = 400;

        busController = GameObject.FindGameObjectWithTag("bus").GetComponent<BusController>();
    }
    private void Update()
    {
        levelCheck = busController.levelCompleted;
        LevelController();
    }
    

    public void ClosePanel()
    {
        startingPanel.SetActive(false);
        joystickPanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void LevelController()
    {
        if (levelCheck)
        {
            closePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }
}
