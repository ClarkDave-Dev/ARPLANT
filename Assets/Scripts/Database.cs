using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public Plant[] plants;

    private void Start() => plants = Resources.LoadAll<Plant>("Plants");
}
