using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler
{
	public GameObject unit;
	public GameObject holdingThing;
	private RectTransform rectTransform;
	private RaycastHit rchit;
	public bool UnitDrop = false;
	public Image image;



	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("OnpointerDown1");
		if (!UnitDrop)
		{
			image.gameObject.SetActive(true);
			UnitDrop = true;
		}

		if (UnitDrop)
		{
			image.gameObject.SetActive(false);
			UnitDrop = false;
		}
	}

	/* private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}
	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
	{
		Debug.Log("OnBeginDrag");
		//throw new System.NotImplementedException();
	}

	void IDragHandler.OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta;
	}

	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
	{
		Debug.Log("OnEndDrag");
		//throw new System.NotImplementedException();
	}



	public void spawnAndHoldUnit(GameObject unitPrefab)
	{

		holdingThing = Instantiate(unitPrefab) as GameObject;
	} */

	public void Update()
	{





		/*	if (holdingThing)
			{
				rchit = new RaycastHit();
				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rchit, 1000f))
				{
					holdingThing.transform.position = rchit.point;

					if (Input.GetMouseButtonUp(0)) //  && rchit.transform.gameObject.tag == "Ground"
					{
						holdingThing = null;
					}
				}

			}

			if (Input.GetMouseButtonDown(0))
			{

				//holdingThing = null;
				spawnAndHoldUnit(unit);
			}  */
	}

}
