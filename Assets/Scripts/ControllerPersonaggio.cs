using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPersonaggio : MonoBehaviour
{

    public Rigidbody rg;
    public Animator anim;
    public GameObject player;
    // Start is called before the first frame update
    
    void Start()
    {
        rg = player.GetComponent<Rigidbody>();
        anim = player.GetComponent<Animator>();
        print("Script personaggio caricato");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public float rotSpeed = 1f;


    
    // Update is called once per frame
    void Update()
    {

        float oriz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        bool attacca = Input.GetButtonDown("Fire1");
        bool tieni = Input.GetButton("Fire2");
        anim.SetBool("blocca", tieni);
        //Debug.Log(tieni);
        //Debug.Log(attacca);

        bool cammina = (oriz != 0 || vert != 0);
        if (attacca)
        {
            anim.SetTrigger("attacca");
        }
        //anim.SetFloat("x", oriz);
        if (cammina)
        {
            
            if (!tieni)
            {
                anim.SetFloat("y", Mathf.Sqrt((vert * vert) + (oriz * oriz)));
                float myAngle = Mathf.Round(Mathf.Atan2(oriz, vert) * Mathf.Rad2Deg);
                float bodyRotation = myAngle + Camera.main.transform.eulerAngles.y;
                player.transform.eulerAngles = Vector3.Lerp(player.transform.eulerAngles,
                    new Vector3(
                        player.transform.eulerAngles.x,
                        bodyRotation,
                        player.transform.eulerAngles.z
                ),
                    rotSpeed);
            }
            else
            {
                anim.SetFloat("x", oriz);
                anim.SetFloat("y", vert);
                if(FieldOfView.instance.visibleTargets.Count > 0)
                {
                    Transform target = FieldOfView.instance.visibleTargets[0];
                    player.transform.LookAt(new Vector3(target.position.x, player.transform.position.y, target.position.z));
                }
                
            }
            //Debug.Log("X: " + oriz + " \nY: " + vert);
        }
        // print("ORIZ: " + oriz);
        // print("VERT: " + vert);

        /*if (Input.GetAxis("Jump")!= 0 && !salto && !tieni)
        {
            rg.AddForce(Vector3.up * vel * 100);
            print("Salto");
            salto = true;
        }

        if ((Input.GetKey(KeyCode.C)|| Input.GetAxis("Fire1")!=0 )&& !salto && !tieni)
        {
            tieni = true;

        }
        if (Input.GetKeyUp(KeyCode.C) || Input.GetAxis("Fire1") == 0)
        {
            tieni = false;
        }
       if(Physics.Raycast(transform.position, Vector3.down, 0.1f))
        {
            salto = false;
        }
        anim.SetBool("tieni", tieni);
        anim.SetBool("salto", salto);*/
    }

    
    
}
