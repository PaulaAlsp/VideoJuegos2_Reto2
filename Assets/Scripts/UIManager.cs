using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public GameObject buttonInicial;

    public TMP_Text countDownText, lapCounterText, bestLapTimeText, currentLapTimeText, totalLaps, positionText, raceResultText;
    public GameObject defaultScreen, pauseScreen, resultsScreen;
    bool panelPausaActive = false;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Gamepad.current.startButton.wasPressedThisFrame)
        {
            if (panelPausaActive == false)
            {
                Time.timeScale = 0f;
                pauseScreen.SetActive(true);
                panelPausaActive = true;
            }
            else
            {
                Time.timeScale = 1f;
                pauseScreen.SetActive(false);
                panelPausaActive = false;
                EventSystem.current.SetSelectedGameObject(buttonInicial);
            }
        }
    }
}

