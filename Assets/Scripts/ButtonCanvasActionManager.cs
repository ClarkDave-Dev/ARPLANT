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


    private ButtonCanvasTweening buttonCanvasTweening;

    private bool informationsButtonIsActive = false;

    private bool partsButtonIsActive = false;


    public delegate void ShowDetails();
    public static event ShowDetails DetailsButtonTapped;

    public delegate void ShowTrivia();
    public static event ShowTrivia TriviaButtonTapped;

    public delegate void ShowMedicalUses();
    public static event ShowMedicalUses MedicalUsesButtonTapped;

    private void Start() 
    {
        buttonCanvasTweening = GameObject.FindObjectOfType<ButtonCanvasTweening>();

        informationsButton.onClick.AddListener(ToggleInformationsButton);
        partsButton.onClick.AddListener(TogglePartsButton);

        detailsButton.onClick.AddListener(DetailsButtonTap);
        triviaButton.onClick.AddListener(TriviaButtonTap);
        medicalUsesButton.onClick.AddListener(MedicalUsesButtonTap);
        closeButton.onClick.AddListener(HideButtonCanvas);

        HideButtonCanvas();
    }

    private void HideButtonCanvas()
    {
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
}
