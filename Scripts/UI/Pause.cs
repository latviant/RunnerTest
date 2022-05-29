using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
   
    public void ToPause()
    {
        Time.timeScale = 0;
        Activate();
    }

    public void ToPlay()
    {
        Time.timeScale = 1;
        DisActivate();
    }

    public void ToExit()
    {
        Application.Quit();
    }

    private void Activate()
    {
        _pauseCanvas.gameObject.SetActive(true);
        _playButton.gameObject.SetActive(true);
        _exitButton.gameObject.SetActive(true);
    }

    private void DisActivate()
    {
        _pauseCanvas.gameObject.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _exitButton.gameObject.SetActive(false);
    }
}
