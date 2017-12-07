using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFadeBack : MonoBehaviour {
    public static PageFadeBack instance;
    public static GameObject PageFadeBackGB;
    public bool isFaddingBack;
    public Transform PageFadeBackTrans;
    public Vector3 orgPosition;
    public float DrawBackSpeed;
    public int DrawBackDistance;
    public int DrawBackCount;
    public TextMesh pageTextMesh;
    void Awake()
    {
        instance = this;
        PageFadeBackGB = gameObject;
        isFaddingBack = false;
        PageFadeBackTrans = PageFadeBackGB.GetComponent<Transform>();
        orgPosition = PageFadeBackTrans.position;
        DrawBackSpeed = (float)0.1;
        DrawBackCount = 0;
        DrawBackDistance = 1000;
        pageTextMesh=PageFadeBackGB.GetComponent<TextMesh>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isFaddingBack)
        {
            Vector3 newPos = new Vector3(PageFadeBackTrans.position.x- DrawBackSpeed, PageFadeBackTrans.position.y + DrawBackSpeed, PageFadeBackTrans.position.z + DrawBackSpeed);
            this.transform.position = newPos;
            DrawBackCount++;
        }
        if(DrawBackCount==DrawBackDistance)
        {
            pageTextMesh.text = "";
            this.transform.position = orgPosition;
        }
		
	}
    public void fadeBackPage(string pageText)
    {
        print("fadeBackPage is called!!!!!!!!!!!!!!!!!!!!!!!!!");
        pageTextMesh.text = pageText;
        isFaddingBack = true;
    }
}
