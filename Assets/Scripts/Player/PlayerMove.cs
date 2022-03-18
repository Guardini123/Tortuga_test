using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    float _playerYSpeed = 1f;
    float _playerZSpeed = 2f;

    public float PlayerYSpeed => _playerYSpeed;
    public float PlayerZSpeed => _playerZSpeed;

    Vector3 _playerPosition = new Vector3();
    Vector3 _cameraPosition = new Vector3();


	void FixedUpdate()
    {
        _playerPosition.Set(
            transform.position.x,
            transform.position.y + _playerYSpeed * Time.fixedDeltaTime,
            transform.position.z + _playerZSpeed * Time.fixedDeltaTime
            );
        transform.position = _playerPosition;

        _cameraPosition.Set(
            _camera.position.x,
            _camera.position.y + _playerYSpeed * Time.fixedDeltaTime,
            _camera.position.z + _playerZSpeed * Time.fixedDeltaTime
            );
        _camera.position = _cameraPosition;
    }

}
