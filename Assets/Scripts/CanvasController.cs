using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    private Plant plant;


    [SerializeField]
    private Text detailsText;

    [SerializeField]
    private Text triviaText;

    [SerializeField]
    private Text medicalUsesText;


    [SerializeField]
    private GameObject medicalUsesPanel;

    [SerializeField]
    private GameObject detailsPanel;

    [SerializeField]
    private GameObject triviaPanel;

    private void Start() 
    {
        if(medicalUsesPanel.activeSelf)
            medicalUsesPanel.SetActive(false);

        if(detailsPanel.activeSelf)
            detailsPanel.SetActive(false);

        if(triviaPanel.activeSelf)
            triviaPanel.SetActive(false);

        SetPanelContents();
    }

    private void SetPanelContents()
    {
        plant = DataHandler.Instance.plantData;

        detailsText.text = plant.plantDetails;
        triviaText.text = plant.plantTrivia;
        medicalUsesText.text = plant.plantMedicalUses;
    }

    private void OnEnable() 
    {
        ButtonCanvasActionManager.DetailsButtonTapped += ShowDetailsPanel;
        ButtonCanvasActionManager.TriviaButtonTapped += ShowTriviaPanel;
        ButtonCanvasActionManager.MedicalUsesButtonTapped += ShowMedicalUsesPanel;

        ButtonCanvasActionManager.HideDetailsEvent += HideDetailsPanel;
        ButtonCanvasActionManager.HideTriviaEvent += HideTriviaPanel;
        ButtonCanvasActionManager.HideMedicalUsesEvent += HideMedicalUsesPanel;
    }

    private void OnDisable() 
    {
        ButtonCanvasActionManager.DetailsButtonTapped -= ShowDetailsPanel;
        ButtonCanvasActionManager.TriviaButtonTapped -= ShowTriviaPanel;
        ButtonCanvasActionManager.MedicalUsesButtonTapped -= ShowMedicalUsesPanel;

        ButtonCanvasActionManager.HideDetailsEvent -= HideDetailsPanel;
        ButtonCanvasActionManager.HideTriviaEvent -= HideTriviaPanel;
        ButtonCanvasActionManager.HideMedicalUsesEvent -= HideMedicalUsesPanel;
    }

    private void ShowDetailsPanel()
    {
        if(!detailsPanel.activeSelf)
            detailsPanel.SetActive(true);
    }

    private void ShowTriviaPanel()
    {
        if(!triviaPanel.activeSelf)
            triviaPanel.SetActive(true);
    }

    private void ShowMedicalUsesPanel()
    {
        if(!medicalUsesPanel.activeSelf)
            medicalUsesPanel.SetActive(true);
    }

    private void HideDetailsPanel()
    {
        if(detailsPanel.activeSelf)
            detailsPanel.SetActive(false);
    }

    private void HideTriviaPanel()
    {
        if(triviaPanel.activeSelf)
            triviaPanel.SetActive(false);
    }

    private void HideMedicalUsesPanel()
    {
        if(medicalUsesPanel.activeSelf)
            medicalUsesPanel.SetActive(false);
    }
}
