using UnityEngine;
using System.Collections.Generic;

public class UserCubeManager : MonoBehaviour 
{
	[SerializeField]
	private GameObject emptyCubeObject;
	
	[SerializeField]
	private GameObject playerCubeObject;

	private List<EmptyCube> emptyCubeList = new List<EmptyCube>();
	private List<PlayerCube> playerCubeList = new List<PlayerCube>();

	private List<int> playerGrid;
	private float blockWidth = 1.5f;
	private int gridLength = 3;
	private int gridDepth = 5;
	private int gridSize;

	void Start() 
	{
		gridSize = gridLength*gridLength;
	}

	private void updatePlayerGrid()
	{
		playerGrid.Clear();
		for (int i = 0; i < gridSize; i++) 
		{
			playerGrid.Add(0);
		}
		foreach (PlayerCube pCube in playerCubeList) 
		{
			playerGrid[pCube.getIndex()] = 1;
		}
	}

	public void UpdatePlayerCubes()
	{
		foreach(EmptyCube e in emptyCubeList)
		{
			foreach(PlayerCube p in playerCubeList) 
			{
				if( p.isSelected() && e.isGazedAt() ) 
				{
					//print (p.getIndex() + " -> " + e.getIndex());
					p.transform.position = e.transform.position;
					p.SetIndex( e.getIndex() );
					updatePlayerGrid();
				}
			}
		}
	}

	public int getTotalSize() 
	{
		return gridSize;
	}

	public Vector3 GetNewGridPosition(int gridIndex)
	{
		return new Vector3 (-blockWidth + blockWidth * (gridIndex % gridLength), 
							blockWidth - blockWidth * (int)(gridIndex / gridLength), 
							0f);
	}

	public void generateUserCubes()
	{
		playerGrid = new List<int>();
		List<int> indicies = new List<int>();

		for (int i = 0; i < gridSize; i++) 
		{
			playerGrid.Add (0);
		}

		int index1 = Random.Range (0, gridSize);
		int index2 = Random.Range (0, gridSize);

		while (index1 == index2) 
		{
			index2 = Random.Range (0, gridSize);
		}
		indicies.Add (index1);
		indicies.Add (index2);

		playerGrid[index1] = 1;
		playerGrid[index2] = 1;

		//load empty cubes
		for (int i = 0; i < gridSize; i++) 
		{
			GameObject emptyCube = (GameObject)Instantiate (emptyCubeObject);
			emptyCube.transform.SetParent (this.transform);
			emptyCube.transform.localPosition = 
				new Vector3 (-blockWidth + blockWidth * (i % gridLength), 
							blockWidth - blockWidth * (int)(i / gridLength), 
							gridDepth);
			EmptyCube e = emptyCube.GetComponent<EmptyCube>();
			e.SetIndex(i);
			//print(i);
			emptyCubeList.Add(e);
		}

		//load player cubes
		foreach (int index in indicies) 
		{
			GameObject playerCube = (GameObject)Instantiate (playerCubeObject);
			playerCube.transform.SetParent (this.transform);
			playerCube.transform.localPosition = 
				new Vector3 (-blockWidth + blockWidth * (index % gridLength),
							blockWidth - blockWidth * (int)(index / gridLength), 
							gridDepth);
			PlayerCube p = playerCube.GetComponent<PlayerCube>();
			p.SetIndex(index);
			//print(index);
			playerCubeList.Add (p);
		}
		//eC = GameObject.FindGameObjectsWithTag ("emptycube");
		//pC = GameObject.FindGameObjectsWithTag ("playercube");
		//print(eCubes.Count); //9
		//print(pCubes.Count); //2
	}

	public int getPlayerGrid(int index) 
	{
		return playerGrid[index];
	}
}