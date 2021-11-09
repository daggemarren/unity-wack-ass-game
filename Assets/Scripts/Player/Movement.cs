using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	public Transform mainCamera;
	private PlayerInput playerInput;
	private float speed = 12.0f;
	private Rigidbody rigidbody;
	private Vector2 currentInput;

	private void Awake()
	{
		playerInput = new PlayerInput();
		playerInput.Player.Move.performed += Walk;
		playerInput.Player.Move.canceled += Walk;

		rigidbody = GetComponent<Rigidbody>();
		rigidbody.freezeRotation = true;
	}

	private void Walk(InputAction.CallbackContext context)
	{
		currentInput = context.ReadValue<Vector2>();
	}

	private bool IsGrounded() => Physics.Raycast(transform.position, Vector3.down, 1.5f) ? true : false;

	void OnEnable() => playerInput.Player.Enable();

	void OnDisable() => playerInput.Player.Disable();

	void Start()
	{
		// Sätta nå default vinkel???
	}

	void FixedUpdate()
	{
		Vector3 _movementVector = currentInput.x * transform.right * speed + currentInput.y * transform.forward * speed;
		rigidbody.velocity = new Vector3(_movementVector.x, rigidbody.velocity.y, _movementVector.z);

		Quaternion targetRotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5.0f);
	}
}
