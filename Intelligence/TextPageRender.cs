//接收PagesTimer发来的段落，将其逐字显示在场景中
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPageRender : MonoBehaviour {

    public static TextPageRender instance;
    public static GameObject textPageRenderGB;
    public string[] IntelligenceText;
    public bool isRenderingEachCharactor;
    public string PresentPageText;
    public int pageCharNum;
    public int pageCharCount;//当前显示的字符数
    public float pageCharCount_float;
    public int lineCharNum;//每行字符数
    public float renderCharSpeed;//字符显示速率
    public bool isWholePageShown;
    public int countParagraph;
    public int NextPageHoldTime;
    public int NextPageHoldTimeCnt;
    public bool isWaitClockTriggered;
    public TextMesh textMeshCmp;
    public int nextPageId;
    public bool isIdleState;
    void Awake()
    {
        instance = this;
        textPageRenderGB = gameObject;
        PresentPageText = "";
        pageCharCount = 0;
        pageCharCount_float = 0;
        lineCharNum = 16;
        isWholePageShown = false;
        renderCharSpeed = (float)0.5;
        countParagraph = 0;
        textMeshCmp = textPageRenderGB.GetComponent<TextMesh>();
        NextPageHoldTime = 100;
        NextPageHoldTimeCnt = 0;
        InitParagraphInfo();
        isWaitClockTriggered = false;
        nextPageId = 0;
    }
	// Use this for initialization
	void Start () {
		isRenderingEachCharactor = false;
        //showOnePage(IntelligenceText[nextPageId]);       
       
    }
	
	// Update is called once per frame
	void Update () {
        //print("isRenderingEachCharactor:" + isRenderingEachCharactor);
        //print("pageCharCount:" + pageCharCount);
        //print("pageCharNum:" + pageCharNum);
        if (!isIdleState)
        {
            textMeshCmp.text = "";
            return;
        }
            
        if (isRenderingEachCharactor ==true && pageCharCount< pageCharNum)
        {
            string TextRendering = "";
            TextRendering = PresentPageText.Substring(0, pageCharCount);
            textMeshCmp.text = TextRendering;
            if(nextPageId==2)
            {
                //print("TextRendering" + TextRendering);
            }
            pageCharCount_float += renderCharSpeed;
            pageCharCount =(int) pageCharCount_float;
          //  print("i am rendering the text!!!!!!!!!!!"+ TextRendering);
        }
        if (isRenderingEachCharactor == true && pageCharCount == pageCharNum)
        {
            isRenderingEachCharactor = false;
            isWholePageShown = true;
        }
        if(isWholePageShown==true)
        {
            //         BroadcastMessage("fadeBackPage", PresentPageText);//页面淡出场景
            //开始计时当前页显示时间
            isWaitClockTriggered = true;
            isWholePageShown = false;
            nextPageId++;
            print("isWholePageShown==true nextPageId=" + nextPageId);
        }
        if(isWaitClockTriggered == true)
        {
            NextPageHoldTimeCnt++;
            if(NextPageHoldTimeCnt==NextPageHoldTime)
            {
                isWaitClockTriggered = false;
                NextPageHoldTimeCnt = 0;
                if(nextPageId<3)
                {
                    PresentPageText = "";
                    showOnePage(IntelligenceText[nextPageId]);
                }                  
            }
        }
	}
    //接口，接收pagesTimer按时刻发来的一整页字符串 将其显示在场景中
    public void showOnePage(string ReceivedPageText)
    {
        pageCharCount = 0;
        pageCharCount_float = 0;
        //print("!!!!!!!!!!!!!!!show one page:" + ReceivedPageText);
        PresentPageText = ReceivedPageText;
        PresentPageText=InsertEndlineChar(ReceivedPageText);
        //print("!!!!!!!!!!!!!!!InsertEndlineChar:" + PresentPageText);
        pageCharNum = PresentPageText.Length;
        isRenderingEachCharactor = true;
        
    }
    public string InsertEndlineChar(string onePageText)
    {
        string TextWithEndlineChar="";
        string endLineChar = "\n";
        string strTemp = "";
        for (int i=0;(i*lineCharNum)<onePageText.Length;i++)
        {
            if ((i + 1) * lineCharNum > onePageText.Length)//每页最后一行不足一整行的字符数
            {
                strTemp = onePageText.Substring(i * lineCharNum, onePageText.Length - (i * lineCharNum));
                strTemp = strTemp + endLineChar;
                TextWithEndlineChar= TextWithEndlineChar+ strTemp;
                break;
            }                       
            strTemp=onePageText.Substring(i * lineCharNum, lineCharNum);
            strTemp = strTemp + endLineChar;
            TextWithEndlineChar = TextWithEndlineChar + strTemp;
            if (nextPageId == 1) {
                //print("textWithEndlineChar[i]:" + TextWithEndlineChar);
            }
        }
        return TextWithEndlineChar;
    }
    public void InitParagraphInfo()
    {
        if (IntelligenceText.Length == 0)
        {
            //length:159 290 168
            IntelligenceText = new string[3];
            IntelligenceText[0] = "据台媒11月7日报道，“台湾空军司令部”今天稍早表示 ，新竹基地一架幻影 2000 战斗机（机号2040），由飞行员何子雨上尉驾驶，18时43分于北部海域执行训练时雷达讯号消失 ，台空军已于 19时05分派遣S—70C型直升机进行搜救 ， 目前飞行员已经获救并送往医院 。 据了解，这架战机消失位置大约在基隆彭佳屿外海 40海里处。\r\n";
            IntelligenceText[1] = "按气象局卫星云图显示，“幻影”失踪的彭佳屿北方空域，事发时云多且有雨，天气不佳。张哲平称，失联的何子雨若弹射跳伞，身上所穿的新式救生衣应该会自动发出求生用的无线电信号标示落海位置，并由人员操作语音通话装备导引救援兵力赶到现场，但“截至今天（8日）中午为止，战管单位没有获得无线电信号”。据悉，台“幻影”战机2001年发生失事事件后，空军采购了防水防寒且加装自动充气并配备无线电、信号弹等求生器材的救生衣。这套救生衣装备价格达40万元新台币，以增加飞行员落水后的生还概率。到了8日晚间终于传出进展：空军直升机在附近海域发现疑似机上发出的求救信号，并且在附近海域目视海面有漂流物。\r\n";
            IntelligenceText[2] = "有知情人士称，当时何子雨与其他飞行员执行的是“二对二的空中战斗训练” ，由于“幻影”战机具有优异的视距外攻击能力，因此长机与僚机的距离分得很开，已超出目视范围，而在最后一次被雷达扫描到前，何子雨战机高度呈现快速下降状态。因此，他可能发生所谓的“空间迷向”，即在缺乏视觉判断标的的情况下，身体的平衡感与实际空间位置出现落差。台空军8日宣布，“幻影”战机即日起暂停例行演训。\r\n";
        }

    }
    public void showTaiwanIntelligence()
    {
        showOnePage(IntelligenceText[nextPageId]);
    }
    public void hideTaiwanIntelligence()
    {
        isIdleState = false;
    }
    public void setIdleStateTrue()
    {
        isIdleState = true;
    }
}
