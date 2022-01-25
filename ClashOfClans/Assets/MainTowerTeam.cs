using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerTeam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var myinfo = gameObject.GetComponent<properties>();
        var controller = gameObject.transform.Find("GameController").GetComponent<gameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
