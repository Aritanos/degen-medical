using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//---------------------------------------------------------------------------------------------------------------------- 
public class ViewManager : MonoBehaviour
{
    [Header("Menu Cards")]
    [SerializeField] GameObject loadingMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject measureMenu;

    [Header("Scan And Item Cards")]
    [SerializeField] GameObject ScansCard;
    [SerializeField] GameObject ItemsCard;

    [Header("Scan And Item Buttons")]
    [SerializeField] GameObject ScansButton;
    [SerializeField] GameObject ItemsButton;

    [SerializeField] static bool scanClearAll;
    [SerializeField] static bool itemClearAll;

    private GameObject[] DicomCards;
    private GameObject[] BGCards;

    [Header("DiCom Viewer")]
    [Tooltip("DiCom Viewer intialization to display intial image in scan card menu")]
    [SerializeField] GameObject Dicom;
    [SerializeField] GameObject DicomCaution;
    [SerializeField] GameObject DicomViewerCollections;
    public GameObject coronalDicomViewer;
    public GameObject axialDicomViewer;
    public GameObject sagittalDicomViewer;
    public GameObject obliquoDicomViewer;

    private Vector3 coronalPos, axialPos, sagittalPos;

//---------------------------------------------------------------------------------------------------------------------  
    void Start()
    {
        StartCoroutine(LoadHomeMenu());
        // initializing initial position of Dicom
          coronalPos = coronalDicomViewer.transform.localPosition;
          axialPos = axialDicomViewer.transform.localPosition;
          sagittalPos = sagittalDicomViewer.transform.localPosition;           
    }
    public IEnumerator LoadHomeMenu()
    {
        yield return new WaitForSeconds(1f);
        loadingMenu.SetActive(true);
        LoadMainMenu();
    }
    public void LoadMainMenu()
    {
        loadingMenu.SetActive(false); ;
        mainMenu.SetActive(true);
        DicomViewerCollections.SetActive(true);        
    }
//----------------------------------------------------------------------------------------------------------------------
    void Update()
    {
        int DicomViewerCount = DicomViewerCollections.transform.childCount;
        if(DicomViewerCount<3)
        {
            DicomCaution.SetActive(false);
        }
    }
//----------------------------------------------------------------------------------------------------------------------     
    public void UICellSelector(GameObject BG)
    {
        if (BG.GetComponent<Image>().color == new Color32(28, 64, 149, 255))
        {
            if (ScansCard.activeSelf)
            {
                if(BG.name.Contains("Coronal"))
                {
                    coronalDicomViewer.SetActive(false);
                    coronalDicomViewer.transform.parent = BG.transform.parent;
                }
                else if(BG.name.Contains("Axial"))
                {
                    axialDicomViewer.SetActive(false);
                    axialDicomViewer.transform.parent = BG.transform.parent;
                }
                else if(BG.name.Contains("Sagittal"))
                {
                    sagittalDicomViewer.SetActive(false);
                    sagittalDicomViewer.transform.parent = BG.transform.parent;
                }
                 else if(BG.name.Contains("Obliquo"))
                {
                    obliquoDicomViewer.SetActive(false);
                    obliquoDicomViewer.transform.parent = BG.transform.parent;
                }
            }
            else
            {
                BG.transform.parent.Find("Measure Button").gameObject.SetActive(false);
            }
                BG.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        { 
            if (ScansCard.activeSelf)
             {
               
               if(DicomViewerCollections.transform.childCount<3)
               {
                    BG.GetComponent<Image>().color = new Color32(28, 64, 149, 255);
                    GameObject dicomViewer  = BG.transform.parent.GetChild(2).gameObject;
                    dicomViewer.SetActive(true);
                    dicomViewer.transform.parent = DicomViewerCollections.transform;
               }
               else
               {
                    StartCoroutine(DicomCautionDelay());
               }
             }
            else
            {
                BG.transform.parent.Find("Measure Button").gameObject.SetActive(true);
                BG.GetComponent<Image>().color = new Color32(28, 64, 149, 255);
            }
        }
    }
 //----------------------------------------------------------------------------------------------------------------------  
    public IEnumerator DicomCautionDelay()
    {
        DicomCaution.SetActive(true);
        yield return new WaitForSeconds(3f);
        DicomCaution.SetActive(false);
    }
  //---------------------------------------------------------------------------------------------------------------------- 
    public void ScanMenuController()
    {
        ScansCard.transform.position = ItemsCard.transform.position;
        ScansCard.transform.rotation = ItemsCard.transform.rotation;
        ScansCard.transform.localScale = ItemsCard.transform.localScale;
        ItemsCard.SetActive(false);
        ScansCard.SetActive(true);
    }
    public void ItemMenuController()
    {
        ItemsCard.transform.position = ScansCard.transform.position;
        ItemsCard.transform.rotation = ScansCard.transform.rotation;
        ItemsCard.transform.localScale = ScansCard.transform.localScale;
        ScansCard.SetActive(false);
        ItemsCard.SetActive(true);
    }
 //---------------------------------------------------------------------------------------------------------------------- 
    public void MeasureButton()
    {
        measureMenu.transform.position = ItemsCard.transform.position;
        measureMenu.transform.rotation = ItemsCard.transform.rotation;
        measureMenu.transform.localScale = ItemsCard.transform.localScale;
        mainMenu.SetActive(false);
        measureMenu.SetActive(true);
    }
    public void BackMeasureButton()
    {
        ItemsCard.transform.position = measureMenu.transform.position;
        ItemsCard.transform.rotation = measureMenu.transform.rotation;
        ItemsCard.transform.localScale = measureMenu.transform.localScale;
        measureMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
//---------------------------------------------------------------------------------------------------------------------- 
// Scan card clear button configuation
    public void ScanClearall()
    {
        DicomCards = GameObject.FindGameObjectsWithTag("DiCom");
        for (var i = 0; i < DicomCards.Length; i++)
        {
            if (DicomCards[i].name.Contains("Coronal"))
            {
                DicomCards[i].SetActive(false);
                DicomCards[i].transform.parent = GameObject.Find("Coronal").transform;
            }
            else if (DicomCards[i].name.Contains("Axial"))
            {
                DicomCards[i].SetActive(false);
                DicomCards[i].transform.parent = GameObject.Find("Axial").transform;
            }
            else if (DicomCards[i].name.Contains("Sagittal"))
            {
                DicomCards[i].SetActive(false);
                DicomCards[i].transform.parent = GameObject.Find("Sagittal").transform;
            }
            else if (DicomCards[i].name.Contains("Obliquo"))
            {
                DicomCards[i].SetActive(false);
                DicomCards[i].transform.parent = GameObject.Find("Obliquo").transform;
            }

        }
        BGCards = GameObject.FindGameObjectsWithTag("cellbg");
        foreach (GameObject BG in BGCards)
        {
           BG.transform.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        }
    }
  //---------------------------------------------------------------------------------------------------------------------- 
  // Scan card All button configuation
    public void ScanSetall()
    {
        DicomViewerCollections.SetActive(true);
        coronalDicomViewer.SetActive(true);
        coronalDicomViewer.transform.parent = DicomViewerCollections.transform;

        axialDicomViewer.SetActive(true);
        axialDicomViewer.transform.parent = DicomViewerCollections.transform;

        sagittalDicomViewer.SetActive(true);
        sagittalDicomViewer.transform.parent = DicomViewerCollections.transform;

        BGCards = GameObject.FindGameObjectsWithTag("cellbg");
        foreach (GameObject BG1 in BGCards)
        {
            BG1.transform.GetComponent<Image>().color = new Color32(28, 64, 149, 255);

        }
    }
 //---------------------------------------------------------------------------------------------------------------------- 
 // Scan card Reset button configuation
    public void ScanResetall()
    {
        coronalDicomViewer.SetActive(true);
        coronalDicomViewer.transform.parent = DicomViewerCollections.transform;

        axialDicomViewer.SetActive(true);
        axialDicomViewer.transform.parent = DicomViewerCollections.transform;

        sagittalDicomViewer.SetActive(true);
        sagittalDicomViewer.transform.parent = DicomViewerCollections.transform;

        coronalDicomViewer.transform.localPosition = coronalPos;
        axialDicomViewer.transform.localPosition = axialPos;
        sagittalDicomViewer.transform.localPosition = sagittalPos;

        BGCards = GameObject.FindGameObjectsWithTag("cellbg");
        foreach (GameObject BG in BGCards)
        {
            BG.transform.GetComponent<Image>().color = new Color32(28, 64, 149, 255);
        }
    }
}
//---------------------------------------------------------------------------------------------------------------------- 
