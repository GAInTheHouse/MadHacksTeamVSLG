using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : MonoBehaviour
{
    public string wasteType;
    public string specificType;
    public string wasteName;
    bool stillOn = false;

    void OnMouseOver()
    {
        
        //Debug.Log("Mouse is Over Waste");
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clicked!");
            // Whatever you want it to do.
            Thrower.SetWaste(this.gameObject);
        }

        if (!stillOn)
        {
            ItemDescriber.instance.SetItemDescription(ToStringRepresentation());
        }
        stillOn = true;
    }

    void OnMouseExit()
    {
        stillOn = false;
        ItemDescriber.instance.SetItemDescription("");
    }

    string ToStringRepresentation()
    {
        string revisedWasteType;
        if (wasteType == "AlumGlasPlast" || wasteType == "Other")
        {
            revisedWasteType = specificType;
        }

        else
        {
            revisedWasteType = wasteType;
        }
        return "The " + wasteName + " is made of " + revisedWasteType.ToLower() + ".";
    }

}
