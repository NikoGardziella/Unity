using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
	public GameObject unit;
	private RectTransform rectTransform;
	private RaycastHit rchit;
	public bool UnitDrop = false;
	public Button UnitButton;
	public int Radistance = 10;
	private Vector3 Point;
	public LayerMask layermask;

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;


	void Start()
	{
		Button btn = UnitButton.GetComponent<Button>();
		btn.onClick.AddListener(AddUnit);
	}

	void AddUnit()
	{
		if (!UnitDrop)
		{
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
			Debug.Log("!Unitdrop");
			UnitDrop = true;
			return;
			
		}

		if (UnitDrop)
		{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
			Debug.Log("Unitdrop");
			UnitDrop = false;
			return;
		}
		Debug.Log("clicked");
		return;
	}




	public void Update()
	{


		if (Input.GetMouseButtonDown(0) && UnitDrop == true)
		{

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, layermask.value))
			{
				Point = hit.point;
				Instantiate(unit, Point, Quaternion.identity);
			}

			
		}
	
	}

}