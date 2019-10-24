using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    static public GameObject currentWaste;
    public static Thrower instance { get; set; }
    public static int successCount = 0;
    public int numObjectsToThrowInt;
    public static int numObjectsToThrow;


    //instance

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //ideally, would take a GameObject of type ObjectsHolder;
        //that would contain an array or list of GameObjects;
        //numObjectsToThrow would = the length of that array or list
        numObjectsToThrow = numObjectsToThrowInt;
    }

    public static void SetWaste(GameObject throwingWaste)
    {
        currentWaste = throwingWaste;
        //currentWaste.gameObject.transform.SetParent(instance.gameObject.transform);
        //currentWaste.gameObject.transform.Translate(new Vector3(0, 0, 1) );

        //Debug.Log("assigned new waste");
    }

    public void Throw()
    {
        //Debug.Log("Throwing");
        Destroy(currentWaste);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
