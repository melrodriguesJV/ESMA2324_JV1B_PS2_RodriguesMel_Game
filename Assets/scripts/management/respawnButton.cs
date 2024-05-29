using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawnButton : MonoBehaviour
{
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject currentCamera;
    public void Replay()
    {
        SceneManager.LoadSceneAsync(1);
        replayButton.SetActive(false);
        Destroy(player);
        Destroy(currentCamera);
    }
}
