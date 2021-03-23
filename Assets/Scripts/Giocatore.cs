using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giocatoe : MonoBehaviour
{
    public Transform hips;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = hips.position;
    }
}
