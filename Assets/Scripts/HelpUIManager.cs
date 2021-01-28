using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpUIManager : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject helpButtonContainer;

    [SerializeField]
    private Button helpButton;

    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private Button deployHelpButton;

    [SerializeField]
    private Button changeHelpButton;

    [SerializeField]
    private Button moveHelpButton;

    [SerializeField]
    private GameObject topText;

    public GameObject deployPanel;
    public GameObject changePanel;
    public GameObject movePanel;

    public GameObject deployHelp1;
    public GameObject deployHelp2;
    public GameObject deployHelp3;
    public GameObject deployHelp4;

    public GameObject changeHelp1;
    public GameObject changeHelp2;
    public GameObject changeHelp3;
    public GameObject changeHelp4;

    public GameObject moveHelp1;
    public GameObject moveHelp2;
    public GameObject moveHelp3;
    public GameObject moveHelp4;
    // Start is called before the first frame update
    void Start()
    {
        helpButton.onClick.AddListener(showHelpPanel);
        closeButton.onClick.AddListener(closeHelpPanel);
        // helpButton.onClick.AddListener(showHelpPanel);

        deployHelpButton.onClick.AddListener(showDeployHelp);
        changeHelpButton.onClick.AddListener(showChangeHelp);
        moveHelpButton.onClick.AddListener(showMoveHelp);

        deployHelp1.GetComponent<Button>().onClick.AddListener(deployStep1);
        deployHelp2.GetComponent<Button>().onClick.AddListener(deployStep2);
        deployHelp3.GetComponent<Button>().onClick.AddListener(deployStep3);

        changeHelp1.GetComponent<Button>().onClick.AddListener(changeStep1);
        changeHelp2.GetComponent<Button>().onClick.AddListener(changeStep2);
        changeHelp3.GetComponent<Button>().onClick.AddListener(changeStep3);

        moveHelp1.GetComponent<Button>().onClick.AddListener(moveStep1);
        moveHelp2.GetComponent<Button>().onClick.AddListener(moveStep2);
        moveHelp3.GetComponent<Button>().onClick.AddListener(moveStep3);

        closeButton.onClick.AddListener(closeHelp);
        closeButton.onClick.AddListener(backButton);

        topText.GetComponent<Button>().onClick.AddListener(backButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void showHelpPanel()
    {
        helpPanel.SetActive(true);
        helpButtonContainer.SetActive(false);
    }
    private void closeHelpPanel()
    {
        helpPanel.SetActive(false);
        topText.GetComponent<Text>().text = "HOW TO";
        topText.GetComponent<Text>().raycastTarget = false;
    }
    private void showDeployHelp()
    {
        deployPanel.SetActive(true);
        topText.GetComponent<Text>().text = "BACK";
        topText.GetComponent<Text>().raycastTarget = true;
    }
    private void showChangeHelp()
    {
        changePanel.SetActive(true);
        topText.GetComponent<Text>().text = "BACK";
        topText.GetComponent<Text>().raycastTarget = true;
    }
    private void showMoveHelp()
    {
        movePanel.SetActive(true);
        topText.GetComponent<Text>().text = "BACK";
        topText.GetComponent<Text>().raycastTarget = true;
    }
    private void deployStep1()
    {
        StartCoroutine(stepFade(deployHelp1));
        deployHelp1.GetComponent<Image>().raycastTarget = false;
        deployHelp2.GetComponent<Image>().raycastTarget = true;
    }
    private void deployStep2()
    {
        StartCoroutine(stepFade(deployHelp2));
        deployHelp2.GetComponent<Image>().raycastTarget = false;
        deployHelp1.GetComponent<Image>().raycastTarget = true;
        StartCoroutine(resetDeploySteps());
    }
    private void deployStep3()
    {
        StartCoroutine(stepFade(deployHelp3));
        deployHelp3.GetComponent<Image>().raycastTarget = false;
        deployHelp1.GetComponent<Image>().raycastTarget = true;
        StartCoroutine(resetDeploySteps());
    }
    private void changeStep1()
    {
        StartCoroutine(stepFade(changeHelp1));
        changeHelp1.GetComponent<Image>().raycastTarget = false;
        changeHelp2.GetComponent<Image>().raycastTarget = true;
    }
    private void changeStep2()
    {
        StartCoroutine(stepFade(changeHelp2));
        changeHelp2.GetComponent<Image>().raycastTarget = false;
        changeHelp3.GetComponent<Image>().raycastTarget = true;
    }
    private void changeStep3()
    {
        StartCoroutine(stepFade(changeHelp3));
        changeHelp3.GetComponent<Image>().raycastTarget = false;
        changeHelp1.GetComponent<Image>().raycastTarget = true;
        StartCoroutine(resetChangeSteps());
    }
    private void moveStep1()
    {
        StartCoroutine(stepFade(moveHelp1));
        moveHelp1.GetComponent<Image>().raycastTarget = false;
        moveHelp2.GetComponent<Image>().raycastTarget = true;
    }
    private void moveStep2()
    {
        StartCoroutine(stepFade(moveHelp2));
        moveHelp2.GetComponent<Image>().raycastTarget = false;
        moveHelp3.GetComponent<Image>().raycastTarget = true;
    }
    private void moveStep3()
    {
        StartCoroutine(stepFade(moveHelp3));
        moveHelp3.GetComponent<Image>().raycastTarget = false;
        moveHelp1.GetComponent<Image>().raycastTarget = true;
        StartCoroutine(resetMoveSteps());
    }
    private void closeHelp()
    {
        helpPanel.SetActive(false);
        deployPanel.SetActive(false);
        changePanel.SetActive(false);
        movePanel.SetActive(false);
        helpButtonContainer.SetActive(true);
        StartCoroutine(resetDeploySteps());
        StartCoroutine(resetChangeSteps());
        StartCoroutine(resetMoveSteps());
    }

    private void backButton()
    {
        movePanel.SetActive(false);
        deployPanel.SetActive(false);
        changePanel.SetActive(false);
        topText.GetComponent<Text>().text = "HOW TO";
        topText.GetComponent<Text>().raycastTarget = false;
        StartCoroutine(resetDeploySteps());
        StartCoroutine(resetChangeSteps());
        StartCoroutine(resetMoveSteps());
    }
    IEnumerator stepFade(GameObject step)
    {
        for (float i = 1; i > 0; i -= Time.deltaTime * 4)
        {
            step.GetComponent<CanvasGroup>().alpha = i;
            yield return null;
        }
    }
    IEnumerator resetDeploySteps()
    {
        deployHelp1.GetComponent<Image>().raycastTarget = true;
        deployHelp2.GetComponent<Image>().raycastTarget = false;
        yield return new WaitForSeconds(0.5f);
        deployHelp1.GetComponent<CanvasGroup>().alpha = 1;
        deployHelp2.GetComponent<CanvasGroup>().alpha = 1;
      //  deployHelp3.GetComponent<CanvasGroup>().alpha = 1;
    }
    IEnumerator resetMoveSteps()
    {
        moveHelp1.GetComponent<Image>().raycastTarget = true;
        moveHelp2.GetComponent<Image>().raycastTarget = false;
        moveHelp3.GetComponent<Image>().raycastTarget = false;
        yield return new WaitForSeconds(0.5f);
        moveHelp1.GetComponent<CanvasGroup>().alpha = 1;
        moveHelp2.GetComponent<CanvasGroup>().alpha = 1;
        moveHelp3.GetComponent<CanvasGroup>().alpha = 1;
    }
    IEnumerator resetChangeSteps()
    {
        changeHelp1.GetComponent<Image>().raycastTarget = true;
        changeHelp2.GetComponent<Image>().raycastTarget = false;
        changeHelp3.GetComponent<Image>().raycastTarget = false;
        yield return new WaitForSeconds(0.5f);
        changeHelp1.GetComponent<CanvasGroup>().alpha = 1;
        changeHelp2.GetComponent<CanvasGroup>().alpha = 1;
        changeHelp3.GetComponent<CanvasGroup>().alpha = 1;
    }
}
