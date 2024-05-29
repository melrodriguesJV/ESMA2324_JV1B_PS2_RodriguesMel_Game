using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseButton : MonoBehaviour
{
    [SerializeField] private GameObject leaveButton;
    public void Pause()
    {
        leaveButton.SetActive(true);
    }
}
