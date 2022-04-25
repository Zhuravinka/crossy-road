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
    CharacterController character;
    int gridSize = 2;
    Vector3 gravityForce = new Vector3(0, -1f, 0);

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
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (canMove)
        {
            ControllPlayer();
            character.Move(gravityForce);
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
        character.Move(direction * gridSize); // TODO make with lerp and +=
    }

    private void PlayerDeath()
    {
        canMove = false;
        _animator.SetBool(IsDead, true);
    }
    
    
}