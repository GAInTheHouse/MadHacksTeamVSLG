using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrashCan : MonoBehaviour
{
    public string canLabel;
    public GameObject dialogBox;
    float endSceneTimer;
    bool countingDown;

    //public GameObject testWastePrefab;
    //GameObject testWaste;

    void Start()
    {
        dialogBox.SetActive(false);
        endSceneTimer = 0;
        countingDown = false;
    }

    void Update()
    {
        if (countingDown)
        {
            if (endSceneTimer > 0)
            {
                endSceneTimer -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("MiniGame2Version2");
            }
        }
    }

    void OnMouseOver()
    {
        //Debug.Log("Calling dialog");
        DisplayDialog();
        //Debug.Log("Mouse is Over");
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clicked!");
            // Whatever you want it to do.
            if (Thrower.currentWaste != null)
            {
                SelectCan(Thrower.currentWaste);
            }
        }
    }

    void OnMouseExit()
    {
        CloseDialogBox();
    }

    public void SelectCan(GameObject waste)
    {
        if (waste.GetComponent<Waste>().wasteType.Equals(canLabel))
        {
            Thrower.instance.Throw();
            ItemDescriber.instance.SetItemDescription("Nice! You chose the right can!");
            //WasteQueue.NextItem();
            Thrower.successCount++;
            //Debug.Log("SuccessCount: " + Thrower.successCount);
            //Debug.Log(Thrower.successCount + "||" + Thrower.numObjectsToThrow);
            if (Thrower.successCount == Thrower.numObjectsToThrow)
            {
                ItemDescriber.instance.SetItemDescription("That's every item! Well done!");

                endSceneTimer = 3.0f;
                countingDown = true;
            }
        }
        else
        {
            ItemDescriber.instance.SetItemDescription("Whoops! Try putting it in a different can.");
        }

        OpenLid();
    }

    void DisplayDialog()
    {
        //Debug.Log("Calling dialog to display");
        dialogBox.SetActive(true);
    }

    void CloseDialogBox()
    {
        dialogBox.SetActive(false);
    }

    void OpenLid()
    {
        //Animate opening lid
    }
}
