/**
 * this file is part of ARGIS
 * 名称：UIManager.cs
 * 简述：界面控制类：负责界面初始化、接收来自数据层的数据传递
 * 作者：wangguowei
 * 编辑: wangguowei  2017.10.22
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {
    public GameObject text_curState;
    public GameObject text_curMap;
    public GameObject text_curModel;
    public GameObject text_debug;

	void Start () {
        initDefaultText();
	}
    /*初始化默认的文本*/
    private void initDefaultText() {
        string currentStateChinese="未赋值";
        string curState = EditManager.instance.state.stateName;
        if (curState == "EditIdleState")   { currentStateChinese = "信息展示"; }
        if (curState == "EditJbState")     { currentStateChinese = "交互布局"; }
        if (curState == "EditRocketState") { currentStateChinese = "数据推演"; }
        if (curState == "EditMapState")    { currentStateChinese = "地理数据"; }
        text_curState.GetComponent<Text>().text = "当前状态为：" + currentStateChinese;
        //text_curMap.GetComponent<Text>().text = "当前地图为：" + ObjEarth.curTextureNum;
        //text_curModel.GetComponent<Text>().text = "当前标号为：" + EditManager.instance.choosenModelName;
        //text_debug.GetComponent<Text>().text = "debug：";
    }
	
	void Update () {
		
	}

    void onChangeState(string curState) {
        string currentStateChinese = "未赋值";
        if (curState == "EditIdleState")   { currentStateChinese = "信息展示"; }
        if (curState == "EditJbState")     { currentStateChinese = "交互布局"; }
        if (curState == "EditRocketState") { currentStateChinese = "数据推演"; }
        if (curState == "EditMapState")    { currentStateChinese = "地理数据"; }
        text_curState.GetComponent<Text>().text = "当前状态为：" + currentStateChinese;
    }

    void onChangeMapTexture(int textureNum) {
        //text_curMap.GetComponent<Text>().text = "当前地图为：" + ObjEarth.curTextureNum;
    }

    void onDebugInfo(string info) {
        //text_debug.GetComponent<Text>().text = "debug：" + info;
    }
}
