using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPStemAnimator : MonoBehaviour
{
    private void Start() 
    {
        gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 2f);
    }

    private void OnEnable() => PartSwitchScript.HideStemModel += StemExit;

    private void OnDisable() => PartSwitchScript.HideStemModel -= StemExit;    
    
    private void StemExit() => LeanTween.scale(gameObject, new Vector3(0f, 0f ,0f ), 2f);
}
