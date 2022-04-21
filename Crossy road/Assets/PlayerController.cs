using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   // [SerializeField] TerrainGenerator terrainGenerator;
   
   public float timeBeforeNextJump = 1.2f;
    private bool canMove = true;

    Animator animator;
    CharacterController character;
    int gridSize = 2;
    Vector3 gravityForce = new Vector3(0, -0.05f, 0);
    //todo get the grid size properly from the terrain generator

    void Start()
    {
       
        animator = GetComponent<Animator>();
        character = GetComponent<CharacterController>();
    }

    void Update()
    {
        ControllPlayer();
        character.Move(gravityForce);
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
        animator.SetTrigger("Jump");
       // if()
        character.Move(direction * gridSize); // TODO make with lerp and +=
       
    }
}