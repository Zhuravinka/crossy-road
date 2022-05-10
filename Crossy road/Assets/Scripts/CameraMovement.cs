using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
  
        if (transform.position.x < player.position.x - cameraMovementThreshold)
        {
            Vector3 desiredPosition = player.position + cameraOffset;
          // desiredPosition.z = Mathf.Clamp(transform.position.z, 5, -3);
          transform.position = Vector3.Lerp(transform.position, desiredPosition, returnSpeed * Time.deltaTime);
        }
    }
}
 