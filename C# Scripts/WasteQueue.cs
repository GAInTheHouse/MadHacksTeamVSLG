using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteQueue : MonoBehaviour
{
    static public GameObject[] wasteQueue;
    public GameObject[] wasteQueueInitial;
    //static GameObject wasteToThrow;
    static int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        wasteQueue = wasteQueueInitial;
        NextItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void NextItem()
    {
        Debug.Log("Next Item called");
        if (wasteQueue.Length == 0 || index == wasteQueue.Length)
        {
            Debug.Log("That's every item!");
        }
        else
        {
            //wasteToThrow = Instantiate(wasteQueue[index]);
            Thrower.SetWaste(wasteQueue[index]);
            Debug.Log("index: " + index);
            ++index;
        }
    }
}
