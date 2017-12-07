using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
public class HoloUserClock : MonoBehaviour {
    public static HoloUserClock instance;
    public static GameObject userClockGB;
    public TextMesh clockTextMeshCmp;
    private void Awake()
    {
        instance = this;
        userClockGB = gameObject;
    }
    // Use this for initialization
    void Start () {
        clockTextMeshCmp = userClockGB.GetComponent<TextMesh>();

    }
	
	// Update is called once per frame
	void Update () {
        string dateTimeString= System.DateTime.Now.ToString();
        clockTextMeshCmp.text = System.DateTime.Now.ToString();
        //userClockGB.GetComponent<TextMesh>().text = "clock is enabled";

    }
}
