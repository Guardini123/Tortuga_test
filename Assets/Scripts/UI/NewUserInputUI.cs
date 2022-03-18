using System.Collections;
using UnityEngine;
using TMPro;


public class NewUserInputUI : MonoBehaviour
{
	[SerializeField] private TMP_InputField _inputField;
	[SerializeField] private UserLoadSaver _loadSaver;

	public void NewUserName()
	{
		_loadSaver.NewUser(_inputField.text);
	}
}