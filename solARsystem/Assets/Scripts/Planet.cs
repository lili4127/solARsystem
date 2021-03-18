using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Spin planet on it's axis. Can be seen when selecting planets from image target
        if (this.transform.parent.gameObject.tag != "orbitclone")
        {
            this.transform.Rotate(0, 50 * Time.deltaTime, 0);
        }
    }
}
