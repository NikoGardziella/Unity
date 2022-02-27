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
	private Vector3 Point;
	public LayerMask layermask;
	public GameObject unitMelee;
	public GameObject ground;

	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
	public DragAndDropRanged dragAndDropRanged;
	public int meleeUnitCount;
	public Text meleeCounter;

	void Start()
	{
		meleeUnitCount = 1;
		meleeCounter.text = meleeUnitCount.ToString();
		Button btn = UnitButton.GetComponent<Button>();
		btn.onClick.AddListener(AddUnit);


	}

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
			if (Physics.Raycast(ray, out hit, layermask.value) && meleeUnitCount > 0)
			{
				Point = hit.point;
				var NewPos = Point;
				NewPos.y = ground.transform.position.y;
				Point = NewPos; 


				Debug.Log("point" + Point);
				meleeUnitCount--;
				meleeCounter.text = meleeUnitCount.ToString();
				Instantiate(unitMelee, Point, Quaternion.identity);
			}

			
		}
	
	}

}
