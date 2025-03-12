using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerStateManager : MonoBehaviour
{
    
    public PlayerBaseState currentState;
    [HideInInspector]
    public PlayerIdleState IdleState = new PlayerIdleState();
    [HideInInspector]
    public PlayerWalkState walkState = new PlayerWalkState();
    [HideInInspector]
    public Vector2 movement;
    CharacterController controller;
    [HideInInspector]
    public PlayerSneakState sneakState = new PlayerSneakState();

    private Animator animator;

    public float default_speed = 5;
    public bool isSneaking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        SwitchState(IdleState);
        animator = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if(isSneaking == true)
        {
            animator.SetBool("IsMoving", true);
        }
        if(isSneaking == false)
        {
            animator.SetBool("IsMoving", false);
        }
    }

    // Input Handling Section

    void OnMove(InputValue moveVal)
    {
        //animator.SetBool("IsMoving", true);
        //This was code I tried at first but it didn't feel as if it really used the state machine
        movement = moveVal.Get<Vector2>();
    }

    void OnSprint()
    {
        if(isSneaking == false)
        {
            isSneaking = true;
            //animator.SetBool("IsMoving", false); 
            //This was code I tried at first but it didn't feel as if it really used the state machine
        }
            else
            {
                isSneaking = false;
            }
        

    }

    //Helper Functions
    public void MovePlayer(float speed)
    {
        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = new Vector3(moveX, 0, moveZ);
        controller.Move(actual_movement * Time.deltaTime * speed);

    }

    public void SwitchState(PlayerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
