using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMap1 : MonoBehaviour {
    public static SphereMap1 instance;
    public static GameObject btn_SphereMap1;
    private void Awake()
    {
        instance = this;
        btn_SphereMap1 = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
