using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour
{
	///////////////////////////////
	// must assign in inspector
	public GameObject followingObject;
	///////////////////////////////

	void Update()
	{
		transform.position = followingObject.transform.position - new Vector3(0, 0.5f, 1.5f);
	}
}
