using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public Text plantNameText;
    public Text plantPriceText;
    public Image plantImg;
    public Image btnImage;
    public Text btnText;

    FarmManager fm;

    // Start is called before the first frame update
    void Start()
    {
        fm = FindObjectOfType<FarmManager>();

        InitializedUI();
    }

    public void BuyPlant()
    {
        fm.PickPlant(this);
    }

    void InitializedUI()
    {
        plantNameText.text = plant.plantName;
        plantPriceText.text = "$" + plant.buyPrice;
        plantImg.sprite = plant.icon;
    }

    public Sprite GetPlantIcon()
    {
        return plantImg.sprite;
    }
   
}
