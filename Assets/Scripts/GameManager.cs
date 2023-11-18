using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject playScreen;
    [SerializeField] private GameObject pauseScreen;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;
        playScreen.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        playScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1.0f;
        playScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
