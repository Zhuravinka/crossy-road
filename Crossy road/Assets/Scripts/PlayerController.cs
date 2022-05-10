using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   // [SerializeField] TerrainGenerator terrainGenerator;
   
   public float timeBeforeNextJump = 1.2f;
    public bool canMove = true;

    Animator _animator;
    Rigidbody character;
    int gridSize = 2;

    private static readonly int IsDead = Animator.StringToHash("isDead");

    private static readonly int Jump = Animator.StringToHash("Jump");
    //todo get the grid size properly from the terrain generator

    private void Awake()
    {
        EventManager.onPlayerDeath.AddListener(PlayerDeath);
    }

    void Start()
    {
       
        _animator = GetComponent<Animator>();
        character = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canMove)
        {
            ControllPlayer();
        }

    }

    void ControllPlayer()
    {
        
        
        if (Input.GetKeyDown(KeyCode.W) && canMove)
        {

            MoveCharacter(new Vector3(1,0,0));

        }
        else if (Input.GetKeyDown(KeyCode.S) && canMove)
        {
            MoveCharacter(new Vector3(-1, 0, 0) );   
        }
        else if (Input.GetKeyDown(KeyCode.A) && canMove)
        {
            MoveCharacter(new Vector3(0, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.D) && canMove)
        {
            MoveCharacter(new Vector3(0, 0, -1));
        }

    }

    private void MoveCharacter(Vector3 direction)
    {
        _animator.SetTrigger(Jump);
        character.transform.position += direction * gridSize; // TODO make with lerp and +=
    }

    private void PlayerDeath()
    {
        canMove = false;
        _animator.SetBool(IsDead, true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.GetComponent<MovingObject>())
        {
            transform.parent = collision.collider.transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.GetComponent<MovingObject>())
        {
            transform.parent = null;
        }
    }
    
}