using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePanelsScript : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject directionsPanel;
    public GameObject navigationPanel;
    // Start is called before the first frame update
    void Start()
    {
        startPanel = GameObject.Find("Panel Start"); 
        directionsPanel = GameObject.Find("Panel Directions"); 
        navigationPanel = GameObject.Find("Panel Navigation"); 

        startPanel.SetActive(false);
        directionsPanel.SetActive(false);
        navigationPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDirectionsPanel()
    {
        startPanel.SetActive(false);
        directionsPanel.SetActive(true);
    }

    public void ShowNavigationPanel()
    {
        directionsPanel.SetActive(false);
        navigationPanel.SetActive(true);
    }

    public void ShowStartPanel()
    {
        navigationPanel.SetActive(false);
        startPanel.SetActive(true);
    }
}
