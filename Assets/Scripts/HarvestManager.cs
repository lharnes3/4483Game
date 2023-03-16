using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarvestManager : MonoBehaviour
{
    Image plantImg;

    GameObject icon1;
    Image image1;
    GameObject icon2;
    Image image2;
    GameObject icon3;
    Image image3;

    int numIcons = 3;

    PlantObject selectedPlant;
    FarmManager fm;


    // Start is called before the first frame update
    void Start()
    {
        icon1 = transform.GetChild(0).gameObject;
        image1 = icon1.transform.GetChild(0).GetComponent<Image>();
        icon2 = transform.GetChild(1).gameObject;
        image2 = icon2.transform.GetChild(0).GetComponent<Image>();
        icon3 = transform.GetChild(2).gameObject;
        image3 = icon3.transform.GetChild(0).GetComponent<Image>();
        image1.gameObject.SetActive(false);
        image1.enabled = false;
        image2.gameObject.SetActive(false);
        image2.enabled = false;
        image3.gameObject.SetActive(false);
        image3.enabled = false;
    }


    public void ShowIcon(SpriteRenderer plant)
    {
        if (!image1.isActiveAndEnabled)
        {
            image1.sprite = plant.sprite;
            image1.gameObject.SetActive(true);
            image1.enabled = true;
        } else if (!image2.isActiveAndEnabled)
        {
            image2.sprite = plant.sprite;
            image2.gameObject.SetActive(true);
            image2.enabled = true;
        } else if (!image3.isActiveAndEnabled) 
        {
            image3.sprite = plant.sprite;
            image3.gameObject.SetActive(true);
            image3.enabled = true;
        } else
        {
            Debug.Log("no more room");
        }
    }

    public void RemoveIcon(string imgName)
    {
        if (image1.sprite.name == imgName && image1.isActiveAndEnabled)
        {
            image1.gameObject.SetActive(false);
            image1.enabled = false;
        } else if ((image2.sprite.name == imgName && image2.isActiveAndEnabled) || (image1.sprite.name == imgName && image1.isActiveAndEnabled))
        {
            image2.gameObject.SetActive(false);
            image2.enabled = false;
        } else if ((image3.sprite.name == imgName && image3.isActiveAndEnabled) || (image1.sprite.name == imgName && image1.isActiveAndEnabled) || (image2.sprite.name == imgName && image2.isActiveAndEnabled))
        {
            image3.gameObject.SetActive(false);
            image3.enabled = false;
        } else
        {
            Debug.Log("not on board");
        }
    }

}
