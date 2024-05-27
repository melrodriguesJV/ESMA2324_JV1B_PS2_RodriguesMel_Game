using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public static PointManager instance;

    private int points;
    [SerializeField] private TMP_Text pointsDisplay;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void OnGUI()
    {
        pointsDisplay.text = points.ToString();
    }

    public void ChangePoints(int amount)
    {
        points += amount;
    }
}
