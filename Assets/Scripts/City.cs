using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class City : MonoBehaviour
{
    public int Money;
    public int Day;
    public int curPopulation;
    public int curJobs;
    public int curFood;
    public int maxPopulation;
    public int maxJobs;
    public int incomePerJobs;
    public TextMeshProUGUI statsText;
    public List<Buildings> building=new List<Buildings>();
    public static City instance;
    private void Awake()
    {
        instance=this;

    }
    public void OnPlaceBuilding(Buildings buildings){
        Money+=buildings.preset.cost;
        maxPopulation+=buildings.preset.population;
        maxJobs+=buildings.preset.jobs;  
        building.Add(buildings);    
        UpdateStatText(); 
    }
    public void OnRemoveBuilding(Buildings buildings){
       
        maxPopulation-=buildings.preset.population;
        maxJobs-=buildings.preset.jobs;  
        building.Remove(buildings);  
        Destroy(buildings.gameObject);  
        UpdateStatText(); 
    }
    void UpdateStatText()
    {
        statsText.text = string.Format("Day: {0} Money: {1} Pop: {2} / {3} Jobs:{4} /{5} Food: {6}", new object[7] { Day, Money, curPopulation, maxPopulation, curJobs, maxJobs, curFood });

    }

    public void EndTurn()
    {
        Day++;
        CalculateMoney();
        CalculatePopulation();
        CalculateJobs();
        CalculateFood();
        UpdateStatText();


    }

    void CalculateMoney()
    {
        Money += curJobs * incomePerJobs;
        foreach (Buildings building in building)
            Money -= building.preset.cosPerTurn;

    }
    void CalculatePopulation()
    {
        if(curFood>=curPopulation && curPopulation< maxPopulation)
        {
            curFood -= curPopulation / 4;
            curPopulation = Mathf.Min(curPopulation + (curFood / 4), maxPopulation);
        }
        else if(curFood<curPopulation)
        {
            curPopulation = curFood;
        }

    }
    void CalculateJobs()
    {
        curJobs = Mathf.Min(curPopulation, maxJobs);

    }

    void CalculateFood()
    {
        curFood = 0;
        foreach (Buildings building in building)
            curFood += building.preset.food;

    }



    
}
