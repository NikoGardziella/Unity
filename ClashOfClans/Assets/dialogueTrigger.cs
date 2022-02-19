using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
	public dialogue dialogue;

	public void triggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

	private void OnCollisionEnter(Collision collision)
	{
	
		Debug.Log("on collidr enter");
		Destroy(gameObject);
		if(collision.gameObject.tag == "unitMelee")
		{
			Debug.Log("tag collider");
			triggerDialogue();
		}

	}
}
