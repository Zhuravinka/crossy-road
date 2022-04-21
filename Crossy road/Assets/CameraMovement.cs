using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 0.0003f;
    [SerializeField] Vector3 offset;
    [SerializeField] private PlayerController player;
    [SerializeField] private float returnSpeed;

    [SerializeField] private float maxDistance;
  // [Header("Camera propertys")]

  // [SerializeField] private float rearDistance;



    void Start()
    {
       //transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z - rearDistance);
       
    }
    void Update()
    {
        CameraMove();

    }
    void CameraMove()
    {
        Vector3 movement = new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
        transform.position += movement;
        if ((transform.position.x-player.transform.position.x) > maxDistance)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, returnSpeed * Time.deltaTime);
        }
    }
}
