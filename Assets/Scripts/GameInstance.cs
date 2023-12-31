using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInstance : MonoBehaviour
{
	private static GameInstance _instance;
	public static GameInstance Instance
	{
		get
		{
			if (!_instance)
			{
				_instance = FindObjectOfType<GameInstance>();
			}

			return _instance;
		}
	}
	public event Action<int> GoldChanged;
	public event Action<int> LevelChanged;


	public event Action GameStarted;
	public event Action GameEnded;
	public event Action Won;
	public event Action Lost;
	

	public bool IsGameStarted {get; private set;}

	public void StartGame()
	{
		IsGameStarted = true;
		GameStarted?.Invoke();
	}

	public void EndGame()
	{
		IsGameStarted = false;
		GameEnded?.Invoke();
	}
	private int _gold;
	public int Gold 
	{ 
		
		get =>_gold ;
		
		set 
		{
			_gold = value;
			GoldChanged?.Invoke(_gold);
		}
	}
	private int _level;
	public int Level
	{ 
		
		get =>_level ;
		
		set 
		{
			_level = value;
			LevelChanged?.Invoke(_level);
		}

	}
	public void LoadCurrentLevel()
	{
		SceneManager.LoadScene(0);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(0);
	}

	public void Win()
	{
		Level++;
		
        Debug.Log("win");
		EndGame();
		Won?.Invoke();
		
	}

	public void Lose()
	{
		// TODO Show lose screen
		Debug.Log("Lost!");
		EndGame();
		Lost?.Invoke();
	}

	private void Awake()
	{
		if (_instance && _instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
	}
}