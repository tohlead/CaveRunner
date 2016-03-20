﻿using UnityEngine;
using System.Collections;

public class MapLoader : MonoBehaviour
{
	int[] mapData = {0,0,0,0,0,0,0,0,0,1,
					 0,0,0,0,0,0,0,0,1,1,
					 0,0,0,0,0,0,0,1,1,0,
					 0,0,0,0,0,0,1,1,1,0,
					 0,0,0,0,0,0,1,0,0,0,
					 0,0,0,0,1,1,1,0,0,0,
					 0,0,0,0,1,0,0,0,0,0,
					 0,1,1,1,1,0,0,0,0,0,
					 1,1,1,0,0,0,0,0,0,0,
					 1,1,0,0,0,0,0,0,0,0};

	const int MAP_WIDTH = 10;

	/////////////////////////////////
	// must assign in inspector
	public GameObject mapPiecePrefab;
	public GameObject redBallPrefab;
	public GameObject blueBallPrefab;
	/////////////////////////////////

	void Start()
	{
		CreateMap(mapData);
	}	

	const int MAP_WALL = 0;
	const int MAP_PATH = 1;

	const float MAP_BLOCK_WIDTH = 1;
	const float MAP_BLOCK_HEIGHT = 1;

	void CreateMap(int[] mapData)
	{
		int mapHeight = mapData.Length / MAP_WIDTH;

		for (int mapCount = 0; mapCount < 10; ++mapCount)
		{
			int mapStartPosX = mapCount * MAP_WIDTH;			
			int mapStartPosY = mapCount * mapHeight;

			if (mapCount > 0)
			{
				mapStartPosX -= mapCount * 1;
				mapStartPosY -= mapCount * 2;
			}

			for (int col = 0; col < mapHeight; ++col)
			{
				for (int row = 0; row < MAP_WIDTH; ++row)
				{
					Vector3 mapObjectCenterPosition = new Vector3(mapStartPosX + MAP_BLOCK_WIDTH * row, mapStartPosY + MAP_BLOCK_HEIGHT * (mapHeight - col - 1), 0);
					if (mapData[col * MAP_WIDTH + row] == MAP_WALL)
					{
						GameObject newWall = Instantiate(mapPiecePrefab) as GameObject;
						newWall.name = "MapPiece" + (col * MAP_WIDTH + row).ToString("000");
						newWall.transform.parent = transform;
						newWall.transform.localPosition = mapObjectCenterPosition;
					}
					else
					{
						int ballAppearRate = 30;
						int ballRandomValue = Random.Range(0, 100);

						if (ballRandomValue < ballAppearRate)
						{
							GameObject newBallObject = null;
							if (Random.Range(0, 100) % 2 == 0)
								newBallObject = Instantiate(redBallPrefab) as GameObject;
							else
								newBallObject = Instantiate(blueBallPrefab) as GameObject;

							newBallObject.transform.parent = transform;
							newBallObject.transform.localPosition = mapObjectCenterPosition;

							Rect randomRect = new Rect(-0.25f, -0.25f, 0.5f, 0.5f);
							float xPos = Random.Range(randomRect.xMin, randomRect.xMax);
							float yPos = Random.Range(randomRect.yMin, randomRect.yMax);

							newBallObject.transform.localPosition += new Vector3(xPos, yPos, 0);
						}
					}
				}
			}
		}
	}
}