using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PartSwitchScript : MonoBehaviour
{

    private string currentModel = null;

    public delegate void HidePlant();
    public static event HidePlant HidePlantModel;

    public delegate void HideLeaf();
    public static event HideLeaf HideLeafModel;

    public delegate void HideStem();
    public static event HideStem HideStemModel;

    private Button button;

    void Start() 
    {
        SwitchPart("Plant");
        currentModel = "Plant";
    }

    void OnEnable()
    {
        ButtonActionManager.ShowLeafCLicked += ShowLeafPart;
        ButtonActionManager.ShowPlantClicked += ShowPlantPart;
        ButtonActionManager.ShowStemClicked += ShowStemPart;

        PlantControls.PlantControlsTapped += ShowButtonCanvas;
    }

    void OnDisable() 
    {
        ButtonActionManager.ShowLeafCLicked -= ShowLeafPart;
        ButtonActionManager.ShowPlantClicked -= ShowPlantPart;
        ButtonActionManager.ShowStemClicked -= ShowStemPart;

        PlantControls.PlantControlsTapped -= ShowButtonCanvas;
    }

    private void SwitchPart(string partName)
    {
        // Disable All Child GameObject
        foreach(Transform part in transform)
        {
            if(part.name == "InformationCanvas")
                continue;
            if(part.name == "ButtonCanvas")
                continue;
            if(part.name == "PlantControls")
                continue;

            if(part.name != partName)
                part.gameObject.SetActive(false);
            else
                part.gameObject.SetActive(true);
        }
    }

    private bool HasPart(string partName)
    {
        foreach(Transform part in transform)
        {
            if(part.name == partName)
                return true;
        }

        return false;
    }

    private void HideCurrentModel()
    {
        if(currentModel == "Plant")
            HidePlantModel();
        else if(currentModel == "Leaf")
            HideLeafModel();
        else if(currentModel == "Stem")
            HideStemModel();
    }

    private void ShowLeafPart()
    {
        if(currentModel != "Leaf" && HasPart("Leaf"))
        {
            HideCurrentModel();
            StartCoroutine(ShowLeafPartDelay());
        }
        
    }

    private IEnumerator ShowLeafPartDelay()
    {
        yield return new WaitForSeconds(2f);

        SwitchPart("Leaf");
        currentModel = "Leaf";
    }

    private void ShowPlantPart()
    {
        if(currentModel != "Plant" && HasPart("Plant"))
        {
            HideCurrentModel();
            StartCoroutine(ShowPlantPartDelay());
        }

    }

    private IEnumerator ShowPlantPartDelay()
    {
        yield return new WaitForSeconds(2f);

        SwitchPart("Plant");
        currentModel = "Plant";
    }

    private void ShowStemPart()
    {
        if(currentModel != "Stem" && HasPart("Stem"))
        {
            HideCurrentModel();
            StartCoroutine(ShowStemPartDelay());
        }
        
    }

    private IEnumerator ShowStemPartDelay()
    {
        yield return new WaitForSeconds(2f);

        SwitchPart("Stem");
        currentModel = "Stem";
    }

    private void ShowButtonCanvas()
    {
        foreach(Transform part in transform)
        {
            if(part.name == "ButtonCanvas")
            {
                if(!part.gameObject.activeSelf)
                    part.gameObject.SetActive(true);
            }
        }
    }

}
