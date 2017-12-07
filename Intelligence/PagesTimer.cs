//用于存储待展现的页面，发送当前队列内页面给TextPageRender
//计时器固定时间间隔发送一页信息
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using System.Timers;

public class PagesTimer : MonoBehaviour {
    public ArrayList pagesArrayList=new ArrayList();
//    public Timer timer =new Timer(10000);//10s触发
    bool timerEnabled;
    void Awake()
    {
        timerEnabled=false;
 //       timer.Elapsed += new System.Timers.ElapsedEventHandler(sendOnePage);//计时器到达时间时执行sendOnePage
    }
    // Use this for initialization
    void Start () {
	}	
	// Update is called once per frame
	void Update () {
        if (pagesArrayList.Count!=0 && timerEnabled==false)
        {
    //        timer.Start();
        }  
        if(pagesArrayList.Count==0 && timerEnabled == true)
        {
      //      timer.Stop();
        }
	}
    //
 //  public void sendOnePage(object sender, System.Timers.ElapsedEventArgs e)
 //  {
 //      ArrayList firstPageAL=null;
 //      string firstPage = "";
 //      if (pagesArrayList.Count!=0)
 //      {
 //          firstPageAL = pagesArrayList.GetRange(0, 1);
 //          firstPage = (string)firstPageAL[0];
 //      }            
 //      if(firstPage != "")
 //      {
 //          BroadcastMessage("showOnePage",firstPage);//sendPageToTextRender
 //      }
 //          
 //  }
 //   public void AddPagesToList(string[] pages)
 //  {
 //      for (int i = 0; i < pages.Length; i++)
 //          pagesArrayList.Add(pages[i]);
 //  }
 //
 //  public void RemovePageInList(string page)
 //  {
 //      pagesArrayList.Remove(page);
 //  }

}
