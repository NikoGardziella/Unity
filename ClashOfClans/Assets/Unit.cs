using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
   public enum state
	{
		inActive, attack, moving
	}
	state _state = state.inActive;

	//Movement
	public float velocity = 6f;
	public Vector3 destination;

	//Fighting
	public float detectionRange = 12f;
	public float detectionRate = 0.1f;
	public float attackRange = 10f;
	public GameObject attackGameObjectArrow;
	public GameObject attackGameObjectMelee;
	public GameObject attackGameObjectTower;
	public float attackRatio = 1f;
	public bool airAttack = true;
	public bool groundAttack = true;
	private GameObject Target = null;
	private float attackTimer = 0f;
	private GameObject ground;
	public bool unitIdle = false;

	// State
	// public bool stateInactive = true;
	// public bool stateMoving;
	// public bool stateAttack;
	public Animator animator;
	public float invocationTime = 0.25f; // wait time
	// public var currentState : state = state.inactive;

	// private var myInfo : properties;

	void Start()
	{
		velocity = Random.Range(6.0f, 7.5f);
		var myInfo = gameObject.GetComponent<properties>();
		attackTimer = attackRatio;
		if (gameObject.tag == "unitMelee")
		animator.SetTrigger("idle");
		InvokeRepeating("checkState", invocationTime, detectionRate);
	}

	void Update()
	{
		attackTimer += Time.deltaTime;
		if(_state != state.inActive)
		{
			if (_state == state.moving)
			{
				animator.SetTrigger("run");
				transform.LookAt(new Vector3(destination.x, 0, destination.z) + new Vector3(transform.position.x, transform.position.y, transform.position.z)); // Object looks direction where it goes
				if (unitIdle == false)
				{
				transform.Translate(Vector3.forward * velocity * Time.deltaTime);
				}

			}
			else if (_state == state.attack)
			{
				if (Target)
				{
					if (attackTimer >= attackRatio)
					{
						if (Target.tag == "Tower") 
						{
							if (Vector3.Distance(gameObject.transform.position, Target.transform.position) <= 3)
							{
								unitIdle = false;
								attack();
								attackTimer = 0;
							}
						}
						if (Vector3.Distance(gameObject.transform.position, Target.transform.position) <= attackRange)
						{

							unitIdle = false;
							attack();
							attackTimer = 0;
						}
						else 
						{
							transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z)); // .y missgin Target?
							transform.Translate(Vector3.forward * velocity * Time.deltaTime);
						} 
					}

				}
				else
				{
					checkState();
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
						//if((Properties.airType == true && groundAttack == true) || (Properties.groundType == true && airAttack == true)) // for flying units
						//{
							Target = PossibleEnemys[i].gameObject;
							_state = state.attack;
							return;
						//}
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

		animator.SetTrigger("attack");

		if(gameObject.tag == "unitRanged")
		{
			var myInfo = gameObject.GetComponent<properties>();
			var shoot = Instantiate(attackGameObjectArrow, transform.position, Quaternion.identity);
			var shootInfo = shoot.GetComponent<Projectile>();
			shootInfo.objective = Target;
			shootInfo.projectileOfTeam = myInfo.team;
		}
		if (gameObject.tag == "Tower")
		{
			var myInfo = gameObject.GetComponent<properties>();
			var shoot = Instantiate(attackGameObjectTower, transform.position, Quaternion.identity);
			var shootInfo = shoot.GetComponent<Projectile>();
			shootInfo.objective = Target;
			shootInfo.projectileOfTeam = myInfo.team;
		}
		if (gameObject.tag == "unitMelee")
		{
			var myInfo = gameObject.GetComponent<properties>();
			var shoot = Instantiate(attackGameObjectMelee, transform.position, Quaternion.identity);
			var shootInfo = shoot.GetComponent<Projectile>();
			shootInfo.objective = Target;
			shootInfo.projectileOfTeam = myInfo.team;
		}

	}


}
