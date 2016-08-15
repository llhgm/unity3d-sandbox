using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	public GameObject explosion;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player")
		{
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}