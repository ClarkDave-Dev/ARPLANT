using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawPalmettoLeafAnimator : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable() 
    {
        PartSwitchScript.HideLeafModel += LeafExit;
    }

    void OnDisable() 
    {
        PartSwitchScript.HideLeafModel -= LeafExit;
    }

    private void LeafExit() => animator.SetBool("Exit", true);
}
