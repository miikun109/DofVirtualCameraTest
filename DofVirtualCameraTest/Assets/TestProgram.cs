using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TestProgram : MonoBehaviour
{
	public CinemachineVirtualCamera m_VirtualCameraStart;
	public CinemachineVirtualCamera m_VirtualCameraEnd;
	public CinemachineBrain m_Brain;
	
	public Volume m_Volume;
	
	private bool IsStartTest{set; get;}
	private float Timer{set; get;}

	private void Awake()
	{
		m_VirtualCameraStart.Priority = 10;
		m_VirtualCameraEnd.Priority = 0;
		Timer = m_Brain.m_DefaultBlend.m_Time;
	}

    void Update()
    {
	    if(IsStartTest)
	    {
		    Timer -= Time.deltaTime;
		    var stack = VolumeManager.instance.stack;
		    var dof = stack.GetComponent<DepthOfField>();
		    if(dof != null)
		    {
			    Debug.Log($"dof.aperture.value : {dof.aperture.value}");
		    }
		    if (Timer <= 0)
		    {
			    IsStartTest = false;
			    m_VirtualCameraStart.Priority = 10;
			    m_VirtualCameraEnd.Priority = 0;
		    }
	    }
        
    }

    private void OnGUI()
    {
	    if(!IsStartTest && GUILayout.Button("Start Test"))
	    {
		    IsStartTest = true;
		    m_VirtualCameraStart.Priority = 0;
		    m_VirtualCameraEnd.Priority = 10;
	    }
    }
}
