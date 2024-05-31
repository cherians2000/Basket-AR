using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceManager : MonoBehaviour
{
    private PlaceIndicator placeIndicator;
    public GameObject objectToPlace;
    public Button placeHoop;
    public GameObject plane;
    private GameObject newPlacedObject;
    public GameObject planeDetectText;
    public GameObject BallSpawner;

    private void Start()
    {
        BallSpawner.SetActive(false);
        placeHoop.gameObject.SetActive(false);
        placeIndicator = FindAnyObjectByType<PlaceIndicator>();
    }
    private void Update()
    {
        if (plane.activeSelf && plane != null)
        {
            placeHoop.gameObject.SetActive(true);
            planeDetectText.gameObject.SetActive(false);
            BallSpawner.SetActive(true);
        }

    }
    public void ClickToPlace()
    {
        newPlacedObject = Instantiate(objectToPlace,placeIndicator.transform.position,placeIndicator.transform.rotation);
        placeHoop.gameObject.SetActive(false);
    }

    public void DestoyHoop()
    {
        Destroy(newPlacedObject);
        if(placeHoop != null)
        {
            placeHoop.gameObject.SetActive(true);
        }
    }
}
