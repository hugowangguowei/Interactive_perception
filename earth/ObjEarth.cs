/**
 * this file is part of ARGIS
 * 名称：ObjEarth.cs
 * 简述：地球模型控制类，提供地球属性控制接口
 * 作者：wangguowei
 * 编辑: wangguowei  2017.10.02
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjEarth : MonoBehaviour {
    
    /*地球模型对象单例模式实例*/
    public static ObjEarth instance;

    /*脚本所绑定的模型*/
    public static GameObject earth;
    
    /*纹理参数-储存纹理数组*/
    public static Texture2D[] earthTextures = new Texture2D[0];
    /*纹理参数-当前纹理标记*/
    public static int curTextureNum = 0;

    /*自转参数-是否自转*/
    public bool isRotate = false;
    public float rotateY = 0.1f;

    //地球文理集合MapsCollection
   // public static GameObject mapsCollectionArea;
    public static GameObject[] SphereMapsCollection=new GameObject[5];
    public static bool isInitMaps = false;

    //地球标绘模型集合
    public static GameObject[] PlotObjsCollection = new GameObject[5];
    public static bool isInitPlotObjsPanel = false;
    public static GameObject plotPan;

    public GameObject graticules;
    private void Awake(){
        instance = this;
        earth = gameObject;
        initTexture();
        isRotate = false;
        transform.Rotate(0, 130, 0);
        //      initMapsCollection();
    }

    void Start () {
	}

    /**
     * 初始化纹理 
     */
    private void initTexture(){
        if (earthTextures.Length == 0){
            earthTextures = new Texture2D[5];
            for(int i = 0; i < 5; i++){
                earthTextures[i] = (Texture2D)Resources.Load("map"+ (i+1));
            }
        }
    }

    void Update () {
        rotate();
	}

    /**
     * 更换纹理
     */
    public void changeTexture(){
        GetComponent<Renderer>().material.mainTexture = earthTextures[curTextureNum];
        curTextureNum++;
        if (curTextureNum >= earthTextures.Length)
        {
            curTextureNum = 0;
        }
        gameObject.SendMessageUpwards("onChangeMapTexture", curTextureNum);
    }
    /**
     * 更换纹理 重载1
     */
    public void changeTexture(int setTextureNum)
    {
        print("setTextureNum:"+ setTextureNum);
        gameObject.SendMessageUpwards("onDebugInfo", "change texture num:"+setTextureNum.ToString());
        GetComponent<Renderer>().material.mainTexture = earthTextures[setTextureNum];
        gameObject.SendMessageUpwards("onChangeMapTexture", setTextureNum);
    }
    public void rotate(){
        if (isRotate){
            transform.Rotate(0, rotateY, 0);
        }
        else{
            return;
        }
    }
    public void changeRotate() {
        isRotate = !isRotate;
    }
    public void changeRotate(bool rotateState)
    {
        isRotate = rotateState;
    }
    public void changeRotateSpeed(float speed){
        this.rotateY = speed;
    }
    void OnSelect() {
        changeRotate();
    }
    public bool showMapsCollection()
    {
        if(isInitMaps)
        {
            return false;
        }
        GameObject world = GameObject.Find("world");

        for (int i=0;i< 5;i++)
        {
            SphereMapsCollection[i] = Instantiate(Resources.Load<GameObject>("Prefabs/SphereModel/SphereMap" + (i + 1)));
            SphereMapsCollection[i].transform.parent = world.transform;
            if (SphereMapsCollection[i] == null)
                print("SphereMapsCollection" + i + "is null");
            else
                print(SphereMapsCollection[i].ToString());
        }
        SphereMapsCollection[0].transform.position = new Vector3((float)0.8, (float)0.3, 3);
        SphereMapsCollection[1].transform.position = new Vector3(1, (float)0.5, (float)3.2);
        SphereMapsCollection[2].transform.position = new Vector3(1, 0, 3);
        SphereMapsCollection[3].transform.position = new Vector3((float)1.5, (float)0.1, (float)3.2);
        SphereMapsCollection[4].transform.position = new Vector3((float)1.4, (float)0.4, (float)3);

        isInitMaps = true;
        return true;
    }
    public bool deleteMapsCollection()
    {
        for(int i=0;i< 5;i++)
        if (SphereMapsCollection[i] != null)
        {
            Destroy(SphereMapsCollection[i]);
            //gameObject.SendMessageUpwards("onDebugInfo", "deleteMapsCollection==null");
        }
        isInitMaps = false; 
        return true;
    }
    public bool showPlotObjsCollection(string test)
    {
        if (isInitPlotObjsPanel)
        {
            return false;
        }
        GameObject world = GameObject.Find("world");

        for (int i = 0; i < 5; i++)
        {
            PlotObjsCollection[i] = Instantiate(Resources.Load<GameObject>("Prefabs/PlotObjs/PlotObj" + (i + 1)));
            PlotObjsCollection[i].transform.parent = world.transform;
            if (PlotObjsCollection[i] == null)
                print("SphereMapsCollection" + i + "is null");
            else
                print(PlotObjsCollection[i].ToString());
        }
        PlotObjsCollection[0].transform.position = new Vector3((float)0.08, (float)-0.8, (float)2);
        PlotObjsCollection[1].transform.position = new Vector3((float)-0.086, (float)-0.75, (float)2);
        PlotObjsCollection[2].transform.position = new Vector3((float)0.25, (float)-0.8, (float)2.06);
        PlotObjsCollection[3].transform.position = new Vector3((float)-0, (float)-0.8, (float)1.8);
        PlotObjsCollection[4].transform.position = new Vector3((float)0.15, (float)-0.82, (float)1.86);

        isInitPlotObjsPanel = true;
        return true;
    }
    public bool showPlotObjsCollection() {
        
        if (isInitPlotObjsPanel) {
            return false;
        }
        GameObject world = GameObject.Find("world");
        plotPan = Instantiate(Resources.Load<GameObject>("Prefabs/PlotPan"));
        plotPan.transform.parent = world.transform;
        plotPan.transform.localPosition = new Vector3(0.6f, -0.8f, -0.25f);
        isInitPlotObjsPanel = true;
        return true;
    }
    public bool deletePlotObjsCollection(string test)
    {

        for (int i = 0; i < 5; i++)
            if (PlotObjsCollection[i] != null)
            {
                Destroy(PlotObjsCollection[i]);
            }
        isInitPlotObjsPanel = false;
        return true;
    }
    public bool deletePlotObjsCollection() {
        if(plotPan != null) {
            Destroy(plotPan);
        }
        isInitPlotObjsPanel = false;
        return true;
    }
    public bool addGraticule() {
        graticules = Instantiate(Resources.Load<GameObject>("Prefabs/world/graticules"));
        graticules.transform.parent = earth.transform;
        graticules.transform.localPosition = new Vector3(0, 0, 0);
        graticules.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        return true;
    }
    public bool deleteGraticule() {
        if(graticules != null) {
            Destroy(graticules);
        }
        return true;
    }

}
