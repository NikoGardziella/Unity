using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
   public enum state
	{
		inActive, attack, moving
	}
	state _state = state.inActive;

	//Movement
	public float velocity = 6f;
	public GameObject destination;

	//Fighting
	public float detectionRange = 12f;
	public float detectionRate = 0.1f;
	public float attackRange = 10f;
	public GameObject attackGameObject;
	public float attackRatio = 1f;
	public bool airAttack = true;
	public bool groundAttack = true;
	private GameObject Target = null;
	private float attackTimer = 0f;

	// State
   // public bool stateInactive = true;
   // public bool stateMoving;
   // public bool stateAttack;

	public float invocationTime = 0.25f;
	// public var currentState : state = state.inactive;

	// private var myInfo : properties;

	void Start()
	{
		var myInfo = gameObject.GetComponent<properties>();
		attackTimer = attackRatio;
		InvokeRepeating("checkState", invocationTime, detectionRate);
	}

	void Update()
	{
		attackTimer += Time.deltaTime;
		if(_state != state.inActive)
		{
			if (_state == state.moving)
			{
				transform.LookAt(new Vector3(destination.transform.position.x, transform.position.y, destination.transform.position.z)); // Object looks direction where it goes
				transform.Translate(Vector3.forward * velocity * Time.deltaTime);
			}
			else if (_state == state.attack)
			{
				if (Target)
				{
					if (attackTimer >= attackRatio)
					{
						if (Vector3.Distance(Target.transform.position, gameObject.transform.position) <= attackRange)
						{
							attack();
							attackTimer = 0;
						}
						else
						{
							transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.y)); // .y missgin Target?
							transform.Translate(Vector3.forward * velocity * Time.deltaTime);
						}
					}
					else
					{
						checkState();
					}
				}
			}
		}
	}

	void checkState()
	{
		if(_state == state.moving)
		{
			var PossibleEnemys = Physics.OverlapSphere(transform.position, detectionRange); // Gameobjects in our range of detection

			for (var i = 0; i < PossibleEnemys.Length; i++)
			{
				if (PossibleEnemys[i].gameObject.layer == 8)
				{
					var Properties = PossibleEnemys[i].gameObject.GetComponent<properties>();
					var myInfo = gameObject.GetComponent<properties>();
					if (Properties.team != myInfo.team) // check that is other team
					{
						if((Properties.airType == true && groundAttack == true) || (Properties.groundType == true && airAttack == true))
						{
							Target = PossibleEnemys[i].gameObject;
							_state = state.attack;
							return;
						}
					}
				}
			}
		}
		else
		{
			if(Target == null)
			{
				_state = state.moving;
			}
		}

	}

	void attack()
	{
		var shoot = Instantiate(attackGameObject, transform.position, Quaternion.identity);
		var shootInfo = shoot.GetComponent<Projectile>();
		shootInfo.objective = Target;
	}
}
