using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public int teamNumber = 2;
    public string[] teams;
    public Color[] teamColor;
    public GameObject vicotryUi;
    public TextEditor TeamName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyTeam(string team)
    {
        int i = 0;
        Debug.Log("function DestroyTeam               !!!!!!!!!!!!!!!!!!");
        while (i < teams.Length)
        {
            if(teams[i] == team)
            {
                teams[i] = "";
                break;
            }
            i++;
        }
        teamNumber--;

        if(teamNumber == 1)
        {
            i = 0;
            while (i < teams.Length)
            {
                if(teams[i] != "")
                {
                    teamWin(teams[i], i);
                }
                i++;
            }
        }
    }

    void teamWin(string team, int showColor)
    {
        Debug.Log("team" + team);
        var newScale = vicotryUi.transform.localScale;
        newScale.x = newScale.x + 1f;
        vicotryUi.transform.localScale = newScale;
        Time.timeScale = 0;
        vicotryUi.transform.Find("TeamName").GetComponent<TextEditor>().text = team;
        vicotryUi.transform.Find("TeamName").GetComponent<Material>().color = teamColor[showColor];

    }
}
