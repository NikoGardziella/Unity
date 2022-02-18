using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class properties : MonoBehaviour
{
    public GameObject GameController1; // To main tower
    public int currentHealth = 100;
    public string team = "blue";

    public int maxHealth = 100;
    public GameObject healthBar;
    public GameObject deathEffect;

    public bool airType;
    public bool groundType;
    public Animator animator;
    public Unit Unit;

    void Start()
    {
        maxHealth = currentHealth;
        healthBar = Instantiate(healthBar, transform.position, Quaternion.identity);
    }
    private IEnumerator waitForAnimation()
	{
        yield return new WaitForSeconds(2);
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

        healthBar.transform.LookAt(Camera.main.transform.position);
        healthBar.transform.position = gameObject.transform.position + Vector3.up;

        if (currentHealth <= 0)
        {
            if (gameObject.tag == "unitMelee")
            {

                Unit.velocity = 0f;
                animator.SetTrigger("die");
                StartCoroutine(waitForAnimation());
               // Destroy(healthBar);
               //Destroy(gameObject);
                

            }
            var myinfo = gameObject.GetComponent<properties>(); //to main tower
            //GameController1.GetComponent<gameController>().DestroyTeam(myinfo.team); // to main tower Doesnt contine after this
            currentHealth = 0;
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(healthBar);
            Destroy(gameObject);
        }
    }
}
