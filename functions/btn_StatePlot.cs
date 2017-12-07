using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_StatePlot : MonoBehaviour {
    public static btn_StatePlot instance;
    public static GameObject StatePlotBtn;
    private void Awake()
    {
        instance = this;
        StatePlotBtn = gameObject;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void selected()
    {
        //收不到消息
        gameObject.SendMessageUpwards("changeState", "addModel");
    }
}
