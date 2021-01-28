using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    [SerializeField]
    private ScrollRect scrollBar;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private CanvasGroup panelInfo;

    [SerializeField]
    private RectTransform infoPanel;

    [SerializeField]
    private Text text;

    [SerializeField]
    private Text infoText;


    private float firstValue = 0;
    private float lastValue = 0;
    private bool mousePos = false;
    private bool resetClick = false;
    private int elementID = -1;
    private int elementID2;


     public void OnPointerDown(PointerEventData eventData)
     {
         if (eventData.pointerCurrentRaycast.gameObject != null)
         {
             elementID = eventData.pointerCurrentRaycast.gameObject.GetComponent<newID>().ID;
            UIManager.Instance.quizPanel.GetComponent<newID>().ID = elementID;
          //   UpdTxt("Mouse Over: " + eventData.pointerCurrentRaycast.gameObject.GetComponent<newID>().ID.ToString());
         }
     }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstValue = Input.mousePosition.x;
            elementID2 = elementID;
            mousePos = true;
            //  UpdTxt(elementID.ToString());
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (panel.GetComponent<CanvasGroup>().alpha > 0)
            {
                for (float i = 0; i <= 1; i += Time.deltaTime * 2)
                {
                    // set color with i as alpha
                    panel.GetComponent<CanvasGroup>().alpha = i;
                    panelInfo.alpha -= Time.deltaTime * 2;

                }
                infoPanel.LeanSetLocalPosY(-400);
                elementID = -1;
            }
            mousePos = false;

        }
        if (mousePos && !resetClick)
        {
            //   UpdTxt(panel.GetComponent<newID>().ID.ToString());
            // UpdTxt(IDCheck.ToString());
            if (panel.GetComponent<newID>().ID == elementID2)
            {
                lastValue = Input.mousePosition.x;
                if (firstValue >= lastValue)
                {
                    panel.GetComponent<CanvasGroup>().alpha = 1 - ((firstValue - lastValue) / 400.0f);
                    panelInfo.alpha = ((firstValue - lastValue) / 400.0f) - 0.3f;
                    if (infoPanel.rect.y < 0 && panel.GetComponent<CanvasGroup>().alpha > 0)
                    {
                        this.infoPanel.localPosition = new Vector2(0, (firstValue - lastValue) - 400);
                    }
                    else if (panel.GetComponent<CanvasGroup>().alpha <= 0)
                    {
                        scrollBar.horizontalNormalizedPosition = 0;
                        infoPanel.localPosition = new Vector2(0, 0);
                        panelInfo.alpha = 1;
                        elementID = -1;
                    }
                }
            }
        }
        else
        {
        } 
        if (Input.GetMouseButtonDown(0) && panel.GetComponent<CanvasGroup>().alpha <= 0)
        {
            StartCoroutine(FadeIn(true));
        } 

    } 

    void UpdTxt(string s)
    {
        text.text = s;
    }

    IEnumerator FadeIn(bool fadein)
    {
        resetClick = true;
        infoPanel.LeanMoveLocalY(-400, 0.1f);
        for (float i = 0; i <= 1; i += Time.deltaTime*3)
        {
            // set color with i as alpha
            panel.GetComponent<CanvasGroup>().alpha = i;
            panelInfo.alpha -= Time.deltaTime*3;
            resetClick = false;
            yield return null;
        }
    }
}
