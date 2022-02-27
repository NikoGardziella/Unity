using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragAndDropRanged : MonoBehaviour
{
	private RectTransform rectTransform;
	private RaycastHit rchit;
	static public bool UnitDropRanged = false;
	public Button UnitButton;
	// public int Radistance = 10;
	private Vector3 Point;
	public LayerMask layermask;
	public GameObject rangedUnit;
	public GameObject ground;
	public DragAndDrop DragAndDrop;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public int rangedUnitCount;
	public Text rangedCounter;

	void Start()
	{
		
		rangedUnitCount = 1;
		rangedCounter.text = rangedUnitCount.ToString();
		Button btn = UnitButton.GetComponent<Button>();
		btn.onClick.AddListener(AddUnit);


	}
	// make two scirpts. Melee and ranged. changed Bool to another script everytime button is pressed


	void AddUnit()
	{

		if (!UnitDropRanged)
		{
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
			Debug.Log(UnitDropRanged);
			DragAndDrop.UnitDropMelee = false;
			UnitDropRanged = true;

			return;
		}

		if (UnitDropRanged)
		{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);

			Debug.Log(UnitDropRanged);
			UnitDropRanged = false;
			return;
		}
		Debug.Log("clicked");
		return;
	}




	void Update()
	{

		if (Input.GetMouseButtonDown(0) && UnitDropRanged == true)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, layermask.value) && rangedUnitCount > 0)
			{
				Point = hit.point;
				var NewPos = Point;
				NewPos.y = ground.transform.position.y + 1f;
				Point = NewPos;
				Debug.Log("point" + Point);
				rangedUnitCount--;
				rangedCounter.text = rangedUnitCount.ToString();
				Instantiate(rangedUnit, Point, Quaternion.identity);
			}


		}

	}

}
