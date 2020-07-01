using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private EnemyCubeManager enemyCubeManager;
	[SerializeField]
	private UserCubeManager userCubeManager;
	[SerializeField]
	private GameObject cardboardButton;
	[SerializeField]
	private TextAsset LevelAsset;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private GameObject restart;
	[SerializeField]
	private GameObject title;
	[SerializeField]
	private AudioClip startMusic;
	[SerializeField]
	private AudioClip gameMusic;
	[SerializeField]
	private AudioClip restartBeginMusic;
	[SerializeField]
	private AudioClip restartLoopMusic;
	[SerializeField]
	private AudioSource audioSource;

	private int currentLevel;
	private int numberOfLevels;
	private bool gameInProgress;
	private bool levelComplete;
	private float levelSpeed;
	private float speedFactor;

	private int score;
	private bool firstRun;
	//0 = mainmenu; 1 = gameplay; -1 = gameover
	private int currentState; 

	private string[] levelsData;

	private List<int> enemyGrid = new List<int>();

	void Start()
	{
		score = 0;
		currentLevel = 0;
		numberOfLevels = 0;
		gameInProgress = false;
		levelComplete = false;
		levelSpeed = 0;

		speedFactor = 0.3f; //0.3f

		currentState = 0;
		firstRun = true;

		showMainMenu();
		Input.multiTouchEnabled = false;
	}

	private bool cubesAreHitting ()
	{
		for (int i = 0; i < userCubeManager.getTotalSize(); i++) 
		{
			if (enemyGrid [i] == 1 && 
				userCubeManager.getPlayerGrid(i) == 1) 
			{
				return true;
			}
		}
		return false;
	}

	void Update()
	{
		if (gameInProgress) 
		{
			//Determine Pass or Loss
			if (enemyCubeManager.isBeforeStartPoint() && !levelComplete) 
			{
				if (cubesAreHitting()) //LOSS
				{
					endGame ();
					gameInProgress = false; //RESTART
				}
				else //PASS
				{
					UpdateCurrentScore();
					UpdateCurrentLevel();
					enemyCubeManager.UpdateEnemyCubeMaterial();
					levelComplete = true;
				}
			}

			//destroy and recreate cube wall after it has passed player
			if (enemyCubeManager.isBeforeVanishingPoint()) 
			{
				enemyCubeManager.DestroyEnemyCubes();
				InitializeStage(currentLevel);				
				levelComplete = false;
			}

			enemyCubeManager.MoveEnemyCubes(levelSpeed);
			userCubeManager.UpdatePlayerCubes();			
		}

		//continue music loop
		if(currentState == -1) 
		{
			if (!audioSource.isPlaying) 
			{                    
				playAudio(restartLoopMusic, true);
			}
		}
	}


	private void startLevel ()
	{
		//print (levelFile);

		currentLevel = 0;
		levelsData = LevelAsset.text.Split (',');
		numberOfLevels = int.Parse (levelsData [0]);
		
		InitializeStage(currentLevel);

		gameInProgress = true;
	}

	private void UpdateCurrentLevel()
	{
		currentLevel += 1;
		if(currentLevel >= numberOfLevels)
		{
			currentLevel = 0;
		}
	}

	private int charToInt (char c)
	{
		return System.Int32.Parse (c.ToString ());
	}

	private void InitializeStage(int currentLevel)
	{
		int offset = currentLevel * 3 + 1;
		char[] levelGrid = levelsData [offset + 1].ToCharArray ();

		levelSpeed = float.Parse (levelsData [offset + 2]) * speedFactor;

		enemyGrid.Clear();
		foreach(char c in levelGrid) 
		{
			enemyGrid.Add(charToInt(c));
		}

		for (int gridIndex = 0; gridIndex < userCubeManager.getTotalSize(); gridIndex++) 
		{
			if(enemyGrid[gridIndex] == 1)
			{
				enemyCubeManager.GenerateEnemyCube( 
					userCubeManager.GetNewGridPosition(gridIndex));
			}
		}

	}

	private void playAudio(AudioClip audioClip, bool doLoop) 
	{
		audioSource.clip = audioClip;
		audioSource.loop = doLoop;
		audioSource.Play();
	}

	private void endGame()
	{
		//print ("end game");
		currentState = -1;
		restart.SetActive(true);
		
		playAudio(restartBeginMusic, false);
	}

	private void UpdateCurrentScore()
	{
		//print("score");
		score++;
		scoreText.text = "score: " + score.ToString();
	}

	//(also) called on restart click 
	public void showMainMenu()
	{
		//print ("restart");
		currentState = 0;
		title.SetActive(true);
		restart.SetActive(false);

		enemyCubeManager.DestroyEnemyCubes();
		cardboardButton.SetActive(true);

		playAudio(startMusic, true);
	}

	//called on title click
	public void beginGame()
	{
		//print ("begin game");
		currentState = 1;
		title.SetActive(false);

		if (firstRun)
		{
			userCubeManager.generateUserCubes();
			firstRun = false;
		}
		startLevel();
		score = 0;
		scoreText.text = "score: " + score.ToString();

		cardboardButton.SetActive(false);

		playAudio(gameMusic, true);
	}

}