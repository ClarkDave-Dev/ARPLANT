using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAnimationScript : MonoBehaviour
{

    [SerializeField]
    private float x, y, z;

    [SerializeField]
    private string grow1;

    [SerializeField]
    private string grow2;

    [SerializeField]
    private string Idle2;


    [SerializeField]
    private float grow1Duration;

    [SerializeField]
    private float grow2Duration;

    Animator animator;

    private void OnEnable() 
    {
        gameObject.transform.localScale = new Vector3(x, y, z);

        animator = GetComponent<Animator>();
        
        ButtonActionManager.OnGrowPlantClicked += PlantGrow;
        PartSwitchScript.HidePlantModel += PlantExit;

        animator.SetBool(grow1, true);
        StartCoroutine(PlayIdle1());
    }

    private void OnDisable() 
    {
        ButtonActionManager.OnGrowPlantClicked -= PlantGrow;
        PartSwitchScript.HidePlantModel -= PlantExit;
    }

    private IEnumerator PlayIdle1()
    {
        yield return new WaitForSeconds(grow1Duration);

        animator.SetBool(grow1, false);
    }

    private IEnumerator PlayIdle2()
    {
        yield return new WaitForSeconds(grow2Duration);

        animator.SetBool(Idle2, true);
    }

    private void PlantGrow()
    {
        animator.SetBool(grow2, true);
        StartCoroutine(PlayIdle2());
    }

    private void PlantExit() => LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 3f);
}
