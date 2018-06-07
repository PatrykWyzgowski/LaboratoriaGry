using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiszczenieAsteroidy : MonoBehaviour {

    public GameObject eksplozja;
    public GameObject graczEksplozja;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(eksplozja, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(graczEksplozja, other.transform.position, other.transform.rotation);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
