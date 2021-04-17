using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    public CinemachineFreeLook freeLook;
    void Start() {
        /*freeLook.m_XAxis.m_Recentering.m_RecenteringTime = 0.1f;
        freeLook.m_XAxis.m_Recentering.m_WaitTime = 0f;
        freeLook.m_XAxis.m_Recentering.m_enabled = true;*/
    }
    // Update is called once per frame
    void Update()
    {
        bool tieni = Input.GetButtonDown("Fire2");
        if (tieni)
        {

            //freeLook.m_XAxis.Value = 0;
            //freeLook.m_YAxis.m_Recentering.RecenterNow();
            freeLook.m_YAxisRecentering.RecenterNow();
            freeLook.m_RecenterToTargetHeading.RecenterNow();
            //Debug.Log(freeLook.m_XAxis.Value);
        }
    }
}
