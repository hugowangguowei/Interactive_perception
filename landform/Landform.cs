﻿/**
 * this file is part of ARGIS
 * 名称：Landform.cs
 * 简述：地形对象展示类，提供小地形绑定的整体方案
 * 版权：华北计算技术研究所 CETC-15 
 * 作者：wangguowei
 * 编辑: wangguowei  2017.11.19
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Landform : MonoBehaviour {
    public static int defaultTerra_w = 1;
    public static int defaultTerra_h = 1;
    public static int defaultSegmentX = 250;
    public static int defaultSegmentY = 250;

    //材质和高度图
    public string heightMapName;
    public Texture2D diffuseMap;
    public Texture2D heightMap;
    public int _startX = 0;
    public int _startY = 0;
    public int _blockW = 1000;
    public int _blockH = 1000;

    //顶点、uv、索引信息
    private Vector3[] vertives;
    private Vector2[] uvs;
    private int[] triangles;

    //生成信息
    private Vector2 size;//长宽
    private float minHeight = -10;
    private float maxHeight = 10;
    private Vector2 segment;
    private float unitH;

    //面片mesh
    public GameObject terrain;
    public float terra_w = 1;
    public float terra_h = 1;
    public float terra_h_min = 0;
    public float terra_h_max = 0.1f;

    public GameObject landform;
    public GameObject table;
    public Landform(string mapName) {
        heightMapName = mapName;
        heightMap = (Texture2D)Resources.Load("Texture/landform/" + mapName);
        diffuseMap = (Texture2D)Resources.Load("Texture/landform/" + mapName + "_t");
        _startX = 0;
        _startY = 0;
        _blockW = heightMap.width;
        _blockH = heightMap.height;

        setLandform();
        SetTerrain(terra_w, terra_h, (uint)defaultSegmentX, (uint)defaultSegmentY, terra_h_min, terra_h_max);
        setRod();
        setTable();
    }

    public Landform(int segmentX,int segmentY,string mapName) {
        heightMap = (Texture2D)Resources.Load("Texture/landform/" + mapName);
        diffuseMap = (Texture2D)Resources.Load("Texture/landform/" + mapName + "_t");
        _startX = 0;
        _startY = 0;
        _blockW = heightMap.width;
        _blockH = heightMap.height;

        setLandform();
        SetTerrain(terra_w, terra_h, (uint)segmentX, (uint)segmentY, terra_h_min, terra_h_max);
        setRod();
    }

    public Landform(int x, int y, int width, int height, int segmentX, int segmentY, string mapName) {
        heightMap = (Texture2D)Resources.Load("Texture/landform/" + mapName);
        diffuseMap = (Texture2D)Resources.Load("Texture/landform/" + mapName + "_t");

        _startX = x;
        _startY = y;
        _blockW = width;
        _blockH = height;
        if (_startX >= heightMap.width) {
            _startX = 0;
        }
        if (_startY >= heightMap.height) {
            _startY = 0;
        }
        if (_startX + _blockW > heightMap.width) {
            _blockW = heightMap.width - _startX;
        }
        if (_startY + _blockH > heightMap.height) {
            _blockH = heightMap.height - _startY;
        }

        setLandform();
        SetTerrain(terra_w,terra_h,(uint)segmentX,(uint)segmentY,terra_h_min,terra_h_max);
        setRod();
    }
    
    //组件相关=================================================================================================
    public void setLandform() {
        GameObject world = GameObject.Find("world");
        landform = new GameObject();
        landform.name = "landform";
        landform.transform.parent = world.transform;
        landform.transform.position = new Vector3(0.7f, -0.3f, 2.5f);

        
        

    }
    //设置标尺
    private void setRod() {
        int interval = 10;
        float _x = terra_w / interval;
        for(int i = 0; i < interval; i++) {
            GameObject text = new GameObject();
            text.transform.parent = terrain.transform;
            text.transform.localPosition = new Vector3(i * _x, 0, 0);
            text.transform.localScale = new Vector3(0.01f, 0.01f, 0.05f);
            text.AddComponent<TextMesh>();
            text.GetComponent<TextMesh>().text = "120." + i;
            text.GetComponent<TextMesh>().fontSize = 30;
        }

        float _y = terra_h / interval;
        for(int i = 0; i< interval; i++) {
            GameObject text = new GameObject();
            text.transform.parent = terrain.transform;
            text.transform.localPosition = new Vector3(1, 0, i * _y);
            text.transform.localScale = new Vector3(0.01f, 0.01f, 0.05f);
            text.AddComponent<TextMesh>();
            text.GetComponent<TextMesh>().text = "30." + i;
            text.GetComponent<TextMesh>().fontSize = 30;
        }
    }
    //设置展示表
    private void setTable() {
        table = Instantiate(Resources.Load<GameObject>("Prefabs/landformInfoPad"));
       
        GameObject text1 = table.transform.Find("Text_1").gameObject;
        GameObject text2 = table.transform.Find("Text_2").gameObject;
        if(heightMapName == "taiwan1") {
            text1.GetComponent<TextMesh>().text = "当前区域:台湾台北(lon:119.18,lat:23.06)";
            text2.GetComponent<TextMesh>().text = "当前气温:11°C  当前风力:东偏北3级";
        }
        if(heightMapName == "jinan") {
            text1.GetComponent<TextMesh>().text = "当前区域:山东济南(lon:117.00,lat:36.40)";
            text2.GetComponent<TextMesh>().text = "当前气温:17°C  当前风力:东偏北2级";
        }

        table.transform.parent = landform.transform;
        table.transform.localPosition = new Vector3(0.5f, 0.25f, 0.5f);
    }
    //销毁landform
    public void destroy() {
        Debug.Log("销毁对象");
        GameObject.Destroy(landform);
    }
    
    //属性控制==================================================================================================
    
    //设置landform成为焦点
    public void focus() {
        if(table == null) {
            setTable();
        }
    }

    //设置landform失去焦点
    public void unfocus() {
        if(table != null) {
            Destroy(table);
            table = null;
        }
    }

    //地形相关==================================================================================================
    /// <summary>
    /// 通过参数生成地形
    /// </summary>
    /// <param name="width">地形宽度</param>
    /// <param name="height">地形长度</param>
    /// <param name="segmentX">宽度的段数</param>
    /// <param name="segmentY">长度的段数</param>
    /// <param name="min">最低高度</param>
    /// <param name="max">最高高度</param>
    public void SetTerrain(float width, float height, uint segmentX, uint segmentY, float min, float max) {
        Init(width, height, segmentX, segmentY, min, max);
        GetVertives();
        DrawMesh();
        terrain.transform.parent = landform.transform;
        terrain.transform.localPosition = new Vector3(0, 0, 0);
    }

    /// 初始化计算某些值
    private void Init(float width, float height, uint segmentX, uint segmentY, float min, float max) {
        size = new Vector2(width, height);
        maxHeight = max;
        minHeight = min;
        unitH = maxHeight - minHeight;
        segment = new Vector2(segmentX, segmentY);
        terrain = new GameObject();
        terrain.name = "terrain";
    }

    /*绘制网格*/
    private void DrawMesh() {
        Mesh mesh = terrain.AddComponent<MeshFilter>().mesh;
        terrain.AddComponent<MeshRenderer>();
        if (diffuseMap == null) {
            Debug.LogWarning("No material,Create diffuse!!");
            //diffuseMap = new Material(Shader.Find("Diffuse"));
            terrain.GetComponent<Renderer>().material.mainTexture = diffuseMap;
            //terrain.renderer.material.mainTexture = img;
        }
        if (heightMap == null) {
            Debug.LogWarning("No heightMap!!!");
        }
        terrain.GetComponent<Renderer>().material.mainTexture = diffuseMap;
        //terrain.GetComponent<renderer>
        //terrain.renderer.material = diffuseMap;
        //给mesh 赋值
        mesh.Clear();
        mesh.vertices = vertives;//,pos);
        mesh.uv = uvs;
        mesh.triangles = triangles;
        //重置法线
        mesh.RecalculateNormals();
        //重置范围
        mesh.RecalculateBounds();
    }

    /*生成顶点信息*/
    private Vector3[] GetVertives() {
        int sum = Mathf.FloorToInt((segment.x + 1) * (segment.y + 1));
        float w = size.x / segment.x;
        float h = size.y / segment.y;

        int index = 0;
        GetUV();
        GetTriangles();
        vertives = new Vector3[sum];
        for (int i = 0; i < segment.y + 1; i++) {
            for (int j = 0; j < segment.x + 1; j++) {
                float tempHeight = 0;
                //边缘设置为0
                if(i == 0 || i == segment.y || j == 0 || j == segment.x || heightMap == null) {
                    tempHeight = 0;
                }
                else {
                    tempHeight = GetHeight(heightMap, uvs[index]);
                }
                vertives[index] = new Vector3(j * w, tempHeight, i * h);
                index++;
            }
        }
        return vertives;
    }

    /*生成UV信息*/
    private Vector2[] GetUV() {
        int sum = Mathf.FloorToInt((segment.x + 1) * (segment.y + 1));
        uvs = new Vector2[sum];
        float u = 1.0F / segment.x;
        float v = 1.0F / segment.y;
        uint index = 0;
        for (int i = 0; i < segment.y + 1; i++) {
            for (int j = 0; j < segment.x + 1; j++) {
                uvs[index] = new Vector2(j * u, i * v);
                index++;
            }
        }
        return uvs;
    }

    /*生成索引信息*/
    private int[] GetTriangles() {
        int sum = Mathf.FloorToInt(segment.x * segment.y * 6);
        triangles = new int[sum];
        uint index = 0;
        for (int i = 0; i < segment.y; i++) {
            for (int j = 0; j < segment.x; j++) {
                int role = Mathf.FloorToInt(segment.x) + 1;
                int self = j + (i * role);
                int next = j + ((i + 1) * role);
                triangles[index] = self;
                triangles[index + 1] = next + 1;
                triangles[index + 2] = self + 1;
                triangles[index + 3] = self;
                triangles[index + 4] = next;
                triangles[index + 5] = next + 1;
                index += 6;
            }
        }
        return triangles;
    }

    private float GetHeight(Texture2D texture, Vector2 uv) {
        if (texture != null) {
            //提取灰度。如果强制读取某个通道，可以忽略
            Color c = GetColor(texture, uv);
            float gray = c.grayscale;//或者可以自己指定灰度提取算法，比如：gray = 0.3F * c.r + 0.59F * c.g + 0.11F * c.b;
            float h = unitH * gray;
            return h;
        }
        else {
            return 0;
        }
    }
    
    /*获取图片上某个点的颜色*/
    private Color GetColor(Texture2D texture, Vector2 uv) {

        //Color color = texture.GetPixel(Mathf.FloorToInt(texture.width * uv.x), Mathf.FloorToInt(texture.height * uv.y));
        Color color = texture.GetPixel(_startX + Mathf.FloorToInt(_blockW * uv.x), _startY + Mathf.FloorToInt(_blockH * uv.y));
        return color;

    }

    /*从外部设置地形的位置坐标*/
    public void SetPos(Vector3 pos) {
        if (terrain) {
            terrain.transform.position = pos;
        }
    }
}