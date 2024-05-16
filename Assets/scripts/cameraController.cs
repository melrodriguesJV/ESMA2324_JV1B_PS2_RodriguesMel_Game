using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + aheadDistance, transform.position.y, transform.position.z);
        
    }
}
