using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawnButton : MonoBehaviour
{
    [SerializeField] private GameObject replayButton;
    public void Replay()
    {
        SceneManager.LoadSceneAsync(1);
        replayButton.SetActive(false);
    }
}
