using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject plantMenu;
    public GameObject optionPanel1;
    public GameObject optionPanel2;
    public GameObject detailsPanel;
    public GameObject triviaPanel;
    public GameObject welcomePanel;
    public GameObject quizPanel;
    public GameObject quizAnswerPanel;
    public GameObject quizPrompt;
    public GameObject backPanel;
    public GameObject plantMovePanel;


    private List<GameObject> panels = new List<GameObject>();

    //
    //Welcome Panel Ui Elements
    //

    public GameObject startButtonCover;
    public GameObject startButton;
    public GameObject logo;
    public GameObject steps;

    // 
    // Variables for Populating the Plant Menu Panel with Pant Cards
    // 
    [SerializeField]
    private GameObject plantCard;
    [SerializeField]
    private GameObject plantCardEmpty;

    [SerializeField]
    private Transform plantCardHolder;

    private Database database;

    private ButtonManager buttonManager;

    private Plant[] plants;


    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if(instance == null)
                instance = FindObjectOfType<UIManager>();
            
            return instance;
        }
    }

    void Start() 
    {
        panels.Add(plantMenu);
        panels.Add(optionPanel1);
        panels.Add(optionPanel2);
        panels.Add(detailsPanel);
        panels.Add(triviaPanel);
        panels.Add(welcomePanel);
        panels.Add(quizPanel);
        panels.Add(quizAnswerPanel);
        panels.Add(backPanel);

        ShowWelcomePanel();
        // ShowOption2Layer();
        PopulatePlantMenu();
    }

    // 
    // Function for populating the Plant Menu Panel
    // 
    private void PopulatePlantMenu()
    {
        database = GameObject.FindObjectOfType<Database>();
        plants = database.plants;
        int n = 0;
        foreach(Plant plant in plants)
        {
            buttonManager = plantCard.GetComponent<ButtonManager>();
            buttonManager.plant = plant;
            buttonManager.ID = n;
            Instantiate(plantCard, plantCardHolder);
            n++;
        }
    }

    // 
    // Details Panel UI Tweening
    // 

    // Sequence for Disabling Details Panel
    private void DisableDetailsPanel() => LeanTween.scaleY(detailsPanel, 0.01f, 0.2f).setOnComplete(DisableDetailsPanel2);
    private void DisableDetailsPanel2() => LeanTween.scaleX(detailsPanel, 0.01f, 0.3f).setOnComplete(DisableDetialsPanel3);
    private void DisableDetialsPanel3() => detailsPanel.SetActive(false);

    // Sequence for Enabling Details Panel
    private void EnableDetailsPanel()
    {
        // Activate the Details Panel and Set the Scale to 0 at the same time
        detailsPanel.SetActive(true);
        detailsPanel.transform.localScale = new Vector3(0.01f, 0.01f);
        // Start Tweening
        LeanTween.scaleX(detailsPanel, 1f, 0.2f).setOnComplete(EnableDetailsPanel2);
    }

    private void EnableDetailsPanel2() => LeanTween.scaleY(detailsPanel, 1f, 0.3f);


    // 
    // Trivia Panel UI Tweening
    // 

    // Sequence for Disabling Trivia Panel
    private void DisableTriviaPanel() => LeanTween.scaleY(triviaPanel, 0.01f, 0.2f).setOnComplete(DisableTriviaPanel2);
    private void DisableTriviaPanel2() => LeanTween.scaleX(triviaPanel, 0.1f, 0.3f).setOnComplete(DisableTriviaPanel3);
    private void DisableTriviaPanel3() => triviaPanel.SetActive(false);

    // Sequence for Enabling Trivia Panel
    private void EnableTriviaPanel()
    {
        triviaPanel.SetActive(true);
        triviaPanel.transform.localScale = new Vector3(0.01f, 0.01f);

        // Start tweening
        LeanTween.scaleX(triviaPanel, 1f, 0.2f).setOnComplete(EnableTriviaPanel2);
    }
    private void EnableTriviaPanel2() => LeanTween.scaleY(triviaPanel, 1f, 0.3f);

    // Function to disable all UI Panels
    public void DisableAll()
    {
        foreach(GameObject panel in panels)
        {
            panel.gameObject.SetActive(false);
        }
    }

    // 
    // UI Layers Functions
    // 
    public void ShowWelcomePanel()
    {
        DisableAll();

        welcomePanel.SetActive(true);
        steps.gameObject.SetActive(true);
        logo.gameObject.SetActive(true);
        startButton.gameObject.SetActive(true);
        startButtonCover.gameObject.SetActive(false);
        startButtonCover.GetComponent<RectTransform>().transform.localPosition = new Vector2(0,-1600);
        startButtonCover.GetComponent<RectTransform>().LeanSize(new Vector2(1200, 400), 0);
    }
    public void ShowQuizPrompt()
    {
        ButtonActionManager.Instance.quizPanelButton.gameObject.SetActive(false);
        quizPrompt.SetActive(true);
        Vector2 currentPos = quizPrompt.GetComponent<RectTransform>().transform.localPosition;
        quizPrompt.GetComponent<RectTransform>().transform.localPosition = new Vector2(currentPos.x + 1000, currentPos.y);
        StartCoroutine(QuizPromptTransition(currentPos));

    }
    public void CloseQuizPrompt()
    {
        Vector2 currentPos = quizPrompt.GetComponent<RectTransform>().transform.localPosition;
        StartCoroutine(QuizPromptExit(currentPos));
        ButtonActionManager.Instance.quizPanelButton.gameObject.SetActive(true);
    }
    public void ShowQuizPanel()
    {
        //   DisableAll();

        //    welcomePanel.SetActive(true);

        Vector2 currentPos = quizPrompt.GetComponent<RectTransform>().transform.localPosition;
        StartCoroutine(QuizPromptExit(currentPos));
        quizPanel.SetActive(true);
        QuizController.Instance.CreateQuestion(quizPanel.GetComponent<newID>().ID);
    }

    public void CloseQuizPanel()
    {
        //   DisableAll();

        //    welcomePanel.SetActive(true);
        quizPanel.SetActive(false);
        quizAnswerPanel.SetActive(false);
        ButtonActionManager.Instance.quizPanelButton.gameObject.SetActive(true);
    }
    public void ShowPlantMenuLayer()
    {
        if (welcomePanel.activeSelf)
            StartCoroutine(WelcomePanelExitTransition());
        else
        {
            plantMenu.SetActive(true);
            optionPanel1.SetActive(true);
            backPanel.SetActive(true);
        }

    }

    public void ShowOption1Layer()
    {
        DisableAll();

        optionPanel1.SetActive(true);
    }

    public void ShowOption2Layer()
    {
        DisableAll();

        optionPanel2.SetActive(true);
    }

    IEnumerator WelcomePanelExitTransition()
    {
        startButtonCover.gameObject.SetActive(true);
        startButtonCover.GetComponent<RectTransform>().LeanSize(new Vector2(startButtonCover.GetComponent<RectTransform>().rect.width, startButtonCover.GetComponent<RectTransform>().rect.height + 3100), 0.3f);
        yield return new WaitForSeconds(0.4f);
        startButtonCover.GetComponent<RectTransform>().LeanMoveLocalY(3100, 0.4f);
        steps.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
       // yield return new WaitForSeconds(0.4f);

        plantMenu.SetActive(true);
        optionPanel1.SetActive(true);
        backPanel.SetActive(true);
    }

    IEnumerator QuizPromptTransition(Vector2 currentPos)
    {
        quizPrompt.GetComponent<RectTransform>().LeanMoveLocalX(currentPos.x, 0.2f);
        yield return null;
    }
    IEnumerator QuizPromptExit(Vector2 currentPos)
    {
        quizPrompt.GetComponent<RectTransform>().LeanMoveLocalX(currentPos.x - 1000, 0.2f);
        yield return new WaitForSeconds(0.2f);
        quizPrompt.SetActive(false);
        quizPrompt.GetComponent<RectTransform>().transform.localPosition = new Vector2(currentPos.x, currentPos.y);
    }

    // Toggle Plant Menu Function
    public void TogglePlantMenuLayer()
    {
        bool isActive = plantMenu.activeSelf;

        if (isActive)
        {
            ShowOption1Layer();
            ButtonActionManager.Instance.quizPanelButton.gameObject.SetActive(true);
        }
        else
        {
            ShowPlantMenuLayer();
            ButtonActionManager.Instance.quizPanelButton.gameObject.SetActive(false);
            quizPrompt.SetActive(false);
            Vector2 currentPos = quizPrompt.GetComponent<RectTransform>().transform.localPosition;
            StartCoroutine(QuizPromptExit(currentPos));
        }
    }
}
