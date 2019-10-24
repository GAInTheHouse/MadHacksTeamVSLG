using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchingTree : MonoBehaviour
{
    public ParticleSystem rocketBurstPrefab;
    Rigidbody rigidbody;
    bool isWaitingToDestroy = false;
    float gameTimer = -1.0f;
    float addTreeTimer = -1.0f;
    bool isWaitingToAddTree = false;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnMouseOver()
    {
        //Debug.Log("Mouse is over tree");
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Clicked!");
            // Whatever you want it to do.
            ForestManager.instance.SelectTree(this);
        }
    }

    public void Launch()
    {
        //Debug.Log("Launching this tree");
        ParticleSystem rocketBurst = Instantiate(rocketBurstPrefab, rigidbody.position, rocketBurstPrefab.transform.rotation);
        rocketBurst.transform.SetParent(gameObject.transform);
        //gameTimer = 2.0f;
        addTreeTimer = 1.7f;
        //isWaitingToDestroy = true;
        isWaitingToAddTree = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWaitingToAddTree)
        {
            //transform.Translate(new Vector3(0, 0.2f, 0));
            Vector3 position = rigidbody.position;
            position += new Vector3(0, 0.2f, 0);
            rigidbody.MovePosition(position);
            if (addTreeTimer >= 0)
            {
                addTreeTimer -= Time.deltaTime;
            }
            else
            {
                Earth.instance.AddTree();
                Destroy(this.gameObject);
            }
        }
    }
}
