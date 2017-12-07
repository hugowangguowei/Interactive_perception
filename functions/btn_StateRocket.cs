using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_StateRocket : MonoBehaviour {
    public static btn_StateRocket instance;
    public static GameObject StateRocketBtn;
    private void Awake()
    {
        instance = this;
        StateRocketBtn = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
     public  void selected()
    {
        gameObject.SendMessageUpwards("changeState", "controlRocket");
    }
}
