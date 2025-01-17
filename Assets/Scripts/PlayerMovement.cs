﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// Myth's CharacterController Script
	public CharacterController controller;
	
	public float speed;
	public float gravity = -19.62f;
	public float jumpHeight = 3f;
	public float groundDistance = 0.5f;
	
	public Transform groundCheck;	
	public LayerMask groundMask;
	
	Vector3 velocity;
	bool isGrounded;
	
    // Update is called once per frame
    void Update()
    {
		// isGrounded
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		
		// Sprint
		speed = Input.GetKey(KeyCode.LeftShift) ? 24f : 12f;
		
		// Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
		Vector3 move = transform.right * x + transform.forward * z;
		controller.Move(move * speed * Time.deltaTime);
		
		// Jump
		if(Input.GetButtonDown("Jump") && isGrounded) 
		velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
		
		// Gravity
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
		
		// Reset Downward Velocity
		if(isGrounded && velocity.y < 0) velocity.y = -2f; 
    }
}
