using UnityEngine;
using System.Collections.Generic;

public class EnemyCubeManager : MonoBehaviour
{	
	[SerializeField]
	private GameObject enemyCubeObject;

	[SerializeField]
	private Material scoreMat;

	private List<GameObject> enemyCubeList = new List<GameObject>();

	private float startPoint = 6f;
	private float vanishingPoint = 2f;

	public void GenerateEnemyCube(Vector3 newPosition)
	{
		GameObject enemyCube = Instantiate(enemyCubeObject);
		enemyCube.transform.SetParent (this.transform);
		enemyCube.transform.localPosition = newPosition;
		enemyCubeList.Add (enemyCube);
	}

	public void UpdateEnemyCubeMaterial ()
	{
		foreach (GameObject enemyCube in enemyCubeList) 
		{
			enemyCube.GetComponent<Renderer>().material = scoreMat;
		}
	}

	public void MoveEnemyCubes(float levelSpeed)
	{
		foreach(GameObject enemyCube in enemyCubeList) 
		{
			Vector3 currentPosition = enemyCube.transform.localPosition;
			currentPosition.z -= levelSpeed;//0//levelSpeed
			enemyCube.transform.localPosition = currentPosition;
		}
	}

	public void DestroyEnemyCubes ()
	{
		//print ("destroy blocks");
		if (enemyCubeList != null) 
		{
			foreach (GameObject enemyCube in enemyCubeList) 
			{
				Destroy (enemyCube);
			}
		}
		enemyCubeList.Clear();
	}

	public bool isBeforeStartPoint()
	{		
		float wallZPosition = enemyCubeList[0].transform.position.z;
		return (wallZPosition <= startPoint);
	}

	public bool isBeforeVanishingPoint()
	{
		float wallZPosition = enemyCubeList[0].transform.position.z;
		return (wallZPosition <= vanishingPoint);
	}

}