using UnityEngine;
using UnityEngine.UI;

public class PlantControls : MonoBehaviour
{
    [SerializeField]
    private Button controlsButton;

    private ButtonCanvasActionManager manager;

    public delegate void PlantControl();
    public static event PlantControl PlantControlsTapped;

    private void Start() 
    {
        controlsButton.onClick.AddListener(ShowPlantControls);
    }

    private void ShowPlantControls()
    {
        if(PlantControlsTapped != null)
            PlantControlsTapped();
    }
}
