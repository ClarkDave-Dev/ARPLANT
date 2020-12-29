using UnityEngine;
using UnityEngine.UI;

public class WorldSpacePanelScript : MonoBehaviour
{
    [SerializeField]
    private Button closePanelButton;

    private void Start() 
    {
        closePanelButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
