using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{

	///////////////////////////////
	// assign in inspector
	public float moveSpeed = 0.0001f;
	public float rotateSpeed = 0.1f;
	///////////////////////////////

	///////////////////////////////
	// must assign in inspector
	public GameObject successImage;
	///////////////////////////////

	bool pressedLeftButton = false;
	bool pressedRightButton = false;

	void Start()
	{
		successImage.SetActive(false);
	}

	void FixedUpdate()
	{
		if (gameStarted == false)
			return;

		float rotateValue = rotateSpeed * Time.fixedDeltaTime;
		float moveValue = moveSpeed * Time.fixedDeltaTime;
		
		transform.position += transform.forward * moveValue;

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

	void OnCollisionEnter(Collision other)
	{
		if (MapLoader.isGoal(other))
		{
			gameStarted = false;
			successImage.SetActive(true);
		}
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

	void InitGameState()
	{
		transform.localPosition = new Vector3(1, 2, 1);
		transform.localRotation = Quaternion.Euler(270, 0, 0);		
	}

	public void GameStartButtonClicked(GameObject clickedButton)
	{
		InitGameState();

		gameStarted = true;
		clickedButton.SetActive(false);
	}

	public void RestartGameButtonClicked()
	{
		InitGameState();
		
		gameStarted = true;
		successImage.SetActive(false);
	}

}
