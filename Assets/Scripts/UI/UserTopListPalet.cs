using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UserTopListPalet : MonoBehaviour
{
    [SerializeField] private TMP_Text _userNameText;
    [SerializeField] private TMP_Text _userScoreText;


    public void Set(string userName, int userScore)
	{
        _userNameText.text = userName;
        _userScoreText.text = userScore.ToString();
	}
}
