using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // [SerializeField] TerrainGenerator terrainGenerator;

    public float movementSpeed = 3;
    public float jumpForce = 300;
    public float timeBeforeNextJump = 1.2f;
    private bool canMove = true;

    Animator _animator;
    CharacterController _character;
    int _gridSize = 2;
    Vector3 gravityForce = new Vector3(0, -0.05f, 0);
    //todo get the grid size properly from the terrain generator

    public static bool isDead = false; //??
    void Start()
    {

        _animator = GetComponent<Animator>();
        _character = GetComponent<CharacterController>();
    }

    void Update()
    {
        ControllPlayer();
        _character.Move(gravityForce);
    }

    void ControllPlayer()
    {


        if (Input.GetKeyDown(KeyCode.W) && canMove)
        {

            MoveCharacter(new Vector3(1, 0, 0));

        }
        else if (Input.GetKeyDown(KeyCode.S) && canMove)
        {
            MoveCharacter(new Vector3(-1, 0, 0));
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

    public void MoveCharacter(Vector3 direction)
    {
        _animator.SetTrigger("Jump");
        // if()
        _character.Move(direction * _gridSize);//todo make with lerp and +=

    }
    public IEnumerator Die()
    {
        isDead = true;
        _animator.SetTrigger("Death");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}