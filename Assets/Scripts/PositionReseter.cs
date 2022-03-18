using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReseter : MonoBehaviour
{
	[SerializeField] private Transform _camera;
	[SerializeField] private Transform _player;
	private PlayerMove _playerMoveComp;

	[SerializeField] private List<Transform> _steps = new List<Transform>();

	private Transform _firstStep;
	private Transform _lastStep;

	private List<Transform> _transformsToMove = new List<Transform>();

	private Vector3 _nextFirstStepPos = new Vector3();
	private Vector3 _nextTransformPos = new Vector3();


	private void Start()
	{
		_playerMoveComp = _player.gameObject.GetComponent<PlayerMove>();

		foreach (var t in _steps)
		{
			_transformsToMove.Add(t);
		}
		_transformsToMove.Add(_camera);
		_transformsToMove.Add(_player);
	}


	private void OnTriggerEnter(Collider other)
	{
		_firstStep = _steps[0];
		_lastStep = _steps[_steps.Count - 1];

		// move first step
		_nextFirstStepPos.Set(
			0,
			_lastStep.position.y + _playerMoveComp.PlayerYSpeed,
			_lastStep.position.z + _playerMoveComp.PlayerZSpeed
			);
		_firstStep.position = _nextFirstStepPos;

		_firstStep.GetComponent<ObstaclesGenerator>().Generate();

		// when move all + camera + player
		foreach (var t in _transformsToMove)
		{
			_nextTransformPos.Set(
				t.position.x,
				t.position.y - _playerMoveComp.PlayerYSpeed,
				t.position.z - _playerMoveComp.PlayerZSpeed
				);
			t.position = _nextTransformPos;
		}

		_steps.RemoveAt(0);
		_steps.Add(_firstStep);
	}
}
