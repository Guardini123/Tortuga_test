using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Rigidbody))]
public class PlayerPhisics : MonoBehaviour
{
    [SerializeField] private float _gravity = -9.8f;
	[SerializeField] private Rigidbody _rb;
	private Vector3 _phisicsImpulse = new Vector3();

	public UnityEvent OnCollide;
	public UnityEvent OnCollideStep;
	public UnityEvent OnCollideSpike;


	void Start()
    {
        Physics.gravity = Vector3.up * _gravity * 2;
    }


	public void EnableRigidbody()
	{
		_rb.isKinematic = false;
		_rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
	}


	private void OnCollisionEnter(Collision collision)
	{
		_phisicsImpulse.Set(
			0f,
			 _gravity * -1f,
			0f
			);
		_rb.AddForce(_phisicsImpulse, ForceMode.Impulse);

		OnCollide?.Invoke();

		if (collision.gameObject.tag == "step") OnCollideStep?.Invoke();

		if (collision.gameObject.tag == "spike") OnCollideSpike?.Invoke();
	}

}
