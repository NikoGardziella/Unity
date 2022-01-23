using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTrigger : MonoBehaviour
{
    
    public string team = "red";
    public Vector3 Direction = Vector3.zero;

    void Update()
    {
        
    }

    /*
    ** Modify x and z values to change the direction of units movement
    */
    private void OnTriggerEnter(Collider other)
    {
        var Properties = other.gameObject.GetComponent<properties>();
        var Unit = other.gameObject.GetComponent<Unit>();

        if(Unit && Properties)
        {
            Debug.Log(other.gameObject.name);
            if(Properties.team == team)
            {
                Debug.Log(other.gameObject.name);
                Unit.destination = Direction;
            }
        }
    }
}
