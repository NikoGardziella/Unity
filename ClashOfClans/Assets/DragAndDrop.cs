using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
	private GameObject unit;
	private RectTransform rectTransform;
	private RaycastHit rchit;
	static public bool UnitDrop = false;
	public Button UnitButton;
	// public int Radistance = 10;
	private Vector3 Point;
	public LayerMask layermask;
	public string unitSelect;
	public GameObject meleeUnit;
	public GameObject rangedUnit;
	public GameObject ground;

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
		Debug.Log("name:" + name);
		if (unitSelect == "unitMelee")
		{
			unit = meleeUnit;
			//unit = GameObject.Find("unitMeleeBlue");
		}
		 if (unitSelect == "unitRanged")
		{
			unit = rangedUnit;
			//unit = GameObject.Find("unitRangedBlue");
		}
		if (!UnitDrop)
		{
			Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
			Debug.Log(UnitDrop);
			UnitDrop = true;

			return;
		}

		if (UnitDrop)
		{
			Cursor.SetCursor(null, Vector2.zero, cursorMode);

			Debug.Log(UnitDrop);
			UnitDrop = false;
			return;
		}
		Debug.Log("clicked");
		return;
	}




	void Update()
	{
	
		if (Input.GetMouseButtonDown(0) && UnitDrop == true)
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
				Debug.Log("unit: " + unit);
				Instantiate(unit, Point, Quaternion.identity);
			}

			
		}
	
	}

}
