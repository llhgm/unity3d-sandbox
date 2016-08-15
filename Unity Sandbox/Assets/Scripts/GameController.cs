using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	public GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera.transform.parent = player.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
