using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class UserInfo
{
    public string Name = "";
    public int TopScore = 0;
    public bool LastVisited = false;

    public UserInfo(string name)
    {
        Name = name;
        LastVisited = true;
    }
}


public class UserLoadSaver : MonoBehaviour
{
    private string _currentUser = "";
    private List<UserInfo> _allUsers = new List<UserInfo>();

    public string CurrentUser => _currentUser == "" ? "unregistered user" : _currentUser;
    public int CurrentTopScore() 
    { 
        foreach(var user in _allUsers)
		{
            if (_currentUser == user.Name) 
            {
                return user.TopScore;
            }
		}
        return 0;
    }
    public List<UserInfo> AllUsers => _allUsers;

    public UnityEvent OnDataLoad;
    public UnityEvent OnDataSaved;


    void Start()
    {
        Load();
    }


    public void NewUser(string userName)
	{
        bool foundUser = false;
        foreach (var user in _allUsers)
        {
            user.LastVisited = false;
            if (user.Name == userName)
            {
                user.LastVisited = true;
                foundUser = true;
            }
        }
        if (!foundUser)
        {
            _allUsers.Add(new UserInfo(userName));
        }
        Save();
    }


    public void NewTopScore(int topScore)
	{
        foreach (var user in _allUsers)
        {
            if ((_currentUser == user.Name) && (topScore > user.TopScore))
            {
                user.TopScore = topScore;
                break;
            }
        }
        Save();
    }


    public void Load()
    {
        Debug.Log("Start load users info!");

        string path = Application.persistentDataPath + "/user.txt";
        try { 
            StreamReader reader = new StreamReader(path);
            while (reader.Peek() >= 0)
            {
                _allUsers.Add(JsonUtility.FromJson<UserInfo>(reader.ReadLine()));
            }
            reader.Close();
        } catch (Exception ex)
		{
            Debug.Log(ex);
		}

        foreach (var user in _allUsers)
        {
            if (user.LastVisited)
            {
                _currentUser = user.Name;
            }
        }
        OnDataLoad?.Invoke();
        Debug.Log("Done!");
    }


    public void Save()
	{
        Debug.Log("Start saving users info!");
        foreach(var user in _allUsers)
		{
            Debug.Log(user.Name + user.TopScore.ToString() + user.LastVisited.ToString());
		}
        Debug.Log("Start saving users info!");

        string path = Application.persistentDataPath + "/user.txt";
        StreamWriter writer = new StreamWriter(path);
        foreach(var user in _allUsers)
		{
            var userInJson = JsonUtility.ToJson(user);
            writer.WriteLine(userInJson);
        }
        writer.Close();

        OnDataSaved?.Invoke();
        Debug.Log("Done!");
    }
}
