using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    Text count;
    int pCounter = 0;
    GameObject popcornPU;
    Text popcornText;
    int sCounter = 0;
    GameObject sunflowerPU;
    Text sunflowerText;
    int tCounter = 0;
    GameObject tomatoPU;
    Text tomatoText;

    // Start is called before the first frame update
    void Start()
    {
        popcornPU = transform.GetChild(1).gameObject;
        popcornText = popcornPU.transform.GetChild(1).GetComponent<Text>();
        popcornText.text = "x" + pCounter.ToString();
        sunflowerPU = transform.GetChild(2).gameObject;
        sunflowerText = sunflowerPU.transform.GetChild(1).GetComponent<Text>();
        sunflowerText.text = "x" + sCounter.ToString();
        tomatoPU = transform.GetChild(3).gameObject;
        tomatoText = tomatoPU.transform.GetChild(1).GetComponent<Text>();
        tomatoText.text = "x" + tCounter.ToString();
    }

    public void Count(string plantName)
    {
        //counter++;
        //count.text = counter.ToString(); 
        if(plantName == "Corn")
        {
            pCounter++;
            popcornText.text = "x" + pCounter.ToString();
        } else if (plantName == "Sunflower")
        {
            sCounter++;
            sunflowerText.text = "x" + sCounter.ToString();
        } else if (plantName == "Tomato")
        {
            tCounter++;
            tomatoText.text = "x" + tCounter.ToString();
        }
    }

}
