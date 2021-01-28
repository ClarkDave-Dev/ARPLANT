﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    
    // [SerializeField]
    // private GameObject plant;

    // [SerializeField]
    public Plant plant;

    public int ID;

    [SerializeField]
    private newID newID;
    // UI Card
    [SerializeField]
    private Text commonName;

    [SerializeField]
    private Text botanicalName;

    [SerializeField]
    private Image plantImage;

    [SerializeField]
    private Text infoText;


    private DetailsManager detailsManager;

    private PlacementController placementController;

    void Start()
    {
        commonName.text = plant.commonName;
        botanicalName.text = plant.botanicalName;
        plantImage.sprite = plant.plantImage;
        infoText.text = plant.plantGeneralInfo;
        newID.ID = ID;

        detailsManager = UIManager.Instance.detailsPanel.GetComponent<DetailsManager>();
        placementController = FindObjectOfType<PlacementController>();

        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectPlantModel);

    }

    private void SelectPlantModel()
    {
        DataHandler.Instance.plant = plant.plantPrefab;
        DataHandler.Instance.plantData = plant;
        
        UIManager.Instance.TogglePlantMenuLayer();
        placementController.SetAllPlanesActive(true);
    }

}
