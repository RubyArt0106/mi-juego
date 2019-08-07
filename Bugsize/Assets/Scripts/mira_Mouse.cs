using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mira_Mouse : MonoBehaviour
{
    bool verDerecha = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (delta.x >= 0 && !verDerecha)
        {
            transform.localScale = new Vector3(1, 1, 1);
            verDerecha = true;
        }
        else if (delta.x < 0 && verDerecha)
        {
            transform.localScale = new Vector3(-1, -1, 1);
            verDerecha = false;
        }
    }
}
