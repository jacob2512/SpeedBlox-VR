using UnityEngine;

[RequireComponent (typeof(Collider))]
public class PlayerCube : MonoBehaviour
{
	[SerializeField]
	private Material upMat;
	
	[SerializeField]
	private Material overMat;
	
	[SerializeField]
	private Material downMat;

	private int index;
	private bool gazedAt;
	private bool selected;

	void Start ()
	{
		gazedAt = false;
		selected = false;
	}

	public bool isGazedAt() 
	{
		return gazedAt;
	}
	public bool isSelected() 
	{
		return selected;
	}	
	public int getIndex() 
	{
		return index;
	}

	private void SetGazedAt (bool currentGazedAt)
	{	
		//print("gazed: " + currentGazedAt);
		if(gazedAt != currentGazedAt) 
		{
			gazedAt = currentGazedAt;
			GetComponent<Renderer>().material = gazedAt ? overMat : upMat;
		}
	}

	private void SetSelected (bool isSelected)
	{
		//print("selected: " + isSelected);
		if(selected != isSelected) 
		{
			selected = isSelected;
			GetComponent<Renderer>().material = selected ? downMat : (gazedAt ? overMat : upMat);
		}
	}

	public void SetIndex(int idx)
	{
		index = idx;
	}

}