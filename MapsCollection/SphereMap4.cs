using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMap4 : MonoBehaviour {
    public static SphereMap4 instance;
    public static GameObject btn_SphereMap4;
    private void Awake()
    {
        instance = this;
        btn_SphereMap4 = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
