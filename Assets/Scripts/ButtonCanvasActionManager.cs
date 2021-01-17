using UnityEngine;
using UnityEngine.UI;

public class ButtonCanvasActionManager : MonoBehaviour
{
    [SerializeField]
    private Button informationsButton;

    [SerializeField]
    private Button partsButton;

    [SerializeField]
    private Button detailsButton;

    [SerializeField]
    private Button triviaButton;

    [SerializeField]
    private Button medicalUsesButton;

    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private Button plantButton;

    [SerializeField]
    private Button leafButton;

    [SerializeField]
    private Button stemButton;

    [SerializeField]
    private Button flowerButton;


    private ButtonCanvasTweening buttonCanvasTweening;

    private bool informationsButtonIsActive = false;

    private bool partsButtonIsActive = false;


    public delegate void ShowDetails();
    public static event ShowDetails DetailsButtonTapped;

    public delegate void ShowTrivia();
    public static event ShowTrivia TriviaButtonTapped;

    public delegate void ShowMedicalUses();
    public static event ShowMedicalUses MedicalUsesButtonTapped;

    public delegate void HideDetails();
    public static event HideDetails HideDetailsEvent;

    public delegate void HideTrivia();
    public static event HideTrivia HideTriviaEvent;

    public delegate void HideMedicalUses();
    public static event HideMedicalUses HideMedicalUsesEvent;

    public delegate void ShowPlant();
    public static event ShowPlant ShowPlantEvent;
    public delegate void ShowLeaf();
    public static event ShowLeaf ShowLeafEvent;

    public delegate void ShowStem();
    public static event ShowStem ShowStemEvent;

    public delegate void ShowFlower();
    public static event ShowFlower ShowFlowerEvent;

    private void Start() 
    {
        buttonCanvasTweening = GameObject.FindObjectOfType<ButtonCanvasTweening>();

        informationsButton.onClick.AddListener(ToggleInformationsButton);
        partsButton.onClick.AddListener(TogglePartsButton);

        detailsButton.onClick.AddListener(DetailsButtonTap);
        triviaButton.onClick.AddListener(TriviaButtonTap);
        medicalUsesButton.onClick.AddListener(MedicalUsesButtonTap);
        closeButton.onClick.AddListener(HideButtonCanvas);

        plantButton.onClick.AddListener(ShowPlantPart);
        leafButton.onClick.AddListener(ShowLeafPart);
        stemButton.onClick.AddListener(ShowStemPart);
        flowerButton.onClick.AddListener(ShowFlowerPart);

        HideButtonCanvas();
    }

    private void HideButtonCanvas()
    {
        if(HideDetailsEvent != null)
            HideDetailsEvent();
        if(HideTriviaEvent != null)
            HideTriviaEvent();
        if(HideMedicalUsesEvent != null)
            HideMedicalUsesEvent();

        gameObject.SetActive(false);
    }

    private void DetailsButtonTap()
    {
        if(DetailsButtonTapped != null)
            DetailsButtonTapped();
    }

    private void TriviaButtonTap()
    {
        if(TriviaButtonTapped != null)
            TriviaButtonTapped();
    }

    private void MedicalUsesButtonTap()
    {
        if(MedicalUsesButtonTapped != null)
            MedicalUsesButtonTapped();
    }

    private void ToggleInformationsButton()
    {
        if(informationsButtonIsActive)
            buttonCanvasTweening.InformationButtonOutTween();
        else
            buttonCanvasTweening.InformationButtonEntry();
        
        informationsButtonIsActive = !informationsButtonIsActive;
    }

    private void TogglePartsButton()
    {
        if(partsButtonIsActive)
            buttonCanvasTweening.PartsButtonOut();
        else
            buttonCanvasTweening.PartsButtonEntry();
        
        partsButtonIsActive = !partsButtonIsActive;
    }

    private void ShowPlantPart()
    {
        if(ShowPlantEvent != null)
            ShowPlantEvent();
    }

    private void ShowLeafPart()
    {
        if(ShowLeafEvent != null)
            ShowLeafEvent();
    }

    private void ShowStemPart()
    {
        if(ShowStemEvent != null)
            ShowStemEvent();
    }

    private void ShowFlowerPart()
    {
        if(ShowFlowerEvent != null)
            ShowFlowerEvent();
    }
}
