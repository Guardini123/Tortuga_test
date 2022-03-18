using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlider : MonoBehaviour 
{
    [SerializeField] private Slider _movementSlider;
    [SerializeField] private float _multiplier;
    private Vector3 _newPlayerPos = new Vector3();
    private float _startPlayerX;


    void Start()
    {
        _startPlayerX = transform.position.x;
        _movementSlider.onValueChanged.AddListener(OnSliderChangeValue);
    }


    public void OnSliderChangeValue(float value)
	{
        _newPlayerPos.Set(
            _startPlayerX + value * _multiplier,
            transform.position.y,
            transform.position.z
            );
        transform.position = _newPlayerPos;
	}
}
