/**
 * this file is part of ARGIS
 * 名称：ObjEarth.cs
 * 简述：模型展示类
 * 作者：wangguowei
 * 编辑: wangguowei  2017.10.02
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using HighlightingSystem;

public class AObjectUI : MonoBehaviour {

    /*模型面板参数*/
    public bool isModelListShow = true;     //模型面板是否显示
    public int modelListLocX = 500;         //模型面板的x坐标
    public int modelListLocY = 200;         //模型面板的y坐标
    public int modelBtnWidth = 80;          //模型按钮的宽
    public int modelBtnHeight = 40;         //模型按钮的高
    public float modelBtnSpaceX = 1.2f;     //模型按钮行间距
    public float modelBtnSpaceY = 1.2f;     //模型按钮列间距
    public int numPerRow = 2;               //面板每行的模型数

     /*CJT*/
    private  GameObject curObject;//当前鼠标点选的物体
    private GameObject curObject_1 = null;

    private void OnGUI() {
        if (isModelListShow) {
            showModelList();
        }
      
    }

    private void showModelList() {
        //TODO 这里静态绑定了四个按钮，需要改写成自适应宽高的对话框
        AObject[] modelList = AObjectManager.instance.modelList;
        int len = modelList.Length;
        for(int i = 0; i < len; i++) {
            int rowNum = (int)i / numPerRow;
            int colNum = i % numPerRow;
            float btnLocX = modelListLocX + modelBtnWidth * modelBtnSpaceX * colNum;
            float btnLocY = modelListLocY + modelBtnHeight * modelBtnSpaceY * rowNum;
            AObject model_i = modelList[i];
            string model_i_name = model_i.AObjName;

            if(GUI.Button(new Rect(btnLocX, btnLocY, modelBtnWidth, modelBtnHeight), new GUIContent(model_i_name))) {
                //EditManager.instance.changeState("addModel", model_i_name);
                EditJbState state = (EditJbState)EditManager.instance.changeState(new EditJbState());
                state.choosenJBName = model_i_name;
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       
    }
	
}
