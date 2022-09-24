using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{
    public GameObject Pj;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Pj.transform.position.x;
        position.y = Pj.transform.position.y;
        transform.position = position;
    }
}
