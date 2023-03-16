using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem chosenPlant;
    public bool isPlanting = false;
    public int money = 100;
    public Text currency;

    // Start is called before the first frame update
    void Start()
    {
        currency.text = "$" + money;
    }


    public void PickPlant(PlantItem newPlant)
    {
        if (chosenPlant == newPlant)
        {
            chosenPlant.btnImage.color = Color.green;
            chosenPlant.btnText.text = "Buy";
            chosenPlant = null;
            isPlanting = false;
        }
        else
        {
            if(chosenPlant != null)
            {
                chosenPlant.btnImage.color = Color.green;
                chosenPlant.btnText.text = "Buy";
            }
            chosenPlant = newPlant;
            chosenPlant.btnImage.color = Color.red;
            chosenPlant.btnText.text = "Cancel";
            isPlanting = true;
        }
    }

    public void Purchases(int price)
    {
        money += price;
        currency.text = "$" + money;
    }

    public Sprite PlantIcon()
    {
        return chosenPlant.GetPlantIcon();
    }
}
