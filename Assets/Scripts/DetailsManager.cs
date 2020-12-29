using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailsManager : MonoBehaviour
{
    public Text plantName;
    public Text plantInformation;
    public Text plantDescription;
    public Text plantFeatures;
    public Text planting;
    public Text propagating;

    public void SetDataPanel(string name, string info, string description, string features, string pla, string prop)
    {
        plantName.text = name;
        plantInformation.text = info;
        plantDescription.text = description;
        plantFeatures.text = features;
        planting.text = pla;
        propagating.text = prop;
    }

}
