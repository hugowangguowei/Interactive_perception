using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIPS : MonoBehaviour {
    public static TIPS instance;
    public GameObject tips;

    void Awake() {
        instance = this;
        tips = gameObject;
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
