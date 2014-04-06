using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {

	public Texture cursorImage;
	
	// Use this for initialization
	void Start () 
	{
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void OnGUI () 
	{
		Vector3 mousePos = Input.mousePosition;
		Rect pos = new Rect(mousePos.x,Screen.height - mousePos.y,cursorImage.width,cursorImage.height);
		GUI.Label(pos,cursorImage);
	}
}
