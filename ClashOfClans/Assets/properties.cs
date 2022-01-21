using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class properties : MonoBehaviour
{

    public int currentHealth = 100;
    public string team = "blue";

    public int maxHealth = 100;
    public GameObject healthBar;
    public GameObject deathEffect;

    public bool airType;
    public bool groundType;

    void Start()
    {
        maxHealth = currentHealth;
        healthBar = Instantiate(healthBar, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < maxHealth)
        {
      
            var newScale = healthBar.transform.localScale;
            newScale.x = (currentHealth / 100f) * 1f;
            healthBar.transform.localScale = newScale;
        }
        else
        {
          /*  var newScale = healthBar.transform.localScale;
            newScale.x = 0;
            healthBar.transform.localScale = newScale; */
        }
        healthBar.transform.LookAt(Camera.main.transform.position);
        healthBar.transform.position = gameObject.transform.position + Vector3.up;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(healthBar);
            Destroy(gameObject);
        }
    }
}
