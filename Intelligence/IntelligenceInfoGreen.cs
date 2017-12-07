using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelligenceInfoGreen : MonoBehaviour {
    public static IntelligenceInfoGreen instance;
    public static GameObject IntelInfoGreen;
    void Awake()
    {
        instance = this;
        IntelInfoGreen = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
