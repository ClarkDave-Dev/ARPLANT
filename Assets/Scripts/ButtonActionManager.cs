using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActionManager : MonoBehaviour
{
    // 
    // Welcome Panel Buttons
    // 
    [SerializeField]
    private Button startButton;

    [SerializeField]
    public Button quizPanelButton;

    //
    // Quiz Panel Button
    //

    [SerializeField]
    private Button quizExitButton;

    [SerializeField]
    public Button quizAnswerButton;

    // 
    // Quiz Prompt Buttons 
    // 

    [SerializeField]
    private Button yesButton;

    [SerializeField]
    private Button noButton;
    // 
    // Options 1 Panel Buttons
    // 
    [SerializeField]
    private Button menuButton;


    // 
    // Options 2 Panel Buttons
    // 
    [SerializeField]
    private Button detailsButton;

    [SerializeField]
    private Button triviaButton;

    [SerializeField]
    private Button optionsButton;


    // 
    // Back Panel Buttons
    // 
    [SerializeField]
    private Button backButton;
    

    // 
    // Wheel 1 Panel Buttons
    // 
    [SerializeField]
    private Button wheel1CloseButton;

    [SerializeField]
    private Button growButton;

    [SerializeField]
    private Button partsButton;


    // 
    // Wheel 2 Panel Buttons
    // 
    [SerializeField]
    private Button wheel2BackButton;

    [SerializeField]
    private Button leafButton;

    [SerializeField]
    private Button plantButton;

    [SerializeField]
    private Button stemButton;


    // 
    // Delegates and Events
    // 
    public delegate void GrowPlantClicked();
    public static event GrowPlantClicked OnGrowPlantClicked;

    public delegate void ShowLeaf();
    public static event ShowLeaf ShowLeafCLicked;

    public delegate void ShowPlant();
    public static event ShowPlant ShowPlantClicked;

    public delegate void ShowStem();
    public static event ShowStem ShowStemClicked;

    private static ButtonActionManager instance;

    public static ButtonActionManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<ButtonActionManager>();

            return instance;
        }
    }
    private void Start() 
    {
        // GUI Manipulation Button Listeners
        menuButton.onClick.AddListener(UIManager.Instance.TogglePlantMenuLayer);
        // detailsButton.onClick.AddListener(UIManager.Instance.ToggleDetailsPanel);
        // triviaButton.onClick.AddListener(UIManager.Instance.ToggleTriviaPanel);
        startButton.onClick.AddListener(UIManager.Instance.ShowPlantMenuLayer);
        quizPanelButton.onClick.AddListener(UIManager.Instance.ShowQuizPrompt);
        yesButton.onClick.AddListener(UIManager.Instance.ShowQuizPanel);
        noButton.onClick.AddListener(UIManager.Instance.CloseQuizPrompt);
        quizExitButton.onClick.AddListener(UIManager.Instance.CloseQuizPanel);
        quizExitButton.onClick.AddListener(QuizController.Instance.StopTimer);
      //  quizAnswerButton.onClick.AddListener(QuizController.Instance.ShowAnswer);
        backButton.onClick.AddListener(UIManager.Instance.ShowWelcomePanel);
        optionsButton.onClick.AddListener(UIManager.Instance.ShowWheel1);
        wheel1CloseButton.onClick.AddListener(UIManager.Instance.CloseWheels);
        partsButton.onClick.AddListener(UIManager.Instance.ShowWheel2);
        wheel2BackButton.onClick.AddListener(UIManager.Instance.ShowWheel1);

        growButton.onClick.AddListener(GrowPlant);
        leafButton.onClick.AddListener(LeafButtonClick);
        plantButton.onClick.AddListener(PlantButtonClick);
        stemButton.onClick.AddListener(StemButtonClick);
    }

    private void GrowPlant()
    {
        if(OnGrowPlantClicked != null)
        {
            UIManager.Instance.CloseWheels();
            OnGrowPlantClicked();
        }
    }

    private void LeafButtonClick()
    {
        if(ShowLeafCLicked != null)
        {
            UIManager.Instance.CloseWheels();
            ShowLeafCLicked();
        }
    }

    private void PlantButtonClick()
    {
        if(ShowPlantClicked != null)
        {
            UIManager.Instance.CloseWheels();
            ShowPlantClicked();
        }
    }

    private void StemButtonClick()
    {
        if(ShowStemClicked != null)
        {
            UIManager.Instance.CloseWheels();
            ShowStemClicked();
        }
    }

}
