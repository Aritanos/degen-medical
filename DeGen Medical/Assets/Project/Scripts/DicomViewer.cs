using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dicom;
using Dicom.Imaging;
using System.IO;
using System;
using TMPro;
using System.Runtime.InteropServices;

public class DicomViewer : MonoBehaviour
{
 
    public RawImage dicomImage;

    [Header("DicomViewer Prefabs")]
    public GameObject dicomViewer;

    [Header("Sliders")]
    public Slider dicomImageSlider;
    public Slider intensitySlider;

    private int intesityValue;
    private int datasetLength;

    [Header("Dropdown Text")]
    public TextMeshProUGUI dropDownText;

    [Header("Thumbnail")]
    public GameObject coronalThumbnail;
    public GameObject axialThumbnail;
    public GameObject sagittalThumbnail;
    public GameObject obliquoThumbnail;
    
    DicomFile dFile;

    private UnityEngine.Object[] dicomFiles;

    private List<Texture2D> CoronalImages = new List<Texture2D>();
    private List<Texture2D> SagittalImages = new List<Texture2D>();
    private List<Texture2D> AxialImages = new List<Texture2D>();
    private List<Texture2D> ObliquoImages = new List<Texture2D>();

 //-----------------------------------------------------------------------------------------------------------------
    public struct DicomImageFrame
    {
        string patientName;
        string anatomicalPlane;
        Texture2D imageFrame;

    public DicomImageFrame(string name, string plane, Texture2D image)
    {
            patientName = name;
            anatomicalPlane = plane;
            imageFrame = image;
    }

    public Texture2D GetTexture(string plane)
    {
        if (anatomicalPlane == plane)
        {
            return imageFrame;
        }
        else
            return null;
    }

    public string GetName()
    {
        return patientName;
    }

    }
//-----------------------------------------------------------------------------------------------------------------

    public List<DicomImageFrame> dicomImageFrameList = new List<DicomImageFrame>();

    // Start is called before the first frame update
    private void Start()
    {
        intensitySlider.GetComponent<Slider>().value = 5;
        dicomImage = GetComponent<RawImage>(); 

        if(coronalThumbnail.GetComponent<RawImage>().texture==null)
        {
            coronalThumbnail.GetComponent<RawImage>().texture = CoronalImages[0];
        }
        if(axialThumbnail.GetComponent<RawImage>().texture==null)
        {
            axialThumbnail.GetComponent<RawImage>().texture = AxialImages[0];
         }
        if(sagittalThumbnail.GetComponent<RawImage>().texture==null)
        {
            sagittalThumbnail.GetComponent<RawImage>().texture = SagittalImages[0];
         }
        if(obliquoThumbnail.GetComponent<RawImage>().texture==null)
        {
            obliquoThumbnail.GetComponent<RawImage>().texture = ObliquoImages[0];
        }
     }
 //-----------------------------------------------------------------------------------------------------------------
    public void Update()
    {
        //Displaying scan image depending on dropdown text
        String text = dropDownText.text;      
        if (text == "Coronal")
       {
            dicomImageSlider.maxValue = CoronalImages.Count;
            dicomViewer.GetComponentInChildren<RawImage>().texture = CoronalImages[(int)Math.Round(dicomImageSlider.value)];
        }
        else if (text == "Sagittal")
        {
            dicomImageSlider.maxValue = SagittalImages.Count;
            dicomViewer.GetComponentInChildren<RawImage>().texture = SagittalImages[(int)Math.Round(dicomImageSlider.value)];
        }
        else if (text == "Axial")
        {
            dicomImageSlider.maxValue = AxialImages.Count;
            dicomViewer.GetComponentInChildren<RawImage>().texture = AxialImages[(int)Math.Round(dicomImageSlider.value)];
        }
        else if (text == "Obliquo")
        {
            dicomImageSlider.maxValue = ObliquoImages.Count;
            dicomViewer.GetComponentInChildren<RawImage>().texture = ObliquoImages[(int)Math.Round(dicomImageSlider.value)];
         }

        //Setting intensity depending on slider value
        intesityValue = (int)Math.Round(intensitySlider.GetComponent<Slider>().value);
        switch(intesityValue)
        {
            case 9:
               dicomViewer.GetComponentInChildren<RawImage>().color = new UnityEngine.Color32(255, 255, 255, 230);
                break;
            case 8:
                dicomViewer.GetComponentInChildren<RawImage>().color = new UnityEngine.Color32(255, 255, 255, 255);
                break;
            case 7:
                dicomViewer.GetComponentInChildren<RawImage>().color = new UnityEngine.Color32(245, 245, 245, 255);
                break;
            case 6:
                dicomViewer.GetComponentInChildren<RawImage>().color = new UnityEngine.Color32(235, 235, 235, 255);
                break;
            case 5:
                dicomViewer.GetComponentInChildren<RawImage>().color = new UnityEngine.Color32(220, 220, 220, 255);
                break;
            case 4:
                dicomViewer.GetComponentInChildren<RawImage>().color = new UnityEngine.Color32(210, 210, 210, 255);
                break;
            case 3:
                dicomViewer.GetComponentInChildren<RawImage>().color = new UnityEngine.Color32(200, 200, 200, 255);
                break;
            case 2:
                dicomViewer.GetComponentInChildren<RawImage>().color = new UnityEngine.Color32(190, 190, 190, 255);
                break;          
            case 1:
                dicomViewer.GetComponentInChildren<RawImage>().color = new UnityEngine.Color32(180, 180, 180, 255);
                break;
        }
    }
//-----------------------------------------------------------------------------------------------------------------
    public int ImportData()
    {
        string path = Application.streamingAssetsPath;     
        dicomImageFrameList.Clear();
        if (Directory.Exists(path))
        {
            foreach(string file in Directory.GetFiles(path))
           {          
                if (Path.GetExtension(file) == ".dcm")
                {
                    if (file != null)
                    {
                        dFile = DicomFile.Open(file);
                    }

                    DicomImage dicomImage = new DicomImage(file);
                    string name = dFile.Dataset.Get<string>(DicomTag.PatientName);
                    string orient = CalculateOrientation(dFile.Dataset.Get<int[]>(DicomTag.ImageOrientationPatient, null));
                    Texture2D texture = dicomImage.RenderImage().AsTexture2D();

                    DicomImageFrame dicomImageFrame = new DicomImageFrame(name, orient, texture);
                    dicomImageFrameList.Add(dicomImageFrame);

                    datasetLength++;   
                }
            }

            LoadDicomViewer();
        }
        else
        {
            Debug.LogError("Directory is not Exist");
        }
        return datasetLength;
    }
 //-----------------------------------------------------------------------------------------------------------------
    private string CalculateOrientation(int[] imageOrientation)
    {
        if (imageOrientation!=null)
        {
            var vector1 = new Vector3(imageOrientation[0], imageOrientation[1], imageOrientation[2]);
            var vector2 = new Vector3(imageOrientation[3], imageOrientation[4], imageOrientation[5]);
            if ((vector1 == Vector3.up || vector1 == Vector3.down) && (vector2 == Vector3.back || vector2 == Vector3.forward))
                return "Sagittal";
            if ((vector1 == Vector3.right || vector1 == Vector3.left) && (vector2 == Vector3.back || vector2 == Vector3.forward))
            {
                return "Coronal";
            }
            if ((vector1 == Vector3.right || vector1 == Vector3.left) && (vector2 == Vector3.up || vector2 == Vector3.down))
            {
                return "Axial";
            }
            else
            {
                return "Obliquo";
            }
        }
        else
            return "Obliquo";
    }

    public void LoadDicomViewer()
    {
        int dicomImageCounter=0;
        foreach (DicomImageFrame dicomImage in dicomImageFrameList)
        {
            if(dicomImage.GetTexture("Coronal")!=null)
            {
                dicomImageCounter = dicomImageCounter+1;
                CoronalImages.Add(dicomImage.GetTexture("Coronal"));
                
            }
            if (dicomImage.GetTexture("Sagittal") != null)
            {
                dicomImageCounter = dicomImageCounter + 1;
                SagittalImages.Add(dicomImage.GetTexture("Sagittal"));
            }
            if (dicomImage.GetTexture("Axial") != null)
            {
                dicomImageCounter = dicomImageCounter + 1;
                AxialImages.Add(dicomImage.GetTexture("Axial"));
            }
            if (dicomImage.GetTexture("Obliquo") != null)
            {
                dicomImageCounter = dicomImageCounter + 1;
                ObliquoImages.Add(dicomImage.GetTexture("Obliquo"));
            }
        }        
    }
//-----------------------------------------------------------------------------------------------------------------
    public void CloseDicom()
    {
        if (gameObject.name.Contains("Coronal"))
        {
            GameObject dicomViewer = GameObject.Find("DiCom Viewer - Coronal");
            dicomViewer.SetActive(false);
            dicomViewer.transform.parent = GameObject.Find("Coronal").transform;
            GameObject.Find("Coronal").transform.GetChild(0).GetComponent<Image>().color = new UnityEngine.Color32(255, 255, 255, 255);
        }
        else if (gameObject.name.Contains("Axial"))
        {
            GameObject dicomViewer = GameObject.Find("DiCom Viewer - Axial");
            dicomViewer.SetActive(false);
            dicomViewer.transform.parent = GameObject.Find("Axial").transform;
            GameObject.Find("Axial").transform.GetChild(0).GetComponent<Image>().color = new UnityEngine.Color32(255, 255, 255, 255);
        }
        else if (gameObject.name.Contains("Sagittal"))
        {
            GameObject dicomViewer = GameObject.Find("DiCom Viewer - Sagittal");
            dicomViewer.SetActive(false);
            dicomViewer.transform.parent = GameObject.Find("Sagittal").transform;
            GameObject.Find("Sagittal").transform.GetChild(0).GetComponent<Image>().color = new UnityEngine.Color32(255, 255, 255, 255);
        }
        else if (gameObject.name.Contains("Obliquo"))
        {
            GameObject dicomViewer = GameObject.Find("DiCom Viewer - Obliquo");
            dicomViewer.SetActive(false);
            dicomViewer.transform.parent = GameObject.Find("Obliquo").transform;
            GameObject.Find("Obliquo").transform.GetChild(0).GetComponent<Image>().color = new UnityEngine.Color32(255, 255, 255, 255);
        }
    }
}

