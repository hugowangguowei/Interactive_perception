using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class satelliteRotate : MonoBehaviour {
    /*火箭相关参数*/
    public GameObject gObj;
    private Vector3 pointS;
    private Vector3 faxiangliang;
    public Vector3 fangxiang;
    private bool isRotate = false;
    private bool isInited = false;
    private float height = 0.1f;
    private float r;

    void Start()
    {
        r = 1.2f;
        pointS = gameObject.GetComponent<Transform>().position;//start有getposition的
        gameObject.transform.localPosition = new Vector3(r, 0, 0);
        
    }
    
	// Update is called once per frame
	void Update () {
        if(isRotate)
            gameObject.transform.RotateAround(new Vector3(0,0,0), this.faxiangliang, 30*Time.deltaTime);
	}

    public void setInitData(float height, Vector3 faxiangliang)
    {
        if (!isInited)
        {
            print("计算位置set: "+faxiangliang);
            this.height = height;
            this.faxiangliang = faxiangliang;
            print("计算位置set2: " + this.faxiangliang+" 2. "+this.faxiangliang.x);
            float z = 1.0f;
            float a = this.faxiangliang.y * this.faxiangliang.y / (this.faxiangliang.x * this.faxiangliang.x);
            float b = 2 * this.faxiangliang.y * this.faxiangliang.z / (this.faxiangliang.x * this.faxiangliang.x);
            float c = this.faxiangliang.z * this.faxiangliang.z / (this.faxiangliang.y * this.faxiangliang.y) - (r * r - 1 + 2 * r * height + height * height);
            float deta = b * b - 4 * a * c;

            float y = (-b + Mathf.Sqrt(deta)) / 2 * a;
            print("y = "+y);
            float x = (-this.faxiangliang.z - this.faxiangliang.y * y) / this.faxiangliang.x;
            print("x = " + x);
            this.fangxiang = new Vector3(x, y, z);
            print("------fangxiang :" + fangxiang);
            float rfangxiang = getVecLength(fangxiang);
            fangxiang *= r*1.3f / rfangxiang;
            isRotate = true;
            isInited = true;
            gameObject.transform.position = fangxiang;
            
        }

    }
    private float getVecLength(Vector3 v)
    {
        return Mathf.Sqrt(v.x*v.x+v.y+v.y+v.z*v.z);
    }
        
}
