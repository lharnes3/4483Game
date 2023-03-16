using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;
    SpriteRenderer plant;
    BoxCollider2D plantCollider;
    SpriteRenderer plantIcon;

    int plantGrowth = 0;
    float timer;

    SpriteRenderer currentPlot;

    PlantObject selectedPlant;
    FarmManager fm;
    HarvestManager hm;
    PowerUpManager pm;

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();
        fm = transform.parent.GetComponent<FarmManager>();
        hm = FindObjectOfType<HarvestManager>();
        pm = FindObjectOfType<PowerUpManager>();
        currentPlot = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantGrowth < selectedPlant.plantStages.Length - 1)
            {
                timer = selectedPlant.timeBetweenStages;
                plantGrowth++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown()
    {
        if(isPlanted)
        {
            if(plantGrowth == selectedPlant.plantStages.Length - 1 && !fm.isPlanting)
            {
                HarvestPlot();
            }
            
        }
        else if (fm.isPlanting && fm.chosenPlant.plant.buyPrice <= fm.money)
        {
            PlantPlot(fm.chosenPlant.plant);
        }
    }

    private void OnMouseOver()
    {
        if (fm.isPlanting)
        {
            if (isPlanted || fm.chosenPlant.plant.buyPrice > fm.money)
            {
                currentPlot.color = Color.red; 
            } else
            {
                currentPlot.color = Color.green;
            }
        }
    }

    private void OnMouseExit()
    {
        currentPlot.color = Color.white;
    }

    void HarvestPlot()
    {
        isPlanted = false;
        plant.gameObject.SetActive(false);
        fm.Purchases(selectedPlant.sellPrice);
        pm.Count(selectedPlant.plantName);
        hm.RemoveIcon(plant.sprite.name);
    }

    void PlantPlot(PlantObject newPlant)
    {
        selectedPlant = newPlant;
        isPlanted = true;
        fm.Purchases(-selectedPlant.buyPrice);
        plantGrowth = 0;
        UpdatePlant();
        timer = selectedPlant.timeBetweenStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plant.sprite = selectedPlant.plantStages[plantGrowth];
        plantCollider.size = plant.sprite.bounds.size;
        plantCollider.offset = new Vector2(0, plant.bounds.size.y/2);
        if (plantGrowth == selectedPlant.plantStages.Length - 1)
        {
            plantIcon = plant;
            hm.ShowIcon(plantIcon);
            selectedPlant.readyForHarvest = true;
        }
    }
}
