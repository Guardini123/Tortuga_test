using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopListUsersController : MonoBehaviour
{
    [SerializeField] private GameObject _userPalet;
	[SerializeField] private Transform _contentContainer;

	[SerializeField] private UserLoadSaver _loadSaver;


	private void Start()
	{
		Init(_loadSaver.AllUsers);
	}


	public void Init(List<UserInfo> users)
	{
		foreach (var user in users)
		{
			var paletGO = GameObject.Instantiate(_userPalet, _contentContainer);
			paletGO.GetComponent<UserTopListPalet>().Set(user.Name, user.TopScore);
		}
	}
}
