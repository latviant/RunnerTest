using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOver : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Player _player;
    [SerializeField] private Button _pauseButton;
    private CanvasGroup _gameOverGroup;

    private void OnEnable()
    {
        _player.Died += onDied;
        _restartButton.onClick.AddListener(OnRestartButtonClic);
        _exitButton.onClick.AddListener(OnExitButtonClic);
    }

    private void OnDisable()
    {
        _player.Died -= onDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClic);
        _exitButton.onClick.RemoveListener(OnExitButtonClic);
    }

    private void Start()
    {
        _gameOverGroup = GetComponent<CanvasGroup>();
        _gameOverGroup.alpha = 0;
    }

    private void onDied()
    {
        _gameOverGroup.alpha = 1;
        _pauseButton.gameObject.SetActive(false);
    }

    private void OnRestartButtonClic()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClic()
    {
        Application.Quit();
    }
}
