using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 0.0003f;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] private Transform player;
    [SerializeField] private float returnSpeed;
    [SerializeField] private float cameraMovementThreshold;
    
    void Update()
    {
        CameraMove();
    }
    void CameraMove()
    {
        Vector3 movement = new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        transform.position += movement;
        Vector3 desiredPosition = player.position + cameraOffset;
        ;
        if (transform.position.x < player.position.x - cameraMovementThreshold)
        {
            transform.position = Vector3.Lerp(transform.position, player.position + cameraOffset, returnSpeed * Time.deltaTime);
        }
    }
}
 