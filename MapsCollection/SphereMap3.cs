using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMap3 : MonoBehaviour {
    public static SphereMap3 instance;
    public static GameObject btn_SphereMap3;
    private void Awake()
    {
        instance = this;
        btn_SphereMap3 = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
