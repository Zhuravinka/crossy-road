using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float cameraSpeed = 0.0003f;
    
   // [SerializeField] private PlayerController player;

  // [Header("Camera propertys")]
  // [SerializeField] private float returnSpeed;
  // [SerializeField] private float rearDistance;

    private Vector3 currentVector;

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
        //currentVector = new Vector3(player.transform.position.x + cameraSpeed * Time.deltaTime, transform.position.y, player.transform.position.z - rearDistance);
        //transform.position = Vector3.Lerp(transform.position, currentVector, returnSpeed * Time.deltaTime);
    }
}
