using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerTeam : MonoBehaviour
{

    public GameObject GameController1;

    void Update()
    {
        var myinfo = gameObject.GetComponent<properties>();
        if (myinfo.currentHealth <= 0)
        {
                GameController1.GetComponent<gameController>().DestroyTeam(myinfo.team);
        }
   }

}
