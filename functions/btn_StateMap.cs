using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_StateMap : MonoBehaviour {
    public static btn_StateMap instance;
    public static GameObject StateMapBtn;
    private void Awake()
    {
        instance = this;
        StateMapBtn = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void selected()
    {
        gameObject.SendMessageUpwards("changeState", "controlEarth");
        ObjEarth.instance.showMapsCollection();
    }
}
