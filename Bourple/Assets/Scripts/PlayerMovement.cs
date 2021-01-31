using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    private Input input;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;

    private void Awake()
    {
        input = new Input();
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Jump.performed += ctx => { Jump(); };
        input.Player.Reset.performed += ctx => { Reset(); };
    }

    private void OnDisable()
    {
        input.Disable();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 move = input.Player.Move.ReadValue<Vector2>();
        horizontalMove = move.x * runSpeed;

    }

    void Jump()
    {
        jump = true;
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}