using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plant Name", menuName = "Plant")]
public class Plant : ScriptableObject
{
    public GameObject plantPrefab;

    // UI Data
    public string commonName;
    public string botanicalName;
    public Sprite plantImage;


    // Plant Detailed Informations
    [Multiline]
    public string plantDetails;

    [Multiline]
    public string plantTrivia;

    [Multiline]
    public string plantMedicalUses;

    [Multiline]
    public string plantGeneralInfo;
}
