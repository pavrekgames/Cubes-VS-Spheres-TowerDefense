using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int currentGold = 50;

    public static bool isGamePause = true;
    public static bool isGameOver = false;

    [Header("Canvases")]
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas gameOverCanvas;

    [Header("Audio")]
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource buttonAudioSource;
    [SerializeField] private AudioClip buttonSound;

    private void Awake()
    {
        PauseGame();
    }

    private void Start()
    {
        BaseSphere.OnGotFinishLine += GameOver;
    }

    void Update()
    {
        if (Time.timeScale == 0) { isGamePause = true; } else { isGamePause = false; }
    }

    public void PauseGame()
    {
        if (isGameOver == false)
        {
            buttonAudioSource.PlayOneShot(buttonSound);
            mainMenuCanvas.enabled = true;
            backgroundAudioSource.Pause();
            Time.timeScale = 0;
        }
    }

    public void UnPauseGame()
    {
        buttonAudioSource.PlayOneShot(buttonSound);
        mainMenuCanvas.enabled = false;
        backgroundAudioSource.UnPause();
        Time.timeScale = 1;
    }

    private void GameOver()
    {
        isGameOver = true;
        isGamePause = true;
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        backgroundAudioSource.Pause();
    }

}
