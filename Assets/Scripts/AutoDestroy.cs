using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour
{
	public float destroyTime = 1.0f;

	float elapsedTime = 0;

	void Update()
	{
		elapsedTime += Time.deltaTime;

		if (elapsedTime >= destroyTime)
			Destroy(gameObject);
	}
}
