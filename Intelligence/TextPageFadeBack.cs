//从TextPageRender接收当前完全显示的页面
//将该页面后退至消失在视野中
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextPageFadeBack : MonoBehaviour {
    public static TextPageFadeBack instance;
    public static GameObject TextPageFadeBackGB;
    public bool isFaddingBack;
    public Transform TextPageFadeBackTrans;
    void Awake()
    {
     //   instance = this;
     //   TextPageFadeBackGB = gameObject;
     //   isFaddingBack = false;
     //   TextPageFadeBackTrans = TextPageFadeBackGB.GetComponent<Transform>();
     //   if (TextPageFadeBackTrans == null)
     //   {
     //       print("TextPageFadeBackTrans==null#######################");
     //   }
     //   else
     //       GetComponent<Transform>().position = new Vector3(1, 1, 1);
    }
    // Use this for initialization
    void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		if(isFaddingBack)
        {
        }
	}

   // public void fadeBackPage(string pageText)
   // {
   //     print("fadeBackPage is called!!!!!!!!!!!!!!!!!!!!!!!!!");
   //     TextPageFadeBackGB.GetComponent<TextMesh>().text = pageText;
   //     isFaddingBack = true;
   // }
}
