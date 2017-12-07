using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMap2 : MonoBehaviour {
    public static SphereMap2 instance;
    public static GameObject btn_SphereMap2;
    private void Awake()
    {
        instance = this;
        btn_SphereMap2 = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
