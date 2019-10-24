using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTree : MonoBehaviour
{
    public ParticleSystem rocketBurstPrefab;
    Rigidbody rigidbody;

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(Earth.instance.transform.position, new Vector3(0, 0, 1), 20 * Time.deltaTime);
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        ParticleSystem rocketBurst = Instantiate(rocketBurstPrefab, rigidbody.position, Quaternion.identity);
        rocketBurst.transform.parent = gameObject.transform;
    }
}
