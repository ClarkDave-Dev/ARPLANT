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
        ButtonCanvasActionManager.ShowLeafEvent += ShowLeafPart;
        ButtonCanvasActionManager.ShowPlantEvent += ShowPlantPart;
        ButtonCanvasActionManager.ShowStemEvent += ShowStemPart;
        ButtonCanvasActionManager.ShowFlowerEvent += ShowFlowerPart;

        PlantControls.PlantControlsTapped += ShowButtonCanvas;
    }

    void OnDisable() 
    {
        ButtonCanvasActionManager.ShowLeafEvent -= ShowLeafPart;
        ButtonCanvasActionManager.ShowPlantEvent -= ShowPlantPart;
        ButtonCanvasActionManager.ShowStemEvent -= ShowStemPart;
        ButtonCanvasActionManager.ShowFlowerEvent -= ShowFlowerPart;

        PlantControls.PlantControlsTapped -= ShowButtonCanvas;
    }

    private void SwitchPart(string partName)
    {
        FindObjectOfType<AudioManager>().Play("switch_part");

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

    private void CleanCanvas()
    {
        foreach(Transform panel in transform)
        {
            if(panel.name == "InformationCanvas")
                panel.gameObject.SetActive(false);
            if(panel.name == "ButtonCanvas")
                panel.gameObject.SetActive(false);
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
        CleanCanvas();
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

    private void ShowFlowerPart()
    {
        if(currentModel != "Flower" && HasPart("Flower"))
        {
            HideCurrentModel();
            StartCoroutine(ShowFlowerPartDelay());
        }
    }

    private IEnumerator ShowFlowerPartDelay()
    {
        yield return new WaitForSeconds(2f);

        SwitchPart("Flower");
        currentModel = "Flower";
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
