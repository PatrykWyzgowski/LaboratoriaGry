using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiszczenieAsteroidy : MonoBehaviour {

    public GameObject eksplozja;
    public GameObject graczEksplozja;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) 
        {
            return;
        }
        if (eksplozja != null)
        {
            Instantiate(eksplozja, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(graczEksplozja, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
