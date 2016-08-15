using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {
	public GameObject playerTank;

	private TankEngine tankEngine;
	private TurretController turretController;

	void Awake ()
	{
		turretController = playerTank.GetComponent<TurretController>();
		tankEngine = playerTank.GetComponent<TankEngine>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
		{
			tankEngine.MoveForward(1);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			tankEngine.MoveForward(-1);
		}
		else
		{
			tankEngine.MoveForward(0);
		}

		if (Input.GetKey(KeyCode.A))
		{
			tankEngine.Strafe(-1);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			tankEngine.Strafe(1);
		}
		else
		{
			tankEngine.Strafe(0);
		}

		if (Input.GetKey(KeyCode.Q))
		{
			tankEngine.Turn(-1);
		}
		else if (Input.GetKey(KeyCode.E))
		{
			tankEngine.Turn(1);
		}
		else
		{
			tankEngine.Turn(0);
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			turretController.ElevateGun(1);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			turretController.ElevateGun(-1);
		}
		else
		{
			turretController.ElevateGun(0);
		}

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			turretController.RotateTurret(-1);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			turretController.RotateTurret(1);
		}
		else
		{
			turretController.RotateTurret(0);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			turretController.FireGun();
		}
	}
}
