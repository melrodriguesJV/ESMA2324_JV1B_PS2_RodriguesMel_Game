using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class pauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject currentCamera;
    [SerializeField] private GameObject canvas;
    private PointManager pointManager;

    private void Start()
    {
        pauseMenu.SetActive(false);
        pointManager = PointManager.instance;
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
        Destroy(player);
        Destroy(currentCamera);
        Destroy(canvas);
        pointManager.ChangePoints(0);
    }
}
