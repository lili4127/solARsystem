using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonImageHandler : MonoBehaviour
{
    public GameObject m1;
    public GameObject m2;
    public GameObject m3;
    public GameObject m4;
    private int activeMoon;

    // Start is called before the first frame update
    void Start()
    {
        //set first moon object active
        m1.SetActive(true);
        m2.SetActive(false);
        m3.SetActive(false);
        m4.SetActive(false);
        activeMoon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //toggle which moon appears on image target
    public void NextMoon()
    {
        if (activeMoon == 0)
        {
            m1.SetActive(false);
            m2.SetActive(true);
            activeMoon = 1;
        }

        else if (activeMoon == 1)
        {
            m2.SetActive(false);
            m3.SetActive(true);
            activeMoon = 2;
        }

        else if (activeMoon == 2)
        {
            m3.SetActive(false);
            m4.SetActive(true);
            activeMoon = 3;
        }

        else if (activeMoon == 3)
        {
            m4.SetActive(false);
            m1.SetActive(true);
            activeMoon = 0;
        }
    }
}
