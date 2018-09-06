using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCanvas : MonoBehaviour {

    private Quaternion baseRotation;

	// Use this for initialization
	void Start ()
    {
        baseRotation = GameObject.Find("Main Camera").transform.rotation;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.rotation = baseRotation;
	}
}
