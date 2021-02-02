using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DicomImageCount : MonoBehaviour
{
    [Header("Scan Slider")]
    public Slider slider2;

    [Header("Scan Slider Text")]
    public Text slider2Text;
   
    private float totalScanCount,currentScan;
 //----------------------------------------------------------------------------------------------------------------
    void Start()
    {       
        slider2.GetComponent<Slider>().value = 0;
    }
//----------------------------------------------------------------------------------------------------------------
    void Update()
    {
        totalScanCount= slider2.GetComponent<Slider>().value;
        currentScan = slider2.maxValue;

        slider2Text.text = (totalScanCount +"/"+ currentScan).ToString();
    }
}

