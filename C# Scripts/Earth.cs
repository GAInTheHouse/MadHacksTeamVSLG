using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Earth : MonoBehaviour
{
    public RotatingTree treePrefab;
    List<RotatingTree> treesInAtmosphere = new List<RotatingTree>();
    int numTreesInAtmosphere;
    public static Earth instance { get; set; }
    public int numTreesToLaunch;
    float brightnessRate;
    Rigidbody rigidbody;
    SpriteRenderer spriteRenderer;
    public GameObject winningMessage;
    float endSceneTimer;
    bool countingDown;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        instance.rigidbody = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        brightnessRate = 1.0f / numTreesToLaunch;
        endSceneTimer = 0f;
        countingDown = false;
    }

    public void AddTree()
    {
        //treesInAtmosphere.Add(launchedTree);
        //launchedTree.transform.position = Earth.instance.transform.position;
        //Debug.Log(launchedTree.transform.position + " || " + Earth.instance.transform.position);
        RotatingTree newTree = Instantiate(treePrefab);
        newTree.transform.SetParent(Earth.instance.transform);
        newTree.transform.position = Earth.instance.transform.position;
        newTree.transform.Translate(new Vector3(0, 1, 0));
        ++instance.numTreesInAtmosphere;
        BrightenEarth();
    }

    void BrightenEarth()
    {
        Color currentRBG = instance.spriteRenderer.color;
        currentRBG.r += brightnessRate;
        currentRBG.b += brightnessRate;
        currentRBG.g += brightnessRate;
        instance.spriteRenderer.color = new Color(currentRBG.r, currentRBG.b, currentRBG.g);

        if (instance.numTreesInAtmosphere == instance.numTreesToLaunch)
        {
            //Debug.Log("You saved Earth!");
            winningMessage.SetActive(true);
            //instance.RadiateEarth()
            endSceneTimer = 3.0f;
            countingDown = true;
        }
    }

    // Update is called once per frame
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
                SceneManager.LoadScene("Quiz");
            }
        }

        void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    }
}
