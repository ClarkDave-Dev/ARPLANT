using UnityEngine;

public class ButtonCanvasTweening : MonoBehaviour
{
    // The 2 Main buttons of the Buttons Canvas in the World Space
    [SerializeField]
    private GameObject informationsButton;

    [SerializeField]
    private GameObject partsButton;

    [SerializeField]
    private GameObject detailsButton;

    [SerializeField]
    private GameObject triviaButton;

    [SerializeField]
    private GameObject medicalUsesButton;

    [SerializeField]
    private GameObject plantButton;

    [SerializeField]
    private GameObject leafButton;

    [SerializeField]
    private GameObject flowerButton;

    [SerializeField]
    private GameObject stemButton;

    [SerializeField]
    private GameObject closeButton;


    private float defaultLocation = -1300;

    private Vector3 closeButtonDefault = new Vector3(1150f, 200f, 0f);

    private void OnEnable() 
    {
        CanvasStart();
    }

    private void CanvasStart()
    {
       closeButton.transform.localPosition = new Vector3(550f, 200f, 0f);

        DisableAllSubButtons();

        if(!informationsButton.activeSelf)
            informationsButton.SetActive(true);
        if(!partsButton.activeSelf)
            partsButton.SetActive(true);

        RectTransform infoRect = informationsButton.GetComponent<RectTransform>();
        infoRect.sizeDelta = new Vector2(350f, 150f);
        informationsButton.transform.localPosition = new Vector3(-200f, 0f, 0f);

        RectTransform partsRect = partsButton.GetComponent<RectTransform>();
        partsRect.sizeDelta = new Vector2(350f, 150f);
        partsButton.transform.localPosition = new Vector3(200f, 0f, 0f);
    }

    private void DisableAllSubButtons()
    {
        if(plantButton.activeSelf)
            plantButton.SetActive(false);
        if(leafButton.activeSelf)
            leafButton.SetActive(false);
        if(flowerButton.activeSelf)
            flowerButton.SetActive(false);
        if(stemButton.activeSelf)
            stemButton.SetActive(false);

        if(detailsButton.activeSelf)
            detailsButton.SetActive(false);
        if(triviaButton.activeSelf)
            triviaButton.SetActive(false);
        if(medicalUsesButton.activeSelf)
            medicalUsesButton.SetActive(false);
    }

    #region Information Button Entry Tween
    
    private void InformationEntryStart()
    {
        closeButton.transform.localPosition = new Vector3(750f, 200f, 0f);

        // Make sure the 2 main buttons are active
        if(!partsButton.activeSelf)
            partsButton.SetActive(true);
        if(!informationsButton.activeSelf)
            informationsButton.SetActive(true);

        // Make sure the 2 main buttons are scaled correctly
        RectTransform partsRect = partsButton.GetComponent<RectTransform>();
        partsRect.sizeDelta = new Vector2(350f, 150f);

        RectTransform infoRect = informationsButton.GetComponent<RectTransform>();
        infoRect.sizeDelta = new Vector2(350f, 150f);

        // Make sure the main buttons placed correctly
        partsButton.transform.localPosition = new Vector3(200f, 0f, 0f);
        informationsButton.transform.localPosition = new Vector3(-200f, 0f, 0f);

        // Disable or Enable the appropriate sub buttons
        DisableAllSubButtons();

        // Set the 3 sub button's locations to the default location of the canvas
        detailsButton.transform.localPosition = new Vector3(-800f, 0f, 0f);
        medicalUsesButton.transform.localPosition = new Vector3(-800f, 0f, 0f);
        triviaButton.transform.localPosition = new Vector3(-800f, 0f, 0f);
    }
    
    public void InformationButtonEntry()
    {
        InformationEntryStart();

        // Set Up for disabling the parts button and positioning at the default location
        RectTransform rect = partsButton.GetComponent<RectTransform>();
        LeanTween.moveLocalX(partsButton, defaultLocation, 0f);
        LeanTween.size(rect, new Vector2(350, 350), 0f);

        // Main Tweening part
        LeanTween.moveLocalX(informationsButton, -800f, 0.25f).setOnComplete(InformationButtonEntry2);
    }

    private void InformationButtonEntry2()
    {
        partsButton.SetActive(false);
        RectTransform rect = informationsButton.GetComponent<RectTransform>();

        LeanTween.size(rect, new Vector2(350, 350), 0.5f).setOnComplete(InformationButtonEntry3);
    }

    private void InformationButtonEntry3()
    {
        if(!detailsButton.activeSelf)
            detailsButton.SetActive(true);

        // Start Main Tweening for the sub buttons
        LeanTween.moveLocalX(detailsButton, -400f, 0.5f).setEaseOutBounce().setOnComplete(InformationButtonEntry4);
    }

    private void InformationButtonEntry4()
    {
        if(!medicalUsesButton.activeSelf)
            medicalUsesButton.SetActive(true);

        LeanTween.moveLocalX(medicalUsesButton, 0f, 0.5f).setEaseOutBounce().setOnComplete(InformationButtonEntry5);
    }

    private void InformationButtonEntry5()
    {
        if(!triviaButton.activeSelf)
            triviaButton.SetActive(true);

        LeanTween.moveLocalX(triviaButton, 400f, 0.5f).setEaseOutBounce();
    }
    #endregion

    #region Information Button Out Tween
        
    public void InformationButtonOutTween()
    {

        closeButton.transform.localPosition = new Vector3(550f, 200f, 0f);
        
        if(partsButton.activeSelf)
            partsButton.SetActive(false);
        if(!informationsButton.activeSelf)
            informationsButton.SetActive(true);

        RectTransform rect = partsButton.GetComponent<RectTransform>();
        rect.localPosition = new Vector3(-800f, 0f, 0f);
        rect.sizeDelta = new Vector2(350f, 350f);

        RectTransform infoRect = informationsButton.GetComponent<RectTransform>();
        infoRect.localPosition = new Vector3(-800f, 0f, 0f);
        infoRect.sizeDelta = new Vector2(350f, 350f);

        // Make sure all the partsButton's sub buttons are active
        if(plantButton.activeSelf)
            plantButton.SetActive(false);
        if(leafButton.activeSelf)
            leafButton.SetActive(false);
        if(stemButton.activeSelf)
            stemButton.SetActive(false);
        if(flowerButton.activeSelf)
            flowerButton.SetActive(false);

        // Make sure all the sub buttons of the Information button are active
        if(!detailsButton.activeSelf)
            detailsButton.SetActive(true);
        if(!triviaButton.activeSelf)
            triviaButton.SetActive(true);
        if(!medicalUsesButton.activeSelf)
            medicalUsesButton.SetActive(true);

        // Make sure the all the sub buttons are in the right position
        detailsButton.transform.localPosition = new Vector3(-400f, 0f, 0f);
        medicalUsesButton.transform.localPosition = new Vector3(0f, 0f, 0f);
        triviaButton.transform.localPosition = new Vector3(400f, 0f, 0f);

        // Main Tweening
        LeanTween.moveLocalX(detailsButton, -800f, 0.5f);
        LeanTween.moveLocalX(medicalUsesButton, -800f, 0.5f);
        LeanTween.moveLocalX(triviaButton, -800f, 0.5f).setOnComplete(InformationButtonOutTween2);
    }

    private void InformationButtonOutTween2()
    {
        // Disable Information Button's sub buttons
        if(detailsButton.activeSelf)
            detailsButton.SetActive(false);
        if(triviaButton.activeSelf)
            triviaButton.SetActive(false);
        if(medicalUsesButton.activeSelf)
            medicalUsesButton.SetActive(false);

        // Tweening for the Main buttons
        RectTransform infoRect = informationsButton.GetComponent<RectTransform>();

        LeanTween.size(infoRect, new Vector2(350f, 150f), 0.5f).setEaseInBack().setOnComplete(InformationButtonOutTween3);
    }

    private void InformationButtonOutTween3()
    {
        partsButton.SetActive(true);

        LeanTween.moveLocalX(informationsButton, -200f, 0.5f).setEaseOutBounce().setOnComplete(InformationButtonOutTween4);
    }

    private void InformationButtonOutTween4()
    {
        RectTransform rect = partsButton.GetComponent<RectTransform>();
        LeanTween.size(rect, new Vector2(350f, 150f), 0.5f).setEaseInBack().setOnComplete(InformationButtonOutTween5);
    }

    private void InformationButtonOutTween5() => LeanTween.moveLocalX(partsButton, 200f, 0.5f).setEaseOutBounce();

    #endregion

    #region Parts Button Entry Tween
        
    private void PartsButtonEntryStartingPoint()
    {
        closeButton.transform.localPosition = new Vector3(950f, 200f, 0f);

        // Make Sure that the 2 main buttons are active
        if(!partsButton.activeSelf)
            partsButton.SetActive(true);
        if(!informationsButton.activeSelf)
            informationsButton.SetActive(true);

        // Make sure that all the sub buttons are disabled
        DisableAllSubButtons();

        // Place all the sub buttons at the default position
        plantButton.transform.localPosition = new Vector3(-1000f, 0f, 0f);
        leafButton.transform.localPosition = new Vector3(-1000f, 0f, 0f);
        flowerButton.transform.localPosition = new Vector3(-1000f, 0f, 0f);
        stemButton.transform.localPosition = new Vector3(-1000f, 0f, 0f);


        // Make sure that the 2 main buttons are placed at the correct position
        // and also scaled at the correct size

        // Parts Button Starting Position
        RectTransform partsRect = partsButton.GetComponent<RectTransform>();
        partsRect.sizeDelta = new Vector2(350f, 150f);
        partsButton.transform.localPosition = new Vector3(200f, 0f, 0f);

        // Informations Button Starting Position
        RectTransform infoRect = informationsButton.GetComponent<RectTransform>();
        infoRect.sizeDelta = new Vector2(350f, 150f);
        informationsButton.transform.localPosition = new Vector3(-200f, 0f, 0f);
        
    }

    public void PartsButtonEntry()
    {
        PartsButtonEntryStartingPoint();

        // Start the Main Tweening
        LeanTween.moveLocalX(informationsButton, -1000f, 0.5f);
        LeanTween.moveLocalX(partsButton, -1000f, 0.5f).setOnComplete(PartsButtonEntry2);
    }
    
    private void PartsButtonEntry2()
    {
        informationsButton.SetActive(false);
        RectTransform rect = partsButton.GetComponent<RectTransform>();
        
        LeanTween.size(rect, new Vector2(350f, 350f), 0.3f).setOnComplete(PartsButtonEntry3);
    }

    private void PartsButtonEntry3()
    {
        plantButton.SetActive(true);
        LeanTween.moveLocalX(plantButton, -600f, 0.5f).setEaseOutBounce().setOnComplete(PartsButtonEntry4);
    }

    private void PartsButtonEntry4()
    {
        leafButton.SetActive(true);
        LeanTween.moveLocalX(leafButton, -200f, 0.5f).setEaseOutBounce().setOnComplete(PartsButtonEntry5);
    }

    private void PartsButtonEntry5()
    {
        stemButton.SetActive(true);
        LeanTween.moveLocalX(stemButton, 200f, 0.5f).setEaseOutBounce().setOnComplete(PartsButtonEntry6);
    }

    private void PartsButtonEntry6()
    {
        flowerButton.SetActive(true);
        LeanTween.moveLocalX(flowerButton, 600f, 0.5f).setEaseOutBounce();
    }

    #endregion

    #region Parts Button Out Tween
    
    private void PartsButtonOutStart()
    {
        // Make sure the activated buttons are correct
        if(!partsButton.activeSelf)
            partsButton.SetActive(true);
        if(informationsButton.activeSelf)
            informationsButton.SetActive(false);

        // Make sure that all the informationsButtons's sub buttons are disabled
        if(detailsButton.activeSelf)
            detailsButton.SetActive(false);
        if(triviaButton.activeSelf)
            triviaButton.SetActive(false);
        if(medicalUsesButton.activeSelf)
            medicalUsesButton.SetActive(false);

        // Make sure that all the partsButton's sub buttons are activated
        if(!plantButton.activeSelf)
            plantButton.SetActive(true);
        if(!leafButton.activeSelf)
            leafButton.SetActive(true);
        if(!stemButton.activeSelf)
            stemButton.SetActive(true);
        if(!flowerButton.activeSelf)
            flowerButton.SetActive(true);

        // Make sure that all the active buttons are placed and scaled correctly
        RectTransform rect = partsButton.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(350f, 350f);
        partsButton.transform.localPosition = new Vector3(-1000f, 0f, 0f);

        RectTransform infoRect = informationsButton.GetComponent<RectTransform>();
        infoRect.sizeDelta = new Vector2(350f, 350f);
        informationsButton.transform.localPosition = new Vector3(-1000f, 0f, 0f);

        plantButton.transform.localPosition = new Vector3(-600f, 0f, 0f);
        leafButton.transform.localPosition = new Vector3(-200f, 0f, 0f);
        stemButton.transform.localPosition = new Vector3(200f, 0f, 0f);
        flowerButton.transform.localPosition = new Vector3(600f, 0f, 0f);
    }

    public void PartsButtonOut()
    {
        PartsButtonOutStart();
        

        // Main Tweening for Parts Button Out
        LeanTween.moveLocalX(plantButton, -1000f, 0.5f);
        LeanTween.moveLocalX(leafButton, -1000f, 0.5f);
        LeanTween.moveLocalX(stemButton, -1000f, 0.5f);
        LeanTween.moveLocalX(flowerButton, -1000f, 0.5f).setOnComplete(PartsButtonOut2);
    }

    private void PartsButtonOut2()
    {
        plantButton.SetActive(false);
        leafButton.SetActive(false);
        stemButton.SetActive(false);
        flowerButton.SetActive(false);
        closeButton.transform.localPosition = new Vector3(550f, 200f, 0f);

        RectTransform rect = partsButton.GetComponent<RectTransform>();
        LeanTween.size(rect, new Vector2(350f, 150f), 0.5f).setEaseInBack().setOnComplete(PartsButtonOut3);
    }

    private void PartsButtonOut3()
    {
        informationsButton.SetActive(true);
        LeanTween.moveLocalX(partsButton, 200f, 0.5f).setEaseOutBounce().setOnComplete(PartsButtonOut4);
    }

    private void PartsButtonOut4()
    {
        RectTransform rect = informationsButton.GetComponent<RectTransform>();
        LeanTween.size(rect, new Vector2(350f, 150f), 0.5f).setEaseInBack().setOnComplete(PartsButtonOut5);
    }

    private void PartsButtonOut5()
    {
        LeanTween.moveLocalX(informationsButton, -200f, 0.5f).setEaseOutBounce();
    }

    #endregion

}
