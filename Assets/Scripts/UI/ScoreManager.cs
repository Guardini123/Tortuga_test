using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
	[SerializeField] private TMP_Text _topScoreText;
	[SerializeField] private TMP_Text _userNameText;

	private int _score;
	private int _topScore;
	private string _userName;

	[SerializeField] private UserLoadSaver _loadSaver;


	public int Score
	{
		get
		{
			return _score;
		}
		set
		{
			_score = value;
			_scoreText.text = _score.ToString();
		}
	}


	public int TopScore
	{
		get
		{
			return _topScore;
		}
		set
		{
			_topScore = value;
			_topScoreText.text = "top: " + _topScore.ToString();
		}
	}


	public string UserName
	{
		get
		{
			return _userName;
		}
		set
		{
			_userName = value;
			_userNameText.text = "Hello, " + _userName.ToString() + "!";
		}
	}


	private void Awake()
    {
		_loadSaver.OnDataLoad.AddListener(() => {
			Score = 0;
			TopScore = _loadSaver.CurrentTopScore();
			UserName = _loadSaver.CurrentUser;
		});
    }

	public void AddScore(int value)
	{
		Score += value;
	}


	public void CheckScore()
	{
		_loadSaver.NewTopScore(Score);
	}
}
