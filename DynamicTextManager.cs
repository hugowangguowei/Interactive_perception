/**
 * this file is part of DYNAMICTEXT
 * 名称：DynamicTextManager.cs
 * 简述：动态文本管理器，用来测试动态文本的表现能力
 * 作者：wangguowei
 * 编辑: wangguowei  2017.10.29
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicTextManager : MonoBehaviour {

    public int frameNum = 10;
    public GameObject canvas;
    public float frameDis = 0.1f;
    private GameObject[] canvasList;
    public string[] infoList;
    private bool infoDirty = false;

    private int[,] graphData;
    private bool graphDataDirty = false;
    public float basicLenX = 8;
    public float basicLenY = 5;
    public float basicLenZ = 0.06f;


    private float _dataTime = 0.0f;
    private int _dataNum = 0;
    private float _graphDataTime = 0.0f;

    void Awake() {
        
        canvasList = new GameObject[frameNum];
        infoList = new string[frameNum];
        graphData = new int[10,6];
        for(int i =0;i< graphData.GetLength(0); i++) {
            for(int j = 0; j < graphData.GetLength(1); j++) {
                graphData[i, j] = 1;
            }
        }

        GameObject canvas_i;
        for(int i = 0; i < frameNum; i++) {
            canvas_i = Instantiate(canvas, new Vector3(0, 0, -1* i * frameDis), Quaternion.identity) as GameObject;
            canvas_i.transform.parent = gameObject.transform;
            canvas_i.transform.localPosition = new Vector3(0, 0, -1 * i * frameDis);
            canvas_i.transform.localScale = new Vector3(1, 1, 1);
            canvas_i.name = "pad_" + i;
            canvasList[i] = canvas_i;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //文本数据
        _dataTime += Time.deltaTime;
        generateData();
        if (infoDirty) {
            refreshData();
        }
        //二维图数据
        _graphDataTime += Time.deltaTime;
        generateGraphData();
        if (graphDataDirty) {
            refreshGraphData();
        }
    }
    /*生成文本数据*/
    public void generateData() {
        if (_dataTime >= 0.1) {
            _dataTime = 0;
            _dataNum++;
            float r = Random.Range(0, 10);
            if (r > 8) {
                insertData("important", "random");
            }
            else {
                insertData("data_" + _dataNum, "random");
            }
        }
    }
    /*插入文本数据*/
    public void insertData(string data,string divName) {
        for(int i = infoList.Length - 1; i >= 0; i--) {
            if(i != 0) {
                infoList[i] = infoList[i - 1];
            }
            else {
                infoList[0] = data;
            }
        }
        infoDirty = true;
    }
    /*更新文本数据*/
    public void refreshData() {
        GameObject canvas_i;
        for (int i = 0; i < canvasList.Length; i++) {
            canvas_i = canvasList[i];
            GameObject canvas = canvas_i.transform.Find("Canvas").gameObject;
            Text text = canvas.transform.Find("headerText").GetComponent<Text>();
            if(infoList[i] == "important") {
                text.text = "<color=#30FF30FF>" + infoList[i] + "</color>";
            }
            else {
                text.text = "<color=#30303080>" + infoList[i] + "</color>";
            }
        }
        infoDirty = false;
    }
    /*生成二维图数据*/
    public void generateGraphData() {
        if (_graphDataTime >= 0.1) {
            _graphDataTime = 0;
            int[] graphFrameData = new int[6];
            for (int i = 0; i < 6; i++) {
                int r = Random.Range(1, 11);
                graphFrameData[i] = r;
            }
            insertGraphData(graphFrameData);
        }
    }
    /*插入二维图数据*/
    public void insertGraphData(int[] graphFrameData) {
        int lenI = graphData.GetLength(0);
        int lenJ = graphData.GetLength(1);
        for (int i = graphData.GetLength(0) - 1; i >= 0; i--) {
            if (i != 0) {
                for (int j = 0; j < lenJ; j++) {
                    graphData[i, j] = graphData[i - 1, j];
                }
            }
            else {
                for (int j = 0; j < lenJ; j++) {
                    graphData[0, j] = graphFrameData[j];
                }
            }
        }
        graphDataDirty = true;
    }
    /*更新二维图数据*/
    public void refreshGraphData() {
        GameObject canvas_i;
        for(int i = 0; i < canvasList.Length; i++) {
            canvas_i = canvasList[i];
            GameObject canvas = canvas_i.transform.Find("Canvas").gameObject;
            GameObject graph1 = canvas.transform.Find("graph1").gameObject;
            GameObject graph2 = canvas.transform.Find("graph2").gameObject;
            GameObject graph3 = canvas.transform.Find("graph3").gameObject;
            GameObject graph4 = canvas.transform.Find("graph4").gameObject;
            GameObject graph5 = canvas.transform.Find("graph5").gameObject;
            GameObject graph6 = canvas.transform.Find("graph6").gameObject;

            //float basicLenX = 8;
            //float basicLenY = 5;
            graph1.transform.localScale = new Vector3(basicLenX, basicLenY * graphData[i, 0], basicLenZ);
            graph2.transform.localScale = new Vector3(basicLenX, basicLenY * graphData[i, 1], basicLenZ);
            graph3.transform.localScale = new Vector3(basicLenX, basicLenY * graphData[i, 2], basicLenZ);
            graph4.transform.localScale = new Vector3(basicLenX, basicLenY * graphData[i, 3], basicLenZ);
            graph5.transform.localScale = new Vector3(basicLenX, basicLenY * graphData[i, 4], basicLenZ);
            graph6.transform.localScale = new Vector3(basicLenX, basicLenY * graphData[i, 5], basicLenZ);


            
            Vector3 vect;
            vect = graph1.transform.localPosition;
            vect.y = basicLenY * graphData[i, 0] / 2 - 40;
            graph1.transform.localPosition = vect;
            vect = graph2.transform.localPosition;
            vect.y = basicLenY * graphData[i, 1] / 2 - 40;
            graph2.transform.localPosition = vect;
            vect = graph3.transform.localPosition;
            vect.y = basicLenY * graphData[i, 2] / 2 - 40;
            graph3.transform.localPosition = vect;
            vect = graph4.transform.localPosition;
            vect.y = basicLenY * graphData[i, 3] / 2 - 40;
            graph4.transform.localPosition = vect;
            vect = graph5.transform.localPosition;
            vect.y = basicLenY * graphData[i, 4] / 2 - 40;
            graph5.transform.localPosition = vect;
            vect = graph6.transform.localPosition;
            vect.y = basicLenY * graphData[i, 5] / 2 - 40;
            graph6.transform.localPosition = vect;
            
        }
        graphDataDirty = false;
    }

}
