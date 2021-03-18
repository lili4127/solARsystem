using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Wand w;
    public float s;

    // Start is called before the first frame update
    void Start()
    {
        s = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate orbit
        this.transform.Rotate(0, 0, s * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if orbit is held by wand and collided with sun make it the suns orbit
        if (other.gameObject.tag == "sun" && w.selected.gameObject.tag == "orbitclone")
        {
            this.transform.parent = other.gameObject.transform;
            this.transform.position = other.gameObject.transform.position;
        }

        //if orbit is held by wand and collided with planet make it the planets orbit
        if (other.gameObject.tag == "planetclone" && w.selected.gameObject.tag == "orbitclone")
        {
            this.transform.parent = other.gameObject.transform;
            this.transform.position = other.gameObject.transform.position;
        }

        //if planet is held by wand and collided with orbit attach it to orbit
        if (other.gameObject.tag == "planetclone" && w.selected.gameObject.tag == "planetclone")
        {
            other.gameObject.transform.parent = this.transform;
        }

        //if moon is held by wand and collided with orbit attach it to orbit
        if (other.gameObject.tag == "moonclone" && w.selected.gameObject.tag == "moonclone")
        {
            other.gameObject.transform.parent = this.transform;
        }
    }
}
