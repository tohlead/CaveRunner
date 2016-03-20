using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
	public float moveSpeed = 0.0001f;
	public float rotateSpeed = 0.1f;

	bool pressedLeftButton = false;
	bool pressedRightButton = false;

	void FixedUpdate()
	{
		float rotateValue = rotateSpeed * Time.fixedDeltaTime;
		float moveValue = moveSpeed * Time.fixedDeltaTime;
		
		if (gameStarted)
		{
			transform.position += transform.forward * moveValue;
		}

		if (Input.GetKey(KeyCode.LeftArrow) || pressedLeftButton)
		{
			transform.Rotate(0, -rotateValue, 0);
		}
		else if (Input.GetKey(KeyCode.RightArrow) || pressedRightButton)
		{
			transform.Rotate(0, rotateValue, 0);
		}
	}

	bool gameStarted = false;	

	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject);
	}	

	public void PressLeftArrowDown()
	{
		pressedLeftButton = true;
	}

	public void PressLeftArrowUp()
	{
		pressedLeftButton = false;
	}

	public void PressRightArrowDown()
	{
		pressedRightButton = true;
	}

	public void PressRightArrowUp()
	{
		pressedRightButton = false;
	}

	public void GameStartButtonClicked(GameObject btnGameStart)
	{
		gameStarted = true;
		btnGameStart.SetActive(false);
	}
}
