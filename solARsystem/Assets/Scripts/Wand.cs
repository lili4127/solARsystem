using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wand : MonoBehaviour
{
    MeshRenderer wandMesh;
    Material og;

    public Material collided;

    public Button sel;
    bool se;

    public Button pos;
    public bool p;

    public Button rot;
    public bool r;

    public Button sca;
    public bool sc;
    //scaling variables
    float scaleRate = 0.3f;
    float minScale = 1f;
    float maxScale = 2f;
    float speed = 2f;

    public Button del;
    bool d;
    public Material deletion;

    public Button toggleOrbit;
    bool orbitVisible;

    GameObject currentTarget;
    public GameObject selected;
    Transform par;
    Transform spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        wandMesh = this.GetComponent<MeshRenderer>();
        og = wandMesh.material;
        par = this.transform.parent;
        spawnPos = par.GetChild(0);

        se = false;
        p = false;
        r = false;
        sc = false;
        d = false;
        orbitVisible = true;
        toggleOrbit.GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (d)
        {
            wandMesh.material = deletion;
        }

        if (!orbitVisible && GameObject.FindGameObjectsWithTag("orbitclone").Length != 0)
        {
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("orbitclone"))
            {
                o.GetComponent<Renderer>().enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        wandMesh.material = collided;
        currentTarget = other.gameObject;
    }

    private void OnTriggerStay(Collider other)
    {
        wandMesh.material = collided;
        currentTarget = other.gameObject;

        if (d && other.gameObject.name.Contains("Clone"))
        {
            Destroy(other.gameObject);
        }

        if (p && other.gameObject.name.Contains("Clone"))
        {
            currentTarget.transform.parent = spawnPos.transform;
        }

        if (r && other.gameObject.name.Contains("Clone"))
        {
            currentTarget.transform.rotation = spawnPos.transform.rotation;
        }

        if (sc && other.gameObject.name.Contains("Clone"))
        {
            Scale(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        wandMesh.material = og;
    }

    public void Selected()
    {
        if (!se)
        {
            se = true;
            sel.GetComponent<Image>().color = Color.green;

            if(currentTarget.tag == "orbit")
            {
                selected = Instantiate(currentTarget, spawnPos, true) as GameObject;
                selected.tag = "orbitclone";
            }

            else if (currentTarget.tag == "planet" || currentTarget.tag == "planetclone")
            {
                selected = Instantiate(currentTarget, spawnPos, true) as GameObject;
                selected.tag = "planetclone";
            }

            else if (currentTarget.tag == "moon" || currentTarget.tag == "moonclone")
            {
                selected = Instantiate(currentTarget, spawnPos, true) as GameObject;
                selected.tag = "moonclone";
            }

        }

        else if (se)
        {
            se = false;
            sel.GetComponent<Image>().color = Color.white;
        }
    }

    public void Positioned()
    {
        if (!p)
        {
            se = false;
            sel.GetComponent<Image>().color = Color.white;
            p = true;
            pos.GetComponent<Image>().color = Color.green; 
        }

        else if (p)
        {
            p = false;
            pos.GetComponent<Image>().color = Color.white;
        }
    }

    public void Rotated()
    {
        if (!r)
        {
            r = true;
            rot.GetComponent<Image>().color = Color.green;
        }

        else if (r)
        {
            r = false;
            rot.GetComponent<Image>().color = Color.white;
        }
    }

    public void Scaled()
    {
        if (!sc)
        {
            sc = true;
            sca.GetComponent<Image>().color = Color.green;
        }

        else if (sc)
        {
            sc = false;
            sca.GetComponent<Image>().color = Color.white;
        }
    }

    void ApplyScaleRate(GameObject g)
    {
        g.transform.localScale += Vector3.one * scaleRate * Time.deltaTime * speed;
    }

    //scale the ring larger or smaller based on its current size
    void Scale(GameObject g)
    {
        //if we exceed the defined range then correct the sign of scaleRate.
        if (g.transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (g.transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        ApplyScaleRate(g);
    }

    public void Deleted()
    {
        if (!d)
        {
            d = true;
            del.GetComponent<Image>().color = Color.green;
            wandMesh.material = deletion;
        }

        else if (d)
        {
            d = false;
            del.GetComponent<Image>().color = Color.white;
        }
    }

    public void ToggleOrbit()
    {
        if (!orbitVisible)
        {
            orbitVisible = true;
            toggleOrbit.GetComponent<Image>().color = Color.green;

            foreach (GameObject o in GameObject.FindGameObjectsWithTag("orbitclone"))
            {
                o.GetComponent<Renderer>().enabled = true;
            }    
        }

        else if (orbitVisible)
        {
            orbitVisible = false;
            toggleOrbit.GetComponent<Image>().color = Color.white;
        }
    }
}
