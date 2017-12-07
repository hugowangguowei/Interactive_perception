using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class changePosition : MonoBehaviour {

    public static changePosition instance;
    private Vector3 curPosition;
    public float lat = 10;//纬度
    public float lon = 20;//经度
    private float thetaJ;   //立体偏角
    private float theta;    //水平偏角   
    private float alpha;    //仰角
    private float r = 4.0f;
    private float speed;    //角度[0,180]
    private int globalCount;
    private float detaTheta;
    public bool flag = true;

    public void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (flag)
        {
            //处理输入的经纬度，转换成坐标
            Vector3 t = new Vector3(1.0f, 0.0f, 0.0f);
            //lat纬度，增加到水平的向量上
            if (lat > 0)
            {
                //北纬
                float y = Mathf.Tan(change2Pi(lat));
                //print("仰角的弧度数： " + y);//这里tan是按照弧度数来修改的，要将纬度转换成弧度数
                t.y += y;
                //lon是经度，上面修改后的向量上进行修改(1.0,y,0),即是修改后的向量
                //由于使用水平面的偏角，所以直接在t上增加就好
                float z = Mathf.Tan(change2Pi(lon));
                //print("水平偏角弧度数：" + z);
                t.z += z;
                float rt = Mathf.Sqrt(t.x * t.x + t.y * t.y + t.z * t.z);
                t *= 4 / rt;
                //print("转换后的世界坐标为" + t);
            }
            else
            {
                //南纬
            }

            flag = false;
        }//这里是处理输入的经纬度转换成世界坐标的地方，目前先不管

        detaTheta = (globalCount * this.speed)%360.0f;//旋转偏移的水平偏角[0-360]
        //地球朝着顺时针转，那么世界坐标要朝着逆时针旋转修改
	}

    public void setPosition(Vector3 position)
    {
        curPosition = position;
        print("当前点击位置坐标: " + curPosition);
        //修改旋转量坐标的时候，只要修改x,z轴对应的坐标，y轴不受影响
        Vector3 sPing = new Vector3( curPosition.x, 0.0f, curPosition.z);
        Vector3 cZhi = new Vector3(curPosition.x, curPosition.y, 0.0f);
        Vector3 czhic = new Vector3(curPosition.x, 0.0f, 0.0f);
        alpha = Vector3.Angle(sPing, curPosition);//返回的不是弧度数
        thetaJ = Vector3.Angle(cZhi, curPosition);//[0,180]
        theta = Vector3.Angle(sPing, cZhi);
        float final_theta;//整合了旋转和当前角度的水平偏角
        //alpha，thetaJ，theta < 90
        print("原始——偏角： " + theta + ", 仰角： " + alpha);
        print("原始——偏角J： " + thetaJ+ ", 仰角： " + alpha);
        //加上逆时针旋转detaTheta角度
        if(curPosition.x>0 && curPosition.z > 0)
        {
            //第一象限
            final_theta = (theta + detaTheta)%360;
        }
        else if(curPosition.x <0 && curPosition.z > 0)
        {
            //第二象限
            final_theta = (180 - theta + detaTheta) % 360;
        }else if(curPosition.x < 0 && curPosition.z < 0)
        {
            //第三象限
            final_theta = (180 + theta + detaTheta) % 360;
        }
        else
        {
            //第四象限
            final_theta = (-theta + detaTheta) % 360;
        }
        //根据坐标位置来判断象限和方向，经纬度都不需要转换，直接可用
        if (curPosition.y > 0)
        {
            //北纬
            print("整合——北纬："+alpha+", 经度："+final_theta);
        }
        else if(curPosition.y == 0)
        {
            //赤道
            print("整合——赤道： 0， 经度： " + final_theta);
        }
        else
        {
            //南纬
            print("整合——南纬： " + alpha+"， 经度： "+final_theta);
        }
        //世界坐标转换经纬度完成
        flag = true;
    }
    private float change2Pi(float x)
    {
        return x * Mathf.PI / 180;
    }
    private float pi2Float(float pi)
    {
        return pi * 180 / Mathf.PI;
    }
    public void setCount(int count, float speed)
    {
        this.speed = speed;//这个speed本来就是角度数的速度[0,360]
        globalCount = count;
    }
}
