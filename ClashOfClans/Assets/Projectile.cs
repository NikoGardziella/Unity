using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity = 3.0f; // double doesnt work with Vector3 line 18.
    public double hitBoxRadius = 0.25f;
    public GameObject objective = null;
    public int damage = 30;

    public bool useDamageArea = false; // projectile causes damage in area when hit
    public int damageAreaRadius = 3;
    public string projectileOfTeam = "";


    // Update is called once per frame
    void Update()
    {
        if(objective)
        {
            gameObject.transform.LookAt(objective.transform);
            gameObject.transform.Translate(Vector3.forward * velocity * Time.deltaTime);
            if(Vector3.Distance(gameObject.transform.position, objective.transform.position) <= hitBoxRadius)
            {
                if (useDamageArea)
                {
                    var Properties = objective.GetComponent<properties>();
                    var possibleEnemy = Physics.OverlapSphere(transform.position, damageAreaRadius);
                    for (var i = 0; i < possibleEnemy.Length; i++)
                    {
                        if (possibleEnemy[i].gameObject.layer == 8)
                        {
                            var properties_target = possibleEnemy[i].gameObject.GetComponent<properties>();
                            if (projectileOfTeam != properties_target.team)
                            {
                                properties_target.currentHealth -= damage;
                            }
                        }
                    }
                }
                else
                {
                    var Properties = objective.GetComponent<properties>();
                    Properties.currentHealth -= damage;
                }
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
