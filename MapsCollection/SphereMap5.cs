using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMap5 : MonoBehaviour {
    public static SphereMap5 instance;
    public static GameObject btn_SphereMap5;
    private void Awake()
    {
        instance = this;
        btn_SphereMap5 = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
