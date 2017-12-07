using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeGreen_1 : MonoBehaviour {
    public static planeGreen_1 instance;
    public static GameObject GreenPlaneGB1;
    void Awake()
    {
        instance = this;
        GreenPlaneGB1 = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
