using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour {

    // Use this for initialization
    public static Debugger instance;
    void Awake() {
        instance = this;
    }
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showMessage(string msg) {
        gameObject.SendMessageUpwards("onDebugInfo", msg);
    }

}
