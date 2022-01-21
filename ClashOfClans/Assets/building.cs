using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class building : MonoBehaviour
{
    public GameObject attackGameobject;
    public double attackRatio = 0.5f;
    public float attackRange = 5.0f;

    public bool airAttack = true;
    public bool groundAttack = true;

    private double attackTimer = 0f;
    private GameObject Target;

    public Transform attackOrigin;
 
      

    void findObjective ()
    {
        var possibleEnemy = Physics.OverlapSphere(transform.position, attackRange);
        for (var i = 0; i < possibleEnemy.Length; i++)
        {
            if(possibleEnemy[i].gameObject.layer == 8)
            {
                var myInformation = gameObject.GetComponent<properties>(); // this might not work
                var Properties = possibleEnemy[i].gameObject.GetComponent<properties>();
                if (Properties.team != myInformation.team)
                {
                    if((Properties.airType == true && airAttack == true) || (Properties.groundType == true && groundAttack == true))
                    {
                        Target = possibleEnemy[i].gameObject;
                        return;
                    }
                }
            }
        }
        Target = GameObject.Find("Target");
    }
  
    void Start()
    {
        Target = null;
        attackTimer = attackRatio;
        findObjective();
    }

    void Update()
    {
        if(attackTimer >= attackRatio)
        {
            if(Vector3.Distance(Target.transform.position, gameObject.transform.position) <= attackRange)
            {
                attack();
                attackTimer = 0f;
            }
            else
            {
                findObjective();
            }
        }
        else
        {
            attackTimer += Time.deltaTime;
        }
    }

    void attack()
    {
        var shoot = Instantiate(attackGameobject, transform.position, Quaternion.identity);
        var shootInfo = shoot.GetComponent<Projectile>();
        shootInfo.objective = Target; 
    }
}
