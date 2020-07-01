using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTextArea : MonoBehaviour 
{
	private bool visible;
	//debug
	private string debugtext;
	private GUIStyle debugStyle;
 	private Rect debugTextArea;

	void InitializeDebugArea()
	{
		visible = false;
		debugtext = "";
		debugTextArea = new Rect(10,10,Screen.width, Screen.height);

		debugStyle = new GUIStyle();
		debugStyle.fontSize = 60;		
		debugStyle.normal.textColor = Color.red;
	}

	void Start () 
	{
		InitializeDebugArea();
	}

	void OnGUI()
	{
		if(visible) GUI.Label(debugTextArea,debugtext,debugStyle);	
	}

	public string getPlayerGridString(List<int> grid) 
	{
		string playerGridString = 
		grid [0] + " " + grid [1] + " " +grid [2] + "\n"+
		grid [3] + " " + grid [4] + " " +grid [5] + "\n"+
		grid [6] + " " + grid [7] + " " +grid [8] + "\n"+		
		"\n"+
		"\n"+
		"\n";
		//print(playerGridString);
		//print(grid.Count);
		return playerGridString;
	}

	void Update()
	{
		//visible = true;
		//debugtext = getPlayerGridString(playerGrid);
	}

}
