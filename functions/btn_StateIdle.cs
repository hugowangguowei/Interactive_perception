using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_StateIdle : MonoBehaviour {

    public static btn_StateIdle instance;
    public static GameObject StateIdleBtn;
    private void  Awake()
    {
        instance = this;
        StateIdleBtn = gameObject;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void selected()
    {
        gameObject.SendMessageUpwards("changeState", "idle");
        gameObject.SendMessageUpwards("onDebugInfo", "btn_stateIdle Send changeState Message");
    }
}
