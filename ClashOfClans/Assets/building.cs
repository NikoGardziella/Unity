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
        // Debug.Log("test0");
        var possibleEnemy = Physics.OverlapSphere(transform.position, attackRange);
        for (var i = 0; i < possibleEnemy.Length; i++)
        {
            //  Debug.Log("test1");
            if (possibleEnemy[i].gameObject.layer == 8)
            {
                //  Debug.Log("test2");
                var myInformation = gameObject.GetComponent<properties>(); // this might not work
                var Properties = possibleEnemy[i].gameObject.GetComponent<properties>();
                //  Debug.Log("test2.1");
                if (Properties.team != myInformation.team)
                {
                    //   Debug.Log("test3");
                    if ((Properties.airType == true && airAttack == true) || (Properties.groundType == true && groundAttack == true))
                    {
                     //   Debug.Log("test4");
                        Target = possibleEnemy[i].gameObject;
                        return;
                    }
                }
            }
        }
        // Target = GameObject.Find("Target");
    }
  
    void Start()
    {
     //   Debug.Log("start");
        var myInformation = gameObject.GetComponent<properties>();
         Target = null;
        attackTimer = attackRatio;
        findObjective();
    }

    void Update()
    {
        if(attackTimer >= attackRatio)
        {
           // Debug.Log("attackTimer >= attackRatio");
            if(Target && Vector3.Distance(Target.transform.position, gameObject.transform.position) <= attackRange)
            {
             //   Debug.Log("attack");
                attack();
                attackTimer = 0f;
            }
           // Debug.Log("find obj"); // this should be after else but for some reason its nor working
           // findObjective();
            else
            {
             //   Debug.Log("find obj");
                findObjective();
            }
        }
        else
        {
          //  Debug.Log("attack timer ++");
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
