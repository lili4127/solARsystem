using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Wand w;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, 25 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sun" && w.selected.gameObject.tag == "orbitclone")
        {
            this.transform.parent = other.gameObject.transform;
            this.transform.position = other.gameObject.transform.position;
        }

        if (other.gameObject.tag == "planetclone" && w.selected.gameObject.tag == "orbitclone")
        {
            this.transform.parent = other.gameObject.transform;
            this.transform.position = other.gameObject.transform.position;
        }

        if (other.gameObject.tag == "planetclone" && w.selected.gameObject.tag == "planetclone")
        {
            other.gameObject.transform.parent = this.transform;
        }

        if (other.gameObject.tag == "moonclone" && w.selected.gameObject.tag == "moonclone")
        {
            other.gameObject.transform.parent = this.transform;
        }
    }
}
