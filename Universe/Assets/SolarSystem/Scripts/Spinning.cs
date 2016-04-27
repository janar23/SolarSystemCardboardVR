﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Spinning : MonoBehaviour {

    public float rotationSpeed = 50.0f;
    int mercurySpeed = 10;
    int venusSpeed = 8;
    int earthSpeed = 7;
    int marsSpeed = 6;
    int jupiterSpeed = 5;
    int saturnSpeed = 4;
    int uranusSpeed = 3;
    int neptuneSpeed = 2;

    public string planet;
    public float OrbitDegrees = 1f;
    private int planetOrbitSpeed = 0;

    // Use this for initialization
    void Start () {
        switch (planet)
        {
            case "mercury":
                planetOrbitSpeed = mercurySpeed;
                break;
            case "venus":
                planetOrbitSpeed = venusSpeed;
                break;
            case "earth":
                planetOrbitSpeed = earthSpeed;
                break;
            case "mars":
                planetOrbitSpeed = marsSpeed;
                break;
            case "jupiter":
                planetOrbitSpeed = jupiterSpeed;
                break;
            case "saturn":
                planetOrbitSpeed = saturnSpeed;
                break;
            case "uranus":
                planetOrbitSpeed = uranusSpeed;
                break;
            case "neptune":
                planetOrbitSpeed = neptuneSpeed;
                break;
            default:
                planetOrbitSpeed = 0;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        //transform.position =
        //           RotatePointAroundPivot(transform.position,
        //                   transform.parent.position,
        //                   Quaternion.Euler(0, OrbitDegrees * Time.deltaTime * planetOrbitSpeed, 0));
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle)
    {
        return angle * (point - pivot) + pivot;
    }

    void OnEnable()
    {
        Cardboard.SDK.OnTrigger += TriggerPulled;
    }

    void OnDisable()
    {
        Cardboard.SDK.OnTrigger -= TriggerPulled;
    }

    void TriggerPulled()
    {
        Debug.Log("The trigger was pulled!");
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Scene Name = " + scene.name);
        if (scene.name == "SolarSystemInRow")
        {
            SceneManager.LoadScene("SolarSystemOrbiting");
        }      
    }
}
