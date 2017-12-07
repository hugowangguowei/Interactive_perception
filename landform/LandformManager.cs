using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandformManager : MonoBehaviour {
    public static LandformManager instance;
    public static ArrayList landformList = new ArrayList();

    void Awake() {
        instance = this;
    }

	void Start () {
        //createLandform(0, 0, 500, 500, 250, 250, "taiwan");
	}
	
	void Update () {
		
	}

    public void createLandform(string mapName) {

        Landform land = new Landform(mapName);
        landformList.Add(land);
    }

    public void createLandform(int x, int y, int width,int height,int segmentX,int segmentY,string mapName) {
        Landform land = new Landform(segmentX, segmentX, mapName);
        landformList.Add(land);
    }

    public void removeLandform() {
        int len = landformList.Count;
        Debug.Log(len);
        for(int i = len - 1; i >= 0; i--) {
            Debug.Log("进入循环");
            Landform land_i = (Landform)landformList[i];
            land_i.destroy();
            landformList.RemoveAt(i);
        }
    }

    public void changeLandform(string mapName) {
        removeLandform();
        createLandform(mapName);
    }

    public void unfocusAllLandform() {
        foreach(Landform land_i in landformList) {
            land_i.unfocus();
        }
    }


}
