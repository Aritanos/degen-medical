using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    Object[] scans;
    Object[] items;
    public GameObject scanObjectCellCollection;
    public GameObject itemObjectCellCollection;
    public GameObject scanCell;
    public GameObject itemCell;

    void Start()
    {
        //loadScanMenu();
        //loadItemMenu();
    }

    void loadScanMenu()
    {
        scans = Resources.LoadAll("Scans", typeof(Sprite));
        GameObject[] objectCell = new GameObject[scans.Length];

        for (int i = 0; i < scans.Length; i++)
        {
            GameObject clone;
            clone = Instantiate(scanCell);
            
            objectCell[i] = clone;
            objectCell[i].transform.parent = scanObjectCellCollection.transform;

            objectCell[i].transform.localPosition = new Vector3 (1,1,1);
            objectCell[i].transform.localScale = new Vector3 (1,1,1);

            RectTransform rt = objectCell[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(200, 200);

            //TO DO: Remove this code while working on NEXT and PREVIOUS buttons
            objectCell[i].SetActive(false);
          
        }
    }

     void loadItemMenu()
    {
        
        items = Resources.LoadAll("Items", typeof(Sprite));
        GameObject[] objectCell = new GameObject[items.Length];

        for (int i = 0; i < items.Length; i++)
        {
            GameObject clone;
            clone = Instantiate(itemCell);

            objectCell[i] = clone;
            objectCell[i].transform.parent = itemObjectCellCollection.transform;

            objectCell[i].transform.localPosition = new Vector3 (1,1,1);
            objectCell[i].transform.localScale = new Vector3 (1,1,1);

            RectTransform rt = objectCell[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(200, 200);

            //TO DO: Remove this code while working on NEXT and PREVIOUS buttons
            objectCell[i].SetActive(false);
          
        }
        
    }

}


