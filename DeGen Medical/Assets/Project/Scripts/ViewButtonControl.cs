using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewButtonControl : MonoBehaviour
{
    [Header("Item Cells ")]
    public GameObject itemObjectCellCollection;

    [Header("Item Titles ")]
    public GameObject ItemTitle;
   
    private int ModelIndex = 2;
    private int ModelIndex1 = 2;
//----------------------------------------------------------------------------------------------------------------------
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            itemObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
        }
        for (int i = 0; i < 3; i++)
        {
            ItemTitle.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
//----------------------------------------------------------------------------------------------------------------------
    public void NextItemButton()
    {
        for (int i = 0; i < itemObjectCellCollection.transform.childCount; i++)
        {
            itemObjectCellCollection.transform.GetChild(i).gameObject.SetActive(false);
        }

        ModelIndex = ModelIndex + 3;

        if (ModelIndex < itemObjectCellCollection.transform.childCount)
        {
            for (int i = ModelIndex - 2; i <= ModelIndex; i++)
            {
                itemObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            ModelIndex = 2;

            for (int i = ModelIndex - 2; i <= ModelIndex; i++)
            {
                itemObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
//----------------------------------------------------------------------------------------------------------------------
    public void NextItemTitle()
    {
        for (int j = 0; j < ItemTitle.transform.childCount; j++)
        {
            ItemTitle.transform.GetChild(j).gameObject.SetActive(false);
        }

        ModelIndex1 = ModelIndex1 + 3;

        if (ModelIndex1 < ItemTitle.transform.childCount)
        {
            for (int j = ModelIndex1 - 2; j <= ModelIndex1; j++)
            {
                ItemTitle.transform.GetChild(j).gameObject.SetActive(true);
            }
        }
        else
        {
            ModelIndex1 = 2;

            for (int j = ModelIndex1 - 2; j <= ModelIndex1; j++)
            {
                ItemTitle.transform.GetChild(j).gameObject.SetActive(true);
            }
        }
    }
//----------------------------------------------------------------------------------------------------------------------
    public void PreviousItemButton()
    {
        for (int i = 0; i < itemObjectCellCollection.transform.childCount; i++)
        {
            itemObjectCellCollection.transform.GetChild(i).gameObject.SetActive(false);
        }

        ModelIndex = ModelIndex - 3;

        if (ModelIndex >= 2)
        {
            for (int i = ModelIndex - 2; i <= ModelIndex; i++)
            {
                itemObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            ModelIndex = itemObjectCellCollection.transform.childCount - 1;

            for (int i = ModelIndex - 2; i <= ModelIndex; i++)
            {
                itemObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
//----------------------------------------------------------------------------------------------------------------------

    public void PreviousItemTitle()
    {
        for (int j = 0; j < ItemTitle.transform.childCount; j++)
        {
            ItemTitle.transform.GetChild(j).gameObject.SetActive(false);
        }

        ModelIndex1 = ModelIndex1 - 3;

        if (ModelIndex1 >= 2)
        {
            for (int j = ModelIndex1 - 2; j <= ModelIndex1; j++)
            {
                ItemTitle.transform.GetChild(j).gameObject.SetActive(true);
            }
        }
        else
        {
            ModelIndex1 = ItemTitle.transform.childCount - 1;

            for (int j = ModelIndex1 - 2; j <= ModelIndex1; j++)
            {
                ItemTitle.transform.GetChild(j).gameObject.SetActive(true);
            }
        }
    }
 //----------------------------------------------------------------------------------------------------------------------
}






//public GameObject scanObjectCellCollection;
//public GameObject scanTitle;
////public GameObject itemObjectCellCollection;
//private int ModelIndex = 2;

//void Start()
//{
//  //Models[0].SetActive(true);
//  for(int i=0; i<3; i++)
//  {
//      scanObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
//      //itemObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
//  }
//}

//public void NextButton()
//{
//    if(!scanObjectCellCollection.transform.Find("Obliquo").gameObject.activeInHierarchy)
//    {
//        for(int i=0; i<=3; i++) 
//        {
//            scanObjectCellCollection.transform.GetChild(i).gameObject.SetActive(false);
//            scanTitle.transform.GetChild(i).gameObject.SetActive(false);
//        }
//        scanObjectCellCollection.transform.GetChild(3).gameObject.SetActive(true);
//        scanTitle.transform.GetChild(3).gameObject.SetActive(true);
//    }

//    // for(int i=0; i<scanObjectCellCollection.transform.childCount; i++) 
//    // {
//    //    scanObjectCellCollection.transform.GetChild(i).gameObject.SetActive(false);
//    // }

//    // ModelIndex = ModelIndex + 3;

//    // if(ModelIndex < scanObjectCellCollection.transform.childCount)
//    // {
//    //     //Models[ModelIndex].SetActive(true);

//    //     for(int i=ModelIndex-2; i<=ModelIndex; i++) 
//    //     {
//    //     scanObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
//    //     }
//    // }
//    // else
//    // {
//    //     ModelIndex = 2;
//    //     //Models[ModelIndex].SetActive(true);

//    //     for(int i=ModelIndex-2; i<=ModelIndex; i++) 
//    //     {
//    //     scanObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
//    //     }

//    // }

//}

//public void PreviousButton()
//{
//   if(scanObjectCellCollection.transform.Find("Obliquo").gameObject.activeInHierarchy)
//    {
//        for(int i=0; i<=3; i++) 
//        {
//            scanObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
//            scanTitle.transform.GetChild(i).gameObject.SetActive(true);
//        }
//        scanObjectCellCollection.transform.GetChild(3).gameObject.SetActive(false);
//        scanTitle.transform.GetChild(3).gameObject.SetActive(false);
//    }
//    // for(int i=0; i<scanObjectCellCollection.transform.childCount; i++) 
//    // {
//    //    scanObjectCellCollection.transform.GetChild(i).gameObject.SetActive(false);
//    // }

//    // ModelIndex = ModelIndex - 3;

//    // if(ModelIndex >=2)
//    // {
//    //     //Models[ModelIndex].SetActive(true);

//    //     for(int i=ModelIndex-2; i<=ModelIndex; i++) 
//    //     {
//    //     scanObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
//    //     }
//    // }
//    // else
//    // {
//    //     ModelIndex = scanObjectCellCollection.transform.childCount-1;

//    //     //Models[ModelIndex].SetActive(true);

//    //     for(int i=ModelIndex-2; i<=ModelIndex; i++) 
//    //     {
//    //     scanObjectCellCollection.transform.GetChild(i).gameObject.SetActive(true);
//    //     }

//    // }

//}