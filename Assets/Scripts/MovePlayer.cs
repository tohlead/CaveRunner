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

	int isOppositeDirection = 1;

	void Start()
	{
		successImage.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			DetermindDirection();
			pressedLeftButton = true;
		}			

		if (Input.GetKeyUp(KeyCode.LeftArrow))
			pressedLeftButton = false;

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			DetermindDirection();
			pressedRightButton = true;
		}

		if (Input.GetKeyUp(KeyCode.RightArrow))
			pressedRightButton = false;
	}

	float elapsedTime = 0;

	void FixedUpdate()
	{
		if (gameStarted == false)
			return;

		elapsedTime += Time.fixedDeltaTime;
		UpdateTimeText();
		
		float rotateValue = rotateSpeed * Time.fixedDeltaTime;
		float moveValue = moveSpeed * Time.fixedDeltaTime;
		
		transform.position += transform.forward * moveValue;		

		if (pressedLeftButton)
		{			
			transform.Rotate(0, -rotateValue * isOppositeDirection, 0);
		}
		else if (pressedRightButton)
		{
			transform.Rotate(0, rotateValue * isOppositeDirection, 0);
		}
	}

	UnityEngine.UI.Text _timeText = null;
	UnityEngine.UI.Text timeText
	{
		get
		{
			if (_timeText == null)
			{
				GameObject timeTextObj = GameObject.Find("UI/TimeBG/TimeText");
				if (timeTextObj != null)
					_timeText = timeTextObj.GetComponent<UnityEngine.UI.Text>();
			}

			return _timeText;
		}
	}

	void UpdateTimeText()
	{
		int minute = (int)(elapsedTime / 60.0f);
		float second = elapsedTime % 60;
		timeText.text = string.Format("Time : {0:00}:{1:00.00}", minute, second);
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
		DetermindDirection();

		pressedLeftButton = true;
	}

	public void PressLeftArrowUp()
	{
		pressedLeftButton = false;
	}

	public void PressRightArrowDown()
	{
		DetermindDirection();

		pressedRightButton = true;
	}

	void DetermindDirection()
	{		
	}

	public void PressRightArrowUp()
	{
		pressedRightButton = false;
	}

	void InitGameState()
	{
		elapsedTime = 0;
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
