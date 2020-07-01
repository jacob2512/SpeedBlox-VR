using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof(Collider))]
public class EmptyCube : MonoBehaviour,
IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
	int index;
	bool gazedAt;
	bool selected;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetGazedAt(true);
    }

	public void OnPointerExit(PointerEventData eventData)
    {
        SetGazedAt(false);        
    }

	public void OnPointerDown(PointerEventData eventData)
    {
        SetSelected(true);
    }

	public void OnPointerUp(PointerEventData eventData)
    {
        SetSelected(false);        
    }

	//called by event trigger system
	public void SetGazedAt (bool currentGazedAt)
	{
		if(gazedAt != currentGazedAt) 
			gazedAt = currentGazedAt;
	}

	//called by event trigger system
	public void SetSelected (bool isSelected)
	{
		if(selected != isSelected)
			selected = isSelected;
	}

	public void SetIndex(int idx)
	{
		index = idx;
	}

}