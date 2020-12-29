using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(ARReferencePointManager))]
public class PlacementController : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;

    private ARPlaneManager arPlaneManager;

    private ARReferencePointManager arReferencePointManager;

    private ARReferencePoint referencePoint;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private Button clearPlantButton;

    [SerializeField]
    private Button moveButton;

    [SerializeField]
    private Button doneMovingButton;

    private int placedPlants = 0;

    private bool isMoving = false;

    DetailsManager detailsManager;

    ButtonManager buttonManager;

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        arReferencePointManager = GetComponent<ARReferencePointManager>();
        detailsManager = FindObjectOfType<DetailsManager>();
        buttonManager = FindObjectOfType<ButtonManager>();

        SetAllPlanesActive(false);
        clearPlantButton.onClick.AddListener(RemoveSpawnedPlant);
        
        moveButton.onClick.AddListener(MovePlant);
        doneMovingButton.onClick.AddListener(MovePlantDone);
        
    }

    private void MovePlant()
    {
        UIManager.Instance.CloseWheels();
        SetAllPlanesActive(true);
        isMoving = true;

        UIManager.Instance.optionPanel2.SetActive(false);
        UIManager.Instance.plantMovePanel.SetActive(true);
    }

    private void MovePlantDone()
    {
        SetAllPlanesActive(false);
        isMoving = false;

        UIManager.Instance.optionPanel2.SetActive(true);
        UIManager.Instance.plantMovePanel.SetActive(false);
    }


    // Removing the instantiated plant model in world space
    public void RemoveSpawnedPlant()
    {
        bool activated = UIManager.Instance.detailsPanel.activeSelf;

        if(activated)
            UIManager.Instance.detailsPanel.SetActive(false);

        arReferencePointManager.RemoveReferencePoint(referencePoint);
        SetAllPlanesActive(true);
        placedPlants = 0;

        UIManager.Instance.ShowOption1Layer();
    }

    void Update()
    {
        SpawnPlantPrefab();

        if(isMoving)
            MoveSpawnPlant();
    }

    // For Instatiating the plant model to world space and at the same time create a reference point
    private void SpawnPlantPrefab()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                var touchPosition = touch.position;
                bool isOverUI = touchPosition.IsPointOverUIObject();

                if(!isOverUI && arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;
                    
                    if(placedPlants < 1)
                    {
                        arReferencePointManager.referencePointPrefab = DataHandler.Instance.plant;
                        referencePoint = arReferencePointManager.AddReferencePoint(hitPose);
                        placedPlants = 1;
                        // EnableOption2();
                        UIManager.Instance.ShowOption2Layer();
                    }
                    if(!isMoving)
                        SetAllPlanesActive(false);
                }
            }
        }
    }

    private void MoveSpawnPlant()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            var touchPosition = touch.position;
            bool isOverUI = touchPosition.IsPointOverUIObject();

            if(!isOverUI && arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                referencePoint.transform.position = hitPose.position;
            }
        }
    }

    // Toggle enable or disable the AR Plant Detection
    public void SetAllPlanesActive(bool value)
    {
        if(value == true)
            arPlaneManager.enabled = true;
        else
            arPlaneManager.enabled = false;

        foreach(var plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }

}
