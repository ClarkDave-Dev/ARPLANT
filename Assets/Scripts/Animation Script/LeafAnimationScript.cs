using UnityEngine;

public class LeafAnimationScript : MonoBehaviour
{
    [SerializeField]
    private float x, y, z;

    private void OnEnable() 
    {
        LeafEntry();
        PartSwitchScript.HideLeafModel += LeafExit;
    }

    private void OnDisable() 
    {
        PartSwitchScript.HideLeafModel -= LeafExit;
    }

    private void LeafEntry()
    {
        gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        LeanTween.scale(gameObject, new Vector3(x, y, z), 3f);
    }

    private void LeafExit() => LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 3f);
}
