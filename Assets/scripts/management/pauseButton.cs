using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseButton : MonoBehaviour
{
    [SerializeField] private GameObject leaveButton;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject currentCamera;
    [SerializeField] private GameObject canvas;
    private PointManager pointManager;
    public void Pause()
    {
        leaveButton.SetActive(true);
    }

    public void Leave()
    {
        SceneManager.LoadSceneAsync(0);
        leaveButton.SetActive(false);
        Destroy(player);
        Destroy(currentCamera);
        Destroy(canvas);
        pointManager.ChangePoints(0);
    }
}
