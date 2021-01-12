using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public GameObject backPanel;
    public GameObject wheel1;
    public GameObject wheel2;
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
    // Wheel Buttons 
    // 

    // Group of buttons for Options Menu Wheel
    [SerializeField]
    private GameObject closeButton;

    [SerializeField]
    private GameObject partsButton;

    [SerializeField]
    private GameObject growButton;

    [SerializeField]
    private GameObject removeButton;

    [SerializeField]
    private GameObject moveButton;

    // Group of buttons for Parts Menu Wheel
    [SerializeField]
    private GameObject backButton;

    [SerializeField]
    private GameObject leafButton;

    [SerializeField]
    private GameObject flowerButton;

    [SerializeField]
    private GameObject plantButton;

    [SerializeField]
    private GameObject stemButton;


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
        panels.Add(wheel1);
        panels.Add(wheel2);

        ShowWelcomePanel();
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
    // Options Menu Button Wheel UI Tweening
    // 

    // Sequence for Disabling Options Menu Wheel
    private void DisableOptionsMenu()
    {
        LeanTween.moveLocalX(growButton, 0f, 0.5f);
        LeanTween.moveLocalX(partsButton, 0f, 0.5f);
        LeanTween.moveLocalY(moveButton, 0f, 0.5f);
        LeanTween.moveLocalY(removeButton, 0f, 0.5f).setOnComplete(DisableOptionsMenu2);

        LeanTween.scale(growButton, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(partsButton, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(moveButton, new Vector3(0f, 0f, 0f), 0.5f);
        LeanTween.scale(removeButton, new Vector3(0f, 0f, 0f), 0.5f);
    }
    private void DisableOptionsMenu2() => LeanTween.rotateZ(closeButton, 180f, 0.5f).setOnComplete(DisableOptionsMenu3);
    private void DisableOptionsMenu3() => wheel1.SetActive(false);

    // Sequence for Enabling Options Menu Wheel
    private void EnableOptionsMenu()
    {
        growButton.transform.localScale = new Vector3(0f, 0f, 0f);
        partsButton.transform.localScale = new Vector3(0f, 0f, 0f);
        moveButton.transform.localScale = new Vector3(0f, 0f, 0f);
        removeButton.transform.localScale = new Vector3(0f, 0f, 0f);

        growButton.transform.localPosition = new Vector3(0f, 0f, 0f);
        partsButton.transform.localPosition = new Vector3(0f, 0f, 0f);
        moveButton.transform.localPosition = new Vector3(0f, 0f, 0f);
        removeButton.transform.localPosition = new Vector3(0f, 0f, 0f);

        wheel1.SetActive(true);

        LeanTween.rotateZ(closeButton, 180f, 0f).setOnComplete(EnableOptionsMenu2);
    }
    private void EnableOptionsMenu2() => LeanTween.rotateZ(closeButton, 0f, 0.5f).setOnComplete(EnableOptionsMenu3);
    private void EnableOptionsMenu3()
    {
        LeanTween.scale(growButton, new Vector3(1f, 1f, 1f), 1f);
        LeanTween.scale(partsButton, new Vector3(1f, 1f, 1f), 1f);
        LeanTween.scale(removeButton, new Vector3(1f, 1f, 1f), 1f);
        LeanTween.scale(moveButton, new Vector3(1f, 1f, 1f), 1f);

        LeanTween.moveLocalX(growButton, 350f, 0.5f);
        LeanTween.moveLocalX(partsButton, -350f, 0.5f);
        LeanTween.moveLocalY(removeButton, -350f, 0.5f);
        LeanTween.moveLocalY(moveButton, 350f, 0.5f);
    }


    // 
    // Parts Menu Button Wheel UI Tweening
    // 

    // Sequence for Disabling Parts Menu
    private void DisablePartsMenu()
    {
        LeanTween.moveLocalX(leafButton, 0f, 0.5f);
        LeanTween.moveLocalX(plantButton, 0f, 0.5f);
        LeanTween.moveLocalY(stemButton, 0f, 0.5f);
        LeanTween.moveLocalY(flowerButton, 0f, 0.5f);

        LeanTween.scale(leafButton, new Vector3(0f, 0f, 0f), 1f);
        LeanTween.scale(plantButton, new Vector3(0f, 0f, 0f), 1f);
        LeanTween.scale(stemButton, new Vector3(0f, 0f, 0f), 1f);
        LeanTween.scale(flowerButton, new Vector3(0f, 0f, 0f), 1f).setOnComplete(DisablePartsMenu2);
    }
    private void DisablePartsMenu2() => LeanTween.rotateZ(backButton, 180f, 0.5f).setOnComplete(DisablePartsMenu3);
    private void DisablePartsMenu3() => wheel2.SetActive(false);


    // Sequence for Enabling Parts Menu
    private void EnablePartsMenu()
    {
        plantButton.transform.localScale = new Vector3(0f, 0f, 0f);
        leafButton.transform.localScale = new Vector3(0f, 0f, 0f);
        stemButton.transform.localScale = new Vector3(0f, 0f, 0f);
        flowerButton.transform.localScale = new Vector3(0f, 0f, 0f);

        plantButton.transform.localPosition = new Vector3(0f, 0f, 0f);
        leafButton.transform.localPosition = new Vector3(0f, 0f, 0f);
        stemButton.transform.localPosition = new Vector3(0f, 0f, 0f);
        flowerButton.transform.localPosition = new Vector3(0f, 0f, 0f);

        wheel2.SetActive(true);
        LeanTween.rotateZ(backButton, 180f, 0f).setOnComplete(EnablePartsMenu2);
    }
    private void EnablePartsMenu2() => LeanTween.rotateZ(backButton, 0f, 0.5f).setOnComplete(EnablePartsMenu3);

    private void EnablePartsMenu3()
    {
        LeanTween.scale(plantButton, new Vector3(1f, 1f, 1f), 0.5f);
        LeanTween.scale(leafButton, new Vector3(1f, 1f, 1f), 0.5f);
        LeanTween.scale(stemButton, new Vector3(1f, 1f, 1f), 0.5f);
        LeanTween.scale(flowerButton, new Vector3(1f, 1f, 1f), 0.5f);

        LeanTween.moveLocalX(plantButton, -350f, 0.5f);
        LeanTween.moveLocalX(leafButton, 350f, 0.5f);
        LeanTween.moveLocalY(stemButton, -350f, 0.5f);
        LeanTween.moveLocalY(flowerButton, 350f, 0.5f);
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
    public void ShowQuizPanel()
    {
        //   DisableAll();

        //    welcomePanel.SetActive(true);

        ButtonActionManager.Instance.quizPanelButton.gameObject.SetActive(false);
        quizPanel.SetActive(true);
        QuizController.Instance.CreateQuestion();
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

    // 
    // Toggle Details Panel Functions
    // 
    public void ToggleDetailsPanel()
    {
        bool triviaPanelIsActive = triviaPanel.activeSelf;
        if(triviaPanelIsActive)
            triviaPanel.SetActive(false);

        bool wheel1IsActive = wheel1.activeSelf;
        if(wheel1IsActive)
            wheel1.SetActive(false);

        bool wheel2IsActive = wheel2.activeSelf;
        if(wheel2IsActive)
            wheel2.SetActive(false);

        StartCoroutine(DetailsPanelToggler(0f));
    }

    private IEnumerator DetailsPanelToggler(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        bool isActive = detailsPanel.activeSelf;
        if(isActive)
            DisableDetailsPanel();
        else
            EnableDetailsPanel();
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


    // 
    // Trivia Panel Toggle Functions
    // 
    public void ToggleTriviaPanel()
    {
        bool detailsPanelIsActive = detailsPanel.activeSelf;
        if(detailsPanelIsActive)
            detailsPanel.SetActive(false);

        bool wheel1IsActive = wheel1.activeSelf;
        if(wheel1IsActive)
            wheel1.SetActive(false);

        bool wheel2IsActive = wheel2.activeSelf;
        if(wheel2IsActive)
            wheel2.SetActive(false);

        StartCoroutine(TriviaPanelToggler(0f));
    }

    private IEnumerator TriviaPanelToggler(float delay)
    {
        yield return new WaitForSeconds(delay);

        bool isActive = triviaPanel.activeSelf;
        if(isActive)
            DisableTriviaPanel();
        else
            EnableTriviaPanel();
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
        }
    }


    // 
    // Options Menu Wheel Toggle Functions
    // 
    public void ShowWheel1()
    {
        bool triviaIsActive = triviaPanel.activeSelf;
        if(triviaIsActive)
            triviaPanel.SetActive(false);
        
        bool detailsIsActive = detailsPanel.activeSelf;
        if(detailsIsActive)
            detailsPanel.SetActive(false);

        bool wheel2IsActive = wheel2.activeSelf;
        if(wheel2IsActive)
            wheel2.SetActive(false);
        
        if(!wheel1.activeSelf)
            EnableOptionsMenu();
    }

    private IEnumerator OptionsMenuToggler(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        EnableOptionsMenu();
    }

    public void CloseWheels()
    {
        if(wheel1.activeSelf)
            DisableOptionsMenu();

        if(wheel2.activeSelf)
            DisablePartsMenu();
    }

    public void ShowWheel2()
    {
        bool triviaIsActive = triviaPanel.activeSelf;
        if(triviaIsActive)
            triviaPanel.SetActive(false);
        
        bool detailsIsActive = detailsPanel.activeSelf;
        if(detailsIsActive)
            detailsPanel.SetActive(false);

        bool wheel1IsActive = wheel1.activeSelf;
        if(wheel1IsActive)
            wheel1.SetActive(false);

        EnablePartsMenu();
    }

    private IEnumerator PartsMenuToggler(float delay)
    {
        yield return new WaitForSeconds(delay);

        EnablePartsMenu();
    }
}
