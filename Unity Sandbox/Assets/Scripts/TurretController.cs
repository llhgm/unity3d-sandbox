using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour {
	public GameObject turret;
	public GameObject barrel;
	public GameObject firePoint;
	public GameObject bullet;
	public GameObject flash;
	public float fireSpeed = 10.0f;
	public float turretRotateSpeed = 10.0f;
	public float gunSpeed = 10.0f;
	public float gunMax = 45.0f;
	public float gunMin = -45.0f;

	private float turretRotation = 0;
	private float gunElevation = 0;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		turret.transform.Rotate(Vector3.up * turretRotateSpeed * turretRotation * Time.deltaTime);
		barrel.transform.Rotate(Vector3.left * turretRotateSpeed * gunElevation * Time.deltaTime);
	}

	public void RotateTurret(float direction)
	{
		turretRotation = direction;
	}

	public void ElevateGun(float direction)
	{
		gunElevation = direction;
	}

	public void FireGun()
	{
		anim.SetTrigger("Fire");

		Instantiate(flash, firePoint.transform.position, firePoint.transform.rotation);

		GameObject bulletInstance = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;
		bulletInstance.GetComponent<Rigidbody>().velocity = bulletInstance.transform.forward * fireSpeed;

		Debug.Log("weapon fired");
	}
}
