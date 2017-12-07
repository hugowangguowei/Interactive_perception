/**
 * this file is part of ARGIS
 * 名称：EditManager.cs
 * 简述：编辑管理类，作为所有输入事件的入口，根据当前的编辑状态
 *       分配给各自的模块处理输入事件。
 * 作者：wangguowei
 * 编辑: wangguowei  2017.10.02
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;//高亮插件

public class EditManager : MonoBehaviour {
    public static EditManager instance;
    public EditState state;
    public string choosenModelName;
    public Camera mainCamera;

    private void Awake() {
        instance = this;
        choosenModelName = "bh10";
        changeState(new EditIdleState());
    }

    void Start () {
		
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            MouseLocResult locResult = getMouseLoc();
            if (locResult.isHitted()) {
                RaycastHit hitInfo = locResult.getHit();
                objectSelect(hitInfo);
            }
        }
	}
    
    /*输入监听==========================================================================*/
    
    /*监听来自语音输入的状态改变*/
    void speechInput_changeState() {
    }
    
    /*监听来自语音输入的调试信息*/
    void speechInput_debugInfo(string info) {
        gameObject.SendMessageUpwards("onDebugInfo", info);
    }
    
    void gazeInput_objectSelect(RaycastHit hitInfo) {
        objectSelect(hitInfo);
    }

    /*核心处理输入处理函数==============================================================*/
    
    /*对象被选中*/
    void objectSelect(RaycastHit hitInfo) {
        GameObject selectedObj = hitInfo.collider.gameObject;
        /////////////gaze主面板切换当前状态↓
        if (selectedObj == btn_StateIdle.StateIdleBtn)
        {
            gameObject.SendMessageUpwards("onDebugInfo", "pressDownIdleState");
            changeState(new EditIdleState());
        }
        if (selectedObj == btn_StateMap.StateMapBtn)
        {
            gameObject.SendMessageUpwards("onDebugInfo", "pressDownMapState");
            changeState(new EditMapState());
        }
        if (selectedObj == btn_StatePlot.StatePlotBtn)
        {
            gameObject.SendMessageUpwards("onDebugInfo", "pressDownPlotState");
            changeState(new EditJbState());
        }
        if (selectedObj == btn_StateRocket.StateRocketBtn)
        {
            gameObject.SendMessageUpwards("onDebugInfo", "sa");
            changeState(new EditRocketState());
        }
        /////////////gaze主面板切换当前状态↑
        /////////////gaze小键盘操作↓
        //初始化火箭
        if(selectedObj.name == "Cube12")
        {
            RocketsManager.instance.AddRocket(1);
        }
        //火箭暂停
        if(selectedObj.name == "Cube13")
        {
            RocketsManager.instance.top().setState(Rocket.s1);

        }
        //火箭发射/继续
        if(selectedObj.name == "Cube14")
        {
            RocketsManager.instance.top().setState(Rocket.s2);
        }
        //删除标号
        if (selectedObj.name == "Cube21"){
            ArrayList list = AObjectManager.instance.selectedJbList;
            
            for (int i = list.Count - 1; i >= 0; i--) {
                AObjectManager.instance.removeAObject((AObject)list[i]);
            }
        }
        //放大标号
        if (selectedObj.name == "Cube22") {
            ArrayList list = AObjectManager.instance.selectedJbList;
            GameObject go;
            //TODO 应该将标号放大添加到AObjectManager中
            foreach (AObject obj in list) {
                go = obj.getGameObject();
                float scale = (float)1.5 * go.transform.localScale.x;
                float scale2 = (float)1.5 * go.transform.localScale.y;
                float scale3 = (float)1.5 * go.transform.localScale.z;
                go.transform.localScale = new Vector3(scale, scale2, scale3);
            }
        }
        //缩小标号
        if (selectedObj.name == "Cube23") {
            ArrayList list = AObjectManager.instance.selectedJbList;
            GameObject go;
            //TODO 应该将标号放大添加到AObjectManager中
            foreach (AObject obj in list) {

                go = obj.getGameObject();
                float scale = (float)0.8 * go.transform.localScale.x;
                float scale2 = (float)0.8 * go.transform.localScale.y;
                float scale3 = (float)0.8 * go.transform.localScale.z;
                go.transform.localScale = new Vector3(scale, scale2, scale3);
            }
        }
        //旋转标号
        if (selectedObj.name == "Cube24") {
            ArrayList list = AObjectManager.instance.selectedJbList;
            GameObject go;
            foreach (AObject obj in list) {
                go = obj.getGameObject();
                float rotateX = (float)0.8 * go.transform.localRotation.x;
                float rotateY = (float)0.8 * go.transform.localRotation.y;
                float rotateZ = (float)0.8 * go.transform.localRotation.z;
                go.transform.Rotate(rotateX, rotateY+10, rotateZ);
            }
        }
        //旋转地球
        if (selectedObj.name == "Cube31")
        {
            ObjEarth.instance.changeRotate();
        }
        //删除地形
        if (selectedObj.name == "Cube32")
        {
            LandformManager.instance.removeLandform();
        }
        //卫星显隐
        if (selectedObj.name == "Cube33") {
            SatelliteManager.instance.changeShowState();
        }
        /////////////gaze小键盘操作↑
        /////////////gaze标绘面板操作↓
        for(int i=1;i<11;i++)
        {
            string bhName = "bh" + i.ToString();
            if (selectedObj.name == bhName)
            {
                EditJbState jbState = (EditJbState)changeState(new EditJbState());
                jbState.setChoosenJBName(bhName);
            }
        }
        /////////////gaze标绘面板操作↑
        if(selectedObj.name == "action(Clone)") {
            RoutinePlayer.instance.play();
        }
        state.choosenObj(hitInfo);
    }
    
    /*更改编辑状态*/
    public EditState changeState(EditState newState) {
        if (state != null) {
            state.hideComponents();
        }
        
        newState.showComponents();
        state = newState;
        gameObject.SendMessageUpwards("onChangeState", newState.stateName);
        return newState;
    }
    
    /*鼠标位置结构体*/
    public struct MouseLocResult {
        bool hitted;
        RaycastHit hit;
        public MouseLocResult(bool a,RaycastHit b) {
            hitted = a;
            hit = b;
        }
        public bool isHitted() {
            return hitted;
        }
        public RaycastHit getHit() {
            return hit;
        }
    }

    /*获取电脑端运行鼠标点击的位置*/
    public MouseLocResult getMouseLoc() {
        RaycastHit hit;
        
        Vector3 dianV = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(dianV);

        if (Physics.Raycast(ray, out hit)) {
            return new MouseLocResult(true, hit);
        }
        return new MouseLocResult(false, default(RaycastHit));
    }
    
    /*测试函数==========================================================================*/

    /*测试函数1*/
    private int testCount = 0;
    public void testHandle() {
        testCount = (testCount + 1) % 2;

        changeState(new EditJbState());
        MouseLocResult locResult = getMouseLoc();
        if (locResult.isHitted()) {
            GameObject gb = locResult.getHit().collider.gameObject;
            if (gb == ObjEarth.earth) {
                //AObjectManager.instance.addAObject(choosenModelName, locResult.getHit().point, locResult.getHit());
            }
            else {
                if (gb.name == "Cube21") {
                    ArrayList list = AObjectManager.instance.selectedJbList;
                    for (int i = list.Count - 1; i >= 0; i--) {
                        AObjectManager.instance.removeAObject((AObject)list[i]);
                    }
                }
                if (gb.name == "Cube22") {
                    ArrayList list = AObjectManager.instance.selectedJbList;
                    GameObject go;
                    foreach (AObject obj in list) {
                        go = obj.getGameObject();
                        float scale = (float)1.5 * go.transform.localScale.x;
                        float scale2 = (float)1.5 * go.transform.localScale.y;
                        float scale3 = (float)1.5 * go.transform.localScale.z;
                        go.transform.localScale = new Vector3(scale, scale2, scale3);
                    }
                }
                if (gb.name == "Cube23") {
                    ArrayList list = AObjectManager.instance.selectedJbList;
                    GameObject go;
                    foreach (AObject obj in list) {
                        go = obj.getGameObject();
                        float scale = (float)0.8 * go.transform.localScale.x;
                        float scale2 = (float)0.8 * go.transform.localScale.y;
                        float scale3 = (float)0.8 * go.transform.localScale.z;
                        go.transform.localScale = new Vector3(scale, scale2, scale3);
                    }
                }
                if (gb.name == "Cube24") {
                    ArrayList list = AObjectManager.instance.selectedJbList;
                    GameObject go;
                    foreach (AObject obj in list) {
                        go = obj.getGameObject();
                        float rotateX = (float)0.8 * go.transform.localRotation.x;
                        float rotateY = (float)0.8 * go.transform.localRotation.y;
                        float rotateZ = (float)0.8 * go.transform.localRotation.z;
                        go.transform.Rotate(rotateX, rotateY + 10, rotateZ);
                    }
                }
            }

            state.choosenObj(locResult.getHit());
        }
    }
    /*测试函数2*/
    public void testHandle2() {
        IdleManager.instance.showCube("place");
    }

}
