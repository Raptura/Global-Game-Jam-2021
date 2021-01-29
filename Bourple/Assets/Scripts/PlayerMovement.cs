using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;
	private Input input;

	public float runSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

    private void Awake()
    {
		input = new Input();
    }

    private void OnEnable()
    {
		input.Enable();

		input.Player.Jump.performed += ctx => { Jump(); };
    }

    private void OnDisable()
    {
		input.Disable();
    }

    // Update is called once per frame
    void Update()
	{

		//horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		Vector2 move = input.Player.Move.ReadValue<Vector2>();
		horizontalMove = move.x * runSpeed;

		Debug.Log(horizontalMove.ToString());

		/*
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
		*/

		/*
		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		

		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
		*/

	}

	void Jump()
    {
		jump = true;
    }

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}