/**
 * this file is part of ARGIS
 * 名称：AObjectManager.cs
 * 简述：模型管理类
 * 作者：wangguowei
 * 编辑: wangguowei  2017.10.02
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AObjectManager : MonoBehaviour {

    public static AObjectManager instance;
    public string[] modelNameList;
    public AObject[] modelList;
    public ArrayList JbList = new ArrayList();
    public ArrayList selectedJbList = new ArrayList();
    public static AObject IntelligenceMarkTaiwan;
    public static AObject IntelligenceMarkJinan;
    public static bool isInitIntelligenceMarks=false;
    public static AObject TaiwanPlane1;
    public static AObject TaiwanPlane2;
    public static bool isPlaneExist=false;
    private void Awake() {
        instance = this;
        loadModel();
    }

    private void loadModel() {
        if(modelNameList.Length == 0) {
            /*加载默认模型*/
            /*CJT加了一些模型，把提前加载的目录更换为含有预制体更多的Button_prefab文件夹，这样也同时修正了原有的点击无反应的bug*/
            modelNameList = new string[10];
            
            modelNameList[0] = "bh1";
            modelNameList[1] = "bh2";
            modelNameList[2] = "bh3";
            modelNameList[3] = "bh4";
            modelNameList[4] = "bh5";
            modelNameList[5] = "bh6";
            modelNameList[6] = "bh7";
            modelNameList[7] = "bh8";
            modelNameList[8] = "bh9";
            modelNameList[9] = "bh10";
        }
        int len = modelNameList.Length;
        modelList = new AObject[len];
        for(int i = 0; i < len; i++) {
            string name_i = modelNameList[i];
            GameObject model_i = (GameObject)Resources.Load("Models/JB/newBH/" + name_i);
            if(model_i == null) {
                print("！！！！！载入失败");
            }
            AObject amodel_i = new AObject(name_i, model_i.transform);
            modelList[i] = amodel_i;
        }
        //载入预警情报地点预制体      

    }

    public bool addIntelligenceMarks(string name/*, Vector3 pos, RaycastHit hit*/)
    {
        if(isInitIntelligenceMarks)
        {
            return false;
        }
        //创建台湾、济南地点
        GameObject earth = ObjEarth.earth;
        GameObject IntellMarkTaiwan = (GameObject)Resources.Load("Prefabs/Intelligence/intelligenceMarkTaiwan");
        GameObject IntellMarkJinan = (GameObject)Resources.Load("Prefabs/Intelligence/intelligenceMarkJinan");
        IntelligenceMarkTaiwan = new AObject("intelligenceMarkTaiwan", IntellMarkTaiwan.transform);
        IntelligenceMarkJinan = new AObject("intelligenceMarkJinan", IntellMarkJinan.transform);
        var modelTrans = IntelligenceMarkTaiwan.AObjTransform;
        var modelTrans2= IntelligenceMarkJinan.AObjTransform;
        Transform child = GameObject.Instantiate(modelTrans, new Vector3(0,0,(float)0.4), Quaternion.identity);//在对应坐标下创建预制体
        Transform child2 = GameObject.Instantiate(modelTrans2, new Vector3(0, 0, (float)0.4), Quaternion.identity);//在对应坐标下创建预制体
        child.transform.parent = earth.transform;
        child2.transform.parent = earth.transform;
        child.transform.localPosition = new Vector3(-0.2331f, 0.2081f, 0.383f);
        child2.transform.localPosition = new Vector3(-0.1758f, 0.3259f, 0.3309f);
        IntelligenceMarkTaiwan = new AObject("intelligenceMarkTaiwan", child);
        IntelligenceMarkJinan = new AObject("intelligenceMarkJinan", child2);
        isInitIntelligenceMarks = true;
        return true;
    }
    public bool hideIntelligenceMarks(string name/*, Vector3 pos, RaycastHit hit*/)
    {
        if (isInitIntelligenceMarks==false)
        {
            return false;
        }
        if(IntelligenceMarkTaiwan!=null)
        {
            Debug.Log("taiwan is not null");
            AObjectManager.instance.removeAObject(IntelligenceMarkTaiwan);          
        }  
        if(IntelligenceMarkJinan!=null)
        {
            Debug.Log("jinan is not null");
            AObjectManager.instance.removeAObject(IntelligenceMarkJinan);
        }
        isInitIntelligenceMarks = false;
        return true;
    }
    public bool showIntelligenceDetail(string place)
    {
        if(!isInitIntelligenceMarks)
        {
            return false;
        }
        BroadcastMessage("setIdleStateTrue");
        BroadcastMessage("showTaiwanIntelligence");//text
        if(isPlaneExist)
        {
            return false;
        }

        GameObject TaiwanPlane11 = (GameObject)Resources.Load("Prefabs/Intelligence/planeGreen_1");
        TaiwanPlane1 = new AObject("TaiwanPlane1", TaiwanPlane11.transform);
        GameObject TaiwanPlane21 = (GameObject)Resources.Load("Prefabs/Intelligence/planeGreen_2");
        TaiwanPlane2 = new AObject("TaiwanPlane2", TaiwanPlane21.transform);
        var planeTrans1 = TaiwanPlane1.AObjTransform;
        Transform child1 = GameObject.Instantiate(planeTrans1, new Vector3(-0.94f, 0.4f, 2.93f), Quaternion.identity);
        child1.Rotate(0,-30,0);
        TaiwanPlane1 = new AObject(name, child1);
        var planeTrans2 = TaiwanPlane2.AObjTransform;
        Transform child2 = GameObject.Instantiate(planeTrans2, new Vector3(-1.41f, -0.49f, 1.89f), Quaternion.identity);
        child2.Rotate(0, -30, 0);
        TaiwanPlane2 = new AObject(name, child2);
        return true;
    }
    public bool hideIntelligenceDetail(string place)
    {
        BroadcastMessage("hideTaiwanIntelligence");//text
        if (TaiwanPlane1 != null){
            AObjectManager.instance.removeAObject(TaiwanPlane1);
            TaiwanPlane1 = null;
        }else {
            return false;
        }
            
        if (TaiwanPlane2 != null){
            AObjectManager.instance.removeAObject(TaiwanPlane2);
            TaiwanPlane2 = null;
        }
        else {
            return false;
        }
        return true;
    }
    private Transform getModel(string name) {
        for(int i = 0; i < modelList.Length; i++) {
            AObject model_i = modelList[i];
            if(model_i.AObjName == name) {
                return model_i.AObjTransform;
            }
        }
        return null;
    }

    public bool addAObject(string name,Vector3 pos, RaycastHit hit) {
        GameObject earth = ObjEarth.earth;
        var modelTrans = getModel(name);
        Transform child = GameObject.Instantiate(modelTrans, pos, Quaternion.identity);//在对应坐标下创建预制体
        child.transform.up = hit.normal;
        child.transform.parent = earth.transform;
        child.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        AObject new_Jb = new AObject(name,child);
        JbList.Add(new_Jb);
        setAObjSingleSelected(new_Jb);
        return true;
    }

    public bool removeAObject(AObject obj) {
        
        if (obj.isSelected) {
            selectedJbList.Remove(obj);
        }
        JbList.Remove(obj);
        GameObject go = obj.getGameObject();
        //DestroyImmediate(go,true);
        Destroy(go);
        
        return true;
    }

    public AObject getAObjByGameObject(GameObject go) {
        foreach(AObject ao in JbList) {
            if(ao.getGameObject() == go) {
                return ao;
            }
        }
        return null;
    }

    public void setAObjSingleSelected(AObject obj) {
        print("当前军标数量：" + JbList.Count);
        foreach(AObject obj_i in JbList) {
            if(obj_i == obj) {
                AObjSelected(obj);
            }
            else if(obj_i.isSelected){
                AObjUnselected(obj_i);
            }
        }
    }

    private void AObjSelected(AObject obj) {
        if (obj.isSelected) {
            return;
        }
        obj.changeSelect(true);
        selectedJbList.Add(obj);
    }

    private void AObjUnselected(AObject obj) {
        obj.changeSelect(false);
        selectedJbList.Remove(obj);
    }

    void Start () {
		
	}

	void Update () {
		
	}

}
