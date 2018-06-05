using UnityEngine;
using System.Collections;

public class RuchLasera : MonoBehaviour {

    public float laserSpeed;
    private Rigidbody rb;
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * laserSpeed;
	}
	
}
