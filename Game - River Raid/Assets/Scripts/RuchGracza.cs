using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class RuchGracza : MonoBehaviour
{

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform canon;
    public float fireRate;

    private float nextFire;
    private AudioSource weaponAudio;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, canon.position, canon.rotation);
            weaponAudio = GetComponent<AudioSource>();
            weaponAudio.Play();
        }
    }
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0, 0, rb.velocity.x * -tilt);
    }
}
