﻿using UnityEngine;
using System.Collections;

public class TerrainManager : MonoBehaviour {
    //材质和高度图
    public Material diffuseMap;
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
    private GameObject terrain;

    // Use this for initialization
    void Start() {
        checkInput();
        SetTerrain();
    }

    private void checkInput() {
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
    }

    /// <summary>
    /// 生成默认地形
    /// </summary>
    public void SetTerrain() {
        SetTerrain(500, 500, 250, 250, -10, 10);
    }

    /// <summary>
    /// 通过参数生成地形
    /// </summary>
    /// <param name="width">地形宽度</param>
    /// <param name="height">地形长度</param>
    /// <param name="segmentX">宽度的段数</param>
    /// <param name="segmentY">长度的段数</param>
    /// <param name="min">最低高度</param>
    /// <param name="max">最高高度</param>
    public void SetTerrain(float width, float height, uint segmentX, uint segmentY, int min, int max) {
        Init(width, height, segmentX, segmentY, min, max);
        GetVertives();
        DrawMesh();
    }

    /// <summary>
    /// 初始化计算某些值
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="segmentX"></param>
    /// <param name="segmentY"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    private void Init(float width, float height, uint segmentX, uint segmentY, int min, int max) {
        size = new Vector2(width, height);
        maxHeight = max;
        minHeight = min;
        unitH = maxHeight - minHeight;
        segment = new Vector2(segmentX, segmentY);
        if (terrain != null) {
            Destroy(terrain);
        }
        terrain = new GameObject();
        terrain.name = "plane";
    }

    /// <summary>
    /// 绘制网格
    /// </summary>
    private void DrawMesh() {
        Mesh mesh = terrain.AddComponent<MeshFilter>().mesh;
        terrain.AddComponent<MeshRenderer>();
        if (diffuseMap == null) {
            Debug.LogWarning("No material,Create diffuse!!");
            diffuseMap = new Material(Shader.Find("Diffuse"));
        }
        if (heightMap == null) {
            Debug.LogWarning("No heightMap!!!");
        }
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

    /// <summary>
    /// 生成顶点信息
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// 生成UV信息
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// 生成索引信息
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// 获取图片上某个点的颜色
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="uv"></param>
    /// <returns></returns>
    private Color GetColor(Texture2D texture, Vector2 uv) {

        //Color color = texture.GetPixel(Mathf.FloorToInt(texture.width * uv.x), Mathf.FloorToInt(texture.height * uv.y));
        Color color = texture.GetPixel(_startX + Mathf.FloorToInt(_blockW * uv.x), _startY + Mathf.FloorToInt(_blockH * uv.y));
        return color;

    }

    /// <summary>
    /// 从外部设置地形的位置坐标
    /// </summary>
    /// <param name="pos"></param>
    public void SetPos(Vector3 pos) {
        if (terrain) {
            terrain.transform.position = pos;
        }
        else {
            SetTerrain();
            terrain.transform.position = pos;
        }
    }
}