using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10.0f;
    //Variables Salto
    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    [SerializeField] private float _jumpHeight = 5.0f;
    private bool _jumpPressed = false;
    private float _gravityValue = -9.81f;

    public PlayerInput _playerInput;


    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.actions["Jump"].performed += ctx => Jump();
    }

    void Update()
    {
        Vector2 movementInput = _playerInput.actions["Move"].ReadValue<Vector2>();
        
        MovementMove(movementInput.x, movementInput.y);
        MovementJump();
    }
    private void Jump()
    {
        OnJump();
    }

    private void MovementMove(float x, float z)
    {
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }
    private void MovementJump()
    {
        _groundedPlayer = controller.isGrounded;
        if (_groundedPlayer)
            _playerVelocity.y = 0.0f;
        if (_jumpPressed)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -1.0f * _gravityValue);
            _jumpPressed = false;
        }
        _playerVelocity.y += _gravityValue * Time.deltaTime;
        controller.Move(_playerVelocity * Time.deltaTime); 
    }
    private void OnJump()
    {
        if (controller.velocity.y == 0)
            _jumpPressed = true;
    }
}
