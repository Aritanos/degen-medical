using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    [Header("DiComs")]
    public GameObject coronalDicomViewer;
    public GameObject axialDicomViewer;
    public GameObject sagittalDicomViewer;
    public GameObject obliquoDicomViewer;

//----------------------------------------------------------------------------------------------------------------
    void Start()
    {
       StartCoroutine(LoadDicoms());
    }
    public IEnumerator LoadDicoms()
    {
        yield return new WaitForSeconds(0.5f);
        coronalDicomViewer.GetComponent<DicomViewer>().ImportData();
        axialDicomViewer.GetComponent<DicomViewer>().ImportData();
        sagittalDicomViewer.GetComponent<DicomViewer>().ImportData();
        obliquoDicomViewer.GetComponent<DicomViewer>().ImportData();
    }
}
