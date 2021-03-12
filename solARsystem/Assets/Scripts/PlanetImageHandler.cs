using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetImageHandler : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    private int activePlanet;

    // Start is called before the first frame update
    void Start()
    {
        p1.SetActive(true);
        p2.SetActive(false);
        p3.SetActive(false);
        p4.SetActive(false);
        activePlanet = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextPlanet()
    {
        if(activePlanet == 0)
        {
            p1.SetActive(false);
            p2.SetActive(true);
            activePlanet = 1;
        }

        else if (activePlanet == 1)
        {
            p2.SetActive(false);
            p3.SetActive(true);
            activePlanet = 2;
        }

        else if (activePlanet == 2)
        {
            p3.SetActive(false);
            p4.SetActive(true);
            activePlanet = 3;
        }

        else if (activePlanet == 3)
        {
            p4.SetActive(false);
            p1.SetActive(true);
            activePlanet = 0;
        }
    }
}
