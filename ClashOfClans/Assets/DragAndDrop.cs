using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
	private RectTransform rectTransform;
	private RaycastHit rchit;
	public bool UnitDropMelee = false;
	public Button UnitButton;
	// public int Radistance = 10;
	private Vector3 Point;
	public LayerMask layermask;
	public GameObject unitMelee;
	public GameObject ground;

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public DragAndDropRanged dragAndDropRanged;

	void Start()
	{
		Button btn = UnitButton.GetComponent<Button>();
		btn.onClick.AddListener(AddUnit);


	}
	// make two scirpts. Melee and ranged. changed Bool to another script everytime button is pressed


	void AddUnit()
	{

		if (!UnitDropMelee)
		{
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
			Debug.Log(UnitDropMelee);
			DragAndDropRanged.UnitDropRanged = false;
			UnitDropMelee = true;

			return;
		}

		if (UnitDropMelee)
		{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);
			Debug.Log(UnitDropMelee);
			UnitDropMelee = false;
			return;
		}
		Debug.Log("clicked");
		return;
	}




	void Update()
	{
	
		if (Input.GetMouseButtonDown(0) && UnitDropMelee == true)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, layermask.value))
			{
				Point = hit.point;
				var NewPos = Point;
				NewPos.y = ground.transform.position.y + 1f;
				Point = NewPos;


				Debug.Log("point" + Point);
				Instantiate(unitMelee, Point, Quaternion.identity);
			}

			
		}
	
	}

}
