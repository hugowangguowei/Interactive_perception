using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeGreen_2 : MonoBehaviour {
    public static planeGreen_2 instance;
    public static GameObject GreenPlaneGB2;
    void Awake()
    {
        instance = this;
        GreenPlaneGB2 = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
