using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResources : MonoBehaviour {

    public static Text countText;
    public static string Display;
    public static Text countTextAlt;
    public static string DisplayAlt;
    public static Dictionary<Allegiance,int> resourceDictionary;
    public enum Allegiance { Team1, Team2 };

    void Start () {
        resourceDictionary = new Dictionary<Allegiance, int>();
        resourceDictionary.Add(Allegiance.Team1, 0);
        resourceDictionary.Add(Allegiance.Team2, 0);
        Display = "Resources: ";
        DisplayAlt = "Enemy: ";
        countText = GameObject.Find("CountText").GetComponent<Text>();
        countTextAlt = GameObject.Find("EnemyCountText").GetComponent<Text>();
        SetResourceText(Allegiance.Team1);
        SetResourceText(Allegiance.Team2);
    }

    void Update () {
		
	}

    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    public static void SetResourceText(Allegiance allegience)
    {
        if(allegience == Allegiance.Team1)
        {
            countText.text = Display + resourceDictionary[allegience].ToString();
        }
        else
        {
            countTextAlt.text = DisplayAlt + resourceDictionary[allegience].ToString();
        }
    }

    public static void AddResource(int resources, Allegiance allegience)
    {
        resourceDictionary[allegience] = resourceDictionary[allegience] + resources;
        SetResourceText(allegience);
    }

    public static int GetResourceCount(Allegiance allegience)
    {
        return resourceDictionary[allegience];
    }
}
