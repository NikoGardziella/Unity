using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
	public dialogue dialogue;
	public DialogueManager dialogueManager;
	public DragAndDrop dragAndDrop;
	public DragAndDropRanged dragAndDropRanged;

	public void triggerDialogue()
	{
		dialogueManager.StartDialogue(dialogue);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "main")
		{
			dragAndDropRanged.rangedUnitCount += 2;
			dragAndDropRanged.rangedCounter.text = dragAndDropRanged.rangedUnitCount.ToString();
			dragAndDrop.meleeUnitCount += 2;
			dragAndDrop.meleeCounter.text = dragAndDrop.meleeUnitCount.ToString();
			Debug.Log("tag collider");
			Destroy(gameObject);
			triggerDialogue();
		}

	}
}
