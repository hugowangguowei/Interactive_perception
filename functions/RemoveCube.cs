using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCube : MonoBehaviour {
    /*状态切换按钮对象单例模式实例*/
    public static RemoveCube instance;
    /*脚本所绑定的模型*/
    public static GameObject RemoveCubeBtn;
    public bool isCubeExist;
    public GameObject detailCube;
    public ATimer timer;
    public float _scaleArgs = 2;
    public int num = 1;
    private void Awake()
    {
        isCubeExist = false;
        instance = this;
        RemoveCubeBtn = gameObject;

        //detailCube = Instantiate(Resources.Load<GameObject>("Prefabs/landDetail"));
    }

    // Use this for initialization
    void Start () {
        /*
        int count = 0;
        timer = new ATimer(
            0.5f,
            () => {
                float scaleNum = (float)System.Math.Pow(_scaleArgs, num);
                float scale = scaleNum * gameObject.transform.localScale.x;
                float scale2 = scaleNum * gameObject.transform.localScale.y;
                float scale3 = scaleNum * gameObject.transform.localScale.z;
                gameObject.transform.localScale = new Vector3(scale, scale2, scale3);
                count++;
                if (count > 3) {
                    num = num * -1;
                    count = count % 3;
                }
            },
            true);
            */
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnSelect()
    {
        /*
        if (isCubeExist) {
            landDetail.DestroyObject(detailCube);
            //  Instantiate(detailCube);
            isCubeExist=!isCubeExist;
        }
        else {
            GameObject.Instantiate(detailCube, new Vector3(1, 0, 1), Quaternion.identity);
            // detailCube = landDetail.landDetailCube;
            Instantiate(detailCube);
            isCubeExist = !isCubeExist;
        }
        */
        
    }
}
