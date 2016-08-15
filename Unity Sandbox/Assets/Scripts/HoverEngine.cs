using UnityEngine;
using System.Collections;

public class HoverEngine : MonoBehaviour {

	public float speed = 90f;
	public float turnSpeed = 5f;
	public float hoverForce = 65f;
	public float hoverHeight = 3.5f;
	public float engineRotationSpeed = 10.0f;
	public float engineReturnSpeed = 10.0f;
	public float engineMaxAngle = 45.0f;
	public GameObject[] engines;

	private Rigidbody carRigidbody;
	private Vector3 currentAngle;
	private Vector3 targetAngle;
	private Vector3 startAngle;

	void Start()
	{
		currentAngle = engines[0].transform.eulerAngles;
		startAngle = engines[0].transform.eulerAngles;
		targetAngle = new Vector3(engineMaxAngle, 0f, 0f);
	}

	void Awake()
	{
		carRigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			foreach (GameObject engine in engines)
			{
				currentAngle = new Vector3(
					Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
					Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
					Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime)
				);
			}
		} else if (Input.GetKey(KeyCode.S))	{
			foreach (GameObject engine in engines)
			{
				
			}
		} else {
			currentAngle = new Vector3(
				Mathf.LerpAngle(currentAngle.x, startAngle.x, Time.deltaTime),
				Mathf.LerpAngle(currentAngle.y, startAngle.y, Time.deltaTime),
				Mathf.LerpAngle(currentAngle.z, startAngle.z, Time.deltaTime)
			);
		}
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

		foreach (GameObject engine in engines)
		{
			engine.transform.eulerAngles = currentAngle;
		}
	}
}
