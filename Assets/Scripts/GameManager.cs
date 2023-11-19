using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI purpleBallText;
    [SerializeField] private TextMeshProUGUI greenBallText;
    [SerializeField] private TextMeshProUGUI redBallText;
    [SerializeField] private TextMeshProUGUI destroyedBallText;
    [SerializeField] private TextMeshProUGUI HideUIButtonText;

    private int purpleCounter = 0;
    private int greenCounter = 0;
    private int redCounter = 0;
    private int destroyedCounter = 0;

    private bool uiVisible = true;

    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject playScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject playUI;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeUIVisible()
    {
        uiVisible = !uiVisible;
        DisplayUI();
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

    public void IncreaseDestroyCounter()
    {
        destroyedCounter++;
        UpdateDestroyText();
    }
    
    public void IncreaseGreenCounter()
    {
        greenCounter++;
        UpdateGreenText();
    }
    
    public void IncreasePurpleCounter()
    {
        purpleCounter++;
        UpdatePurpleText();
    }
    
    public void IncreaseRedCounter()
    {
        redCounter++;
        UpdateRedText();
    }

    private void UpdateDestroyText()
    {
        destroyedBallText.text = $"Destroyed: {destroyedCounter}";
    }
    private void UpdatePurpleText()
    {
        purpleBallText.text = $"Purple : {purpleCounter}";
    }
    private void UpdateRedText()
    {
        redBallText.text = $"Red : {redCounter}";
    }
    private void UpdateGreenText()
    {
        greenBallText.text = $"Green : {greenCounter}";
    }

    private void DisplayUI()
    {
        if (uiVisible)
        {
            playUI.SetActive(true);
            HideUIButtonText.text = "HIDE UI";
        }
        else
        {
            playUI.SetActive(false);
            HideUIButtonText.text = "SHOW UI";
        }
    }
}
