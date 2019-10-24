using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriber : MonoBehaviour
{
    public TMPro.TextMeshProUGUI itemDescriptionPrefab;
    public static string currentDescription;
    public static ItemDescriber instance { get; set; }

    void Start()
    {
        instance = this;
    }

    public void SetItemDescription(string newDescription)
    {
        itemDescriptionPrefab.GetComponent<TMPro.TextMeshProUGUI>().text = newDescription;
        currentDescription = newDescription;
    }
}
