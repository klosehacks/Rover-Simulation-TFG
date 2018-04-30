using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlerCursor : MonoBehaviour {

	public Texture2D _basicCursor;
	public Texture2D _otherCursor;
	public CursorMode _cursorMode = CursorMode.Auto;
	public Vector2 _hotSpot = Vector2.zero;

	void Start ()
	{
		setBasicCursorTexture ();
	}

	// Al cambiar el cursor sale un warnign debido a la importación//

	public void setBasicCursorTexture()
	{
		//Cursor.SetCursor (_basicCursor,_hotSpot,_cursorMode);
	}

	public void setOtherCursorTexture()
	{
		//Cursor.SetCursor (_otherCursor,_hotSpot,_cursorMode);
	}
}
