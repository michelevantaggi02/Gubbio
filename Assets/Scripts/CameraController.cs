using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    Vector3 offset;
    void Start() {
        offset = transform.position - Player.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public float lerpspeed = 0.025f;
    public float rotationSpeed = 500f;
    Vector3 velocity = Vector3.zero;
    Vector3 prevpos;
    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        transform.RotateAround(Player.transform.position, Vector3.up, mouseX);
        
        transform.LookAt(Vector3.Slerp(prevpos, Player.transform.position, lerpspeed));
        transform.position = Vector3.SmoothDamp(transform.position, Player.transform.position + offset,ref velocity, 0.05f);
        prevpos = Player.transform.position;
    }
}
