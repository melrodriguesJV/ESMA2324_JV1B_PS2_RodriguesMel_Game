using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject leaveButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject currentCamera;
    [SerializeField] private GameObject canvas;
    private PointManager pointManager;

    private void Start()
    {
        pointManager = PointManager.instance;
    }

    public void Replay()
    {
        SceneManager.LoadSceneAsync(1);
        replayButton.SetActive(false);
        leaveButton.SetActive(false);
        Destroy(player);
        Destroy(currentCamera);
        Destroy(canvas);
        pointManager.ChangePoints(0);
    }

    public void Leave()
    {
        SceneManager.LoadSceneAsync(0);
        replayButton.SetActive(false);
        leaveButton.SetActive(false);
        pauseButton.SetActive(false);
        Destroy(player);
        Destroy(currentCamera);
        Destroy(canvas);
        pointManager.ChangePoints(0);
    }
}
