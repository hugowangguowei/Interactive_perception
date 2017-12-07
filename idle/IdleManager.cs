using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleManager : MonoBehaviour {
    public static IdleManager instance;
    GameObject detailCube;

    private void Awake() {
        instance = this;   
    }

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool showCube(string name/*, Vector3 pos, RaycastHit hit, Transform trans*/)
    {
        detailCube = Instantiate(Resources.Load<GameObject>("Prefabs/landDetail"));
        detailCube.transform.position = new Vector3(1,-0.09f,3);
        return true;
    }
    public bool deleteCube(string name/*, Vector3 pos, RaycastHit hit, Transform trans*/)
    {
        if(detailCube != null) {
            Destroy(detailCube);
        }
        //landDetail.DestroyObject(detailCube);
        return true;
    }
}
