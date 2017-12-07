using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMapsCollection : MonoBehaviour {
    public static SphereMapsCollection instance;
    public static GameObject MapsCollectionGB;
    private void Awake()
    {
        instance = this;
        MapsCollectionGB = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
