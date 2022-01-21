using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity = 3.0f; // double doesnt work with Vector3 line 18.
    public double hitBoxRadius = 0.25f;
    public GameObject objective = null;

    public int damage = 30;


    // Update is called once per frame
    void Update()
    {
        if(objective)
        {
            gameObject.transform.LookAt(objective.transform);
            gameObject.transform.Translate(Vector3.forward * velocity * Time.deltaTime);
            if(Vector3.Distance(gameObject.transform.position, objective.transform.position) <= hitBoxRadius)
            {
                var Properties = objective.GetComponent<properties>();
                Properties.currentHealth -= damage;

                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
