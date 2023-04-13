using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    Rigidbody obstacle;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Obstacle") return;
        obstacle = other.GetComponent<Rigidbody>();
        Invoke("Launch", 0.2f);
    }

    void Launch()
    {
        obstacle.AddForce((obstacle.transform.position - transform.position).normalized * 20, ForceMode.Impulse);
    }
}