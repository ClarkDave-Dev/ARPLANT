using UnityEngine;

public class StemAnimationScript : MonoBehaviour
{
    [SerializeField]
    private float x, y, z;

    private void OnEnable() 
    {
        StemEntry();
        PartSwitchScript.HideStemModel += StemExit;
    }

    private void OnDisable() 
    {
        PartSwitchScript.HideStemModel -= StemExit;
    }

    private void StemEntry()
    {
        gameObject.transform.localScale = new Vector3(0f, 0f, 0f);

        LeanTween.scale(gameObject, new Vector3(x, y, z), 3f);
    }

    private void StemExit() => LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 3f);
}
