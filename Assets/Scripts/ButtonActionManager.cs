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
    // Back Panel Buttons
    // 
    [SerializeField]
    private Button backButton;
    
    [SerializeField]
    private Button growButton;
    // 
    // Delegates and Events
    // 
    public delegate void GrowPlantClicked();
    public static event GrowPlantClicked OnGrowPlantClicked;

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

        growButton.onClick.AddListener(GrowPlant);
    }

    private void GrowPlant()
    {
        if(OnGrowPlantClicked != null)
        {
            OnGrowPlantClicked();
        }
    }
}
