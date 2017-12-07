/**
 * this file is part of ARGIS
 * 名称：HoloManager.cs
 * 简述：卫星管理类
 * 作者：LUT
 * 编辑: LUT  2017.10.20
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteManager : MonoBehaviour {
    public static SatelliteManager instance;

    public bool needSatellite = true;
    public bool satelliteInit = false;
    public GameObject satellite;

    private bool isSatelliteShow = true;

    public void Awake()
    {
        instance = this;

        if (needSatellite)
        {
            addSatellite();
        }
    }

    public void addSatellite()
    {
        if (!satelliteInit)
        {
            GameObject satellitePrefab = (GameObject)Resources.Load("Prefabs/satellite");
            GameObject earth = ObjEarth.earth;
            //初始化卫星
            satellite = Instantiate(satellitePrefab);
            satellite.transform.parent = earth.transform;
            needSatellite = true;
            satelliteInit = true;

            isSatelliteShow = true;
        }
    }

    public void removeSatellite()
    {
        Destroy(satellite);
        needSatellite = false;
        satelliteInit = false;
    }

    public void changeShowState() {
        if (isSatelliteShow) {
            hideSatellite();
        }
        else {
            showSatellite();
        }
    }

    public void showSatellite() {
        if(satellite == null) {
            addSatellite();
        }
        satellite.SetActive(true);
        isSatelliteShow = true;
    }

    public void hideSatellite() {
        if(satellite != null) {
            satellite.SetActive(false);
        }
        isSatelliteShow = false;
    }

    public void setSatellite(float height, Vector3 faxiangliang)
    {
        if (needSatellite)
        {
            print("setSatellite faxiangliang :" + faxiangliang);
            satelliteRotate ssr = (satelliteRotate)satellite.GetComponent("satelliteRotate");
            ssr.setInitData(height, faxiangliang);
        }
    }
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
