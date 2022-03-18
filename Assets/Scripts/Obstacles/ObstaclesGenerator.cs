using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
	private Array _possibleObstaclesTypes = null;
	private List<ObstacleSlot> _obstacleSlots = new List<ObstacleSlot>();


	private void Start()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			_obstacleSlots.Add(transform.GetChild(i).GetComponent<ObstacleSlot>());
		}
	}

	public void Generate()
	{
		ResetSlots();

		_possibleObstaclesTypes = Enum.GetNames(typeof(ObstacleType));
		foreach (var obstacleType in _possibleObstaclesTypes)
		{
			var obstacleCount = UnityEngine.Random.Range(0, 5);
			var obstacleIndex = (int)Enum.Parse(typeof(ObstacleType), obstacleType.ToString());
			while (obstacleCount > 0)
			{
				int obstaclePosition = UnityEngine.Random.Range(0, 5);
				if (_obstacleSlots[obstaclePosition].Free)
				{
					_obstacleSlots[obstaclePosition].Obstacle = (ObstacleType)obstacleIndex;
				}
				obstacleCount--;
			}
		}
	}

	private void ResetSlots()
	{
		foreach(var obstacleSlot in _obstacleSlots)
		{
			obstacleSlot.Obstacle = ObstacleType.empty;
		}
	}
}
