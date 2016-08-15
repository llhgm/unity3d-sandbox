using UnityEngine;
using System.Collections;

public class TankEngine : MonoBehaviour {

	public float speed = 90f;
	public float turnSpeed = 5f;
	public float hoverForce = 65f;
	public float hoverHeight = 3.5f;

	private Rigidbody carRigidbody;
	private Vector3 currentAngle;
	private Vector3 targetAngle;
	private Vector3 startAngle;
	private float powerInput;
	private float turnInput;
	private float strafeInput;

	void Awake()
	{
		carRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		Ray ray = new Ray(transform.position, -transform.up);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, hoverHeight))
		{
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
		}

		carRigidbody.AddRelativeForce(0f, 0f, powerInput * speed);
		carRigidbody.AddRelativeForce(strafeInput * speed, 0f, 0f);
		carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
	}

	public void MoveForward(float direction)
	{
		powerInput = direction;
	}

	public void Strafe(float direction)
	{
		strafeInput = direction;
	}

	public void Turn(float direction)
	{
		turnInput = direction;
	}
}