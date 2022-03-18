using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObstacleType
{
	empty,
	cube
}


public class ObstacleSlot : MonoBehaviour
{
	[SerializeField] private GameObject CubePrefab;

	private ObstacleType _obstacle;
	public ObstacleType Obstacle
	{
		get
		{
			return _obstacle;
		}
		set
		{
			_obstacle = value;
			instantiateNewObstacle(_obstacle);
		}
	}


	public bool Free => transform.childCount > 0 ? false : true;


	private void instantiateNewObstacle(ObstacleType obstacleType)
	{
		if (transform.childCount > 0)
		{
			GameObject.Destroy(transform.GetChild(0).gameObject);
		}

		GameObject instantiatedGO = null;
		switch (_obstacle)
		{
			case ObstacleType.empty:
				return;
			case ObstacleType.cube:
				instantiatedGO = Instantiate(CubePrefab, transform);
				break;
			default:
				break;
		}
		instantiatedGO.transform.localPosition = Vector3.zero;
		/*instantiatedGO.transform.localScale = Vector3.one;*/
	}
}
