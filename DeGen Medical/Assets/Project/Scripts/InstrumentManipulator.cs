using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstrumentManipulator : MonoBehaviour
{
 //Initializing default value for instrument length and diameter 
    private int Value = 45;
    private double Value1 = 6.5;

    [Header("Length Value ")]
    public Text TextObject = null;

    [Header("Diameter Value")]
    public Text TextObject1 = null;

    // Instialization for Instrument Manupulation
    [Header("Instrument Tooltip")]
    [SerializeField] GameObject item1;
    [SerializeField] GameObject item2;
    [SerializeField] GameObject item3;

    [Header("Instrument Model")]
    [SerializeField] GameObject Model1;
    [SerializeField] GameObject Model2;
    [SerializeField] GameObject Model3;

    Vector3 temp;
 //------------------------------------------------------------------------------------------------------------
 // Increment length and diameter 
    public void Increment()
    {
        Debug.Log("increment");
        if (Value < 130)
        {
            if (TextObject != null)
            {             
                Value = Value + 5;
                TextObject.text = (Value.ToString()).ToString();
            }
        }
    }   
    public void IncrementDiameter()
    {
        if (Value1 < 10)
        {
            if (TextObject1 != null)
            {
                Value1 = Value1 + 0.5;
                TextObject1.text = (Value1.ToString()).ToString();
            }
        }
    }
 //------------------------------------------------------------------------------------------------------------
 // Decrement length and diameter 
    public void Decrement()
    {
        if (Value > 25)
        {
            if (TextObject != null)
            {
                if (Value != 0)
                {
                    Value = Value - 5;
                    TextObject.text = (Value.ToString()).ToString();
                }
            }
        }
    }
    public void Decrementdiameter()
    {
        if (Value1 > 4)
        {
            if (TextObject1 != null)
            {
                if (Value1 != 0)
                {
                    Value1 = Value1 - 0.5;
                    TextObject1.text = (Value1.ToString()).ToString();
                }
            }
        }
    }
//------------------------------------------------------------------------------------------------------------
// Instrument Manupulator Code from Hear:
    public void scalepositive()
    {
        if (Value1 < 10)
        {
            temp = item1.transform.localScale;
            temp.x += 0.005f;
            temp.z += 0.005f;
            item1.transform.localScale = temp;

            temp = item2.transform.localScale;
            temp.x += 0.005f;
            temp.z += 0.005f;
            item2.transform.localScale = temp;

            temp = item3.transform.localScale;
            temp.x += 0.005f;
            temp.z += 0.005f;
            item3.transform.localScale = temp;
        }
    }
    public void scaleNegative()
    {
        if (Value1 > 4)
        {
            temp = item1.transform.localScale;
            temp.x -= 0.005f;
            temp.z -= 0.005f;
            item1.transform.localScale = temp;

            temp = item2.transform.localScale;
            temp.x -= 0.005f;
            temp.z -= 0.005f;
            item2.transform.localScale = temp;

            temp = item3.transform.localScale;
            temp.x -= 0.005f;
            temp.z -= 0.005f;
            item3.transform.localScale = temp;
        }
    }
    public void scaleUp()
    {
        if (Value < 130)
        {
            temp = item1.transform.localScale;
            temp.y += 0.01145f;
            item1.transform.localScale = temp;

            temp = item2.transform.localScale;
            temp.y += 0.01145f;
            item2.transform.localScale = temp;

            temp = item3.transform.localScale;
            temp.y += 0.01145f;
            item3.transform.localScale = temp;
        }
    }
    public void scaleDown()       
    {
        if (Value > 25)
        {
            temp = item1.transform.localScale;
            temp.y -= 0.01145f;
            item1.transform.localScale = temp;

            temp = item2.transform.localScale;
            temp.y -= 0.01145f;
            item2.transform.localScale = temp;

            temp = item3.transform.localScale;
            temp.y -= 0.01145f;
            item3.transform.localScale = temp;
        }
    }
//------------------------------------------------------------------------------------------------------------
    public void ItemCell1()
    {
        Model1.SetActive(!Model1.activeInHierarchy);
    }
    public void ItemCell2()
    {
        Model2.SetActive(!Model2.activeInHierarchy);
    }
    public void ItemCell3()
    {
        Model3.SetActive(!Model3.activeInHierarchy);
    }
 //------------------------------------------------------------------------------------------------------------
    public void ClearLengthAndDiameter()
    {
        TextObject.text = "45";
        TextObject1.text = "6.5";
        item1.transform.localScale = new Vector3(1, 1, 1);
        item2.transform.localScale = new Vector3(1, 1, 1);
        item3.transform.localScale = new Vector3(1, 1, 1);
        Value = 45;
        Value1 = 6.5;
    }
 //------------------------------------------------------------------------------------------------------------
    public void ClearInstruments()
    {
        Model1.SetActive(false);
        Model2.SetActive(false);
        Model3.SetActive(false);
        GameObject.Find("Item Cell 1").transform.Find("BG").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        GameObject.Find("Item Cell 2").transform.Find("BG").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        GameObject.Find("Item Cell 3").transform.Find("BG").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        GameObject.Find("Item Cell 1").transform.Find("Measure Button").gameObject.SetActive(false);
        GameObject.Find("Item Cell 2").transform.Find("Measure Button").gameObject.SetActive(false);
        GameObject.Find("Item Cell 3").transform.Find("Measure Button").gameObject.SetActive(false);
    }
}
//------------------------------------------------------------------------------------------------------------
