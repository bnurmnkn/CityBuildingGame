using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacments : MonoBehaviour
{
    private bool currentyPlacing;
    private bool currentyBulldozering;

    private BuildingPresets curBuildingPreset;
    
    private float indicatorUpdateTime=0.05f;
    private float lastUpdateTime;

    private Vector3 curIndicatorPos;

    public GameObject PlacementIndicator;
    public GameObject BulldozerIndicator;

    public void BeginNewBuildingPlacement(BuildingPresets preset)
    {
        currentyPlacing=true;
        curBuildingPreset=preset;
        PlacementIndicator.SetActive(true);

    }
    void CancelBuildingPlacement()
    {
        currentyPlacing=false;
        PlacementIndicator.SetActive(false);

    }
    
    public void ToogleBulldozer()
    {
        currentyBulldozering=!currentyBulldozering;
        BulldozerIndicator.SetActive(currentyBulldozering);
    }
    private  void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CancelBuildingPlacement();
        }
        if(Time.time-lastUpdateTime>indicatorUpdateTime)
        {
            lastUpdateTime=Time.time;
            curIndicatorPos=Selector.instance.GetCurTilePosition();

            if(currentyPlacing)
            {
                PlacementIndicator.transform.position=curIndicatorPos;
            }
            else if(currentyBulldozering)
            {
                BulldozerIndicator.transform.position=curIndicatorPos;
            }

            
        }
        if(Input.GetMouseButtonDown(0)&& currentyPlacing)
            {
                PlaceBuilding();
            }
            else if(Input.GetMouseButtonDown(0)&&currentyBulldozering)
            {
                Bulldoze();
            }
       
    }
    void PlaceBuilding()
        {
            GameObject buildingObj=Instantiate(curBuildingPreset.prefab,curIndicatorPos,Quaternion.identity);
            CancelBuildingPlacement();

        }
    void Bulldoze()
    {

    }    


}
