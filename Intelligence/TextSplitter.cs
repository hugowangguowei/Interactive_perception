//将一整篇文字（已经按自然段存入string[]）
//分割为字符数相等的页面，并在每段切割完成后 
//将每段文字以页string[]的形式发送给PagesTimer类进行存储
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSplitter : MonoBehaviour {
    public string EntireInfo;
    public string[] InfoParagraphs;
    public int paraMaxLength;
    public string[] pagesInOnePara;
    public int paragraphNum;

    // Use this for initialization
    private void Awake()
    {
        paraMaxLength = 300;
        InitEntireInfo();//测试初始化
        InitParagraphInfo();//测试初始化
  //      testText();//测试显示
    }
    void Start () {      		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void InitEntireInfo()
    {
        //length:635
        EntireInfo = "据台媒11月7日报道，“台湾空军司令部”今天稍早表示，新竹基地一架幻影2000战斗机（机号2040），由飞行员何子雨上尉驾驶，18时43分于北部海域执行训练时雷达讯号消失，台空军已于19时05分派遣S-70C型直升机进行搜救，目前飞行员已经获救并送往医院。 据了解，这架战机消失位置大约在基隆彭佳屿外海40海里处。\r\n" +
            "按气象局卫星云图显示，“幻影”失踪的彭佳屿北方空域，事发时云多且有雨，天气不佳。张哲平称，失联的何子雨若弹射跳伞，身上所穿的新式救生衣应该会自动发出求生用的无线电信号标示落海位置，并由人员操作语音通话装备导引救援兵力赶到现场，但“截至今天（8日）中午为止，战管单位没有获得无线电信号”。据悉，台“幻影”战机2001年发生失事事件后，空军采购了防水防寒且加装自动充气并配备无线电、信号弹等求生器材的救生衣。这套救生衣装备价格达40万元新台币，以增加飞行员落水后的生还概率。到了8日晚间终于传出进展：空军直升机在附近海域发现疑似机上发出的求救信号，并且在附近海域目视海面有漂流物。\r\n" +
            "有知情人士称，当时何子雨与其他飞行员执行的是“二对二的空中战斗训练”，由于“幻影”战机具有优异的视距外攻击能力，因此长机与僚机的距离分得很开，已超出目视范围，而在最后一次被雷达扫描到前，何子雨战机高度呈现快速下降状态。因此，他可能发生所谓的“空间迷向”，即在缺乏视觉判断标的的情况下，身体的平衡感与实际空间位置出现落差。台空军8日宣布，“幻影”战机即日起暂停例行演训。\r\n";
    }
    public void InitParagraphInfo()
    {
        if(InfoParagraphs.Length == 0)
        {
            //length:159 290 168
            InfoParagraphs = new string[3];
            InfoParagraphs[0] = "据台媒11月7日报道，“台湾空军司令部”今天稍早表示，新竹基地一架幻影2000战斗机（机号2040），由飞行员何子雨上尉驾驶，18时43分于北部海域执行训练时雷达讯号消失，台空军已于19时05分派遣S-70C型直升机进行搜救，目前飞行员已经获救并送往医院。 据了解，这架战机消失位置大约在基隆彭佳屿外海40海里处。\r\n";
            InfoParagraphs[1] = "按气象局卫星云图显示，“幻影”失踪的彭佳屿北方空域，事发时云多且有雨，天气不佳。张哲平称，失联的何子雨若弹射跳伞，身上所穿的新式救生衣应该会自动发出求生用的无线电信号标示落海位置，并由人员操作语音通话装备导引救援兵力赶到现场，但“截至今天（8日）中午为止，战管单位没有获得无线电信号”。据悉，台“幻影”战机2001年发生失事事件后，空军采购了防水防寒且加装自动充气并配备无线电、信号弹等求生器材的救生衣。这套救生衣装备价格达40万元新台币，以增加飞行员落水后的生还概率。到了8日晚间终于传出进展：空军直升机在附近海域发现疑似机上发出的求救信号，并且在附近海域目视海面有漂流物。\r\n";
            InfoParagraphs[2] = "有知情人士称，当时何子雨与其他飞行员执行的是“二对二的空中战斗训练”，由于“幻影”战机具有优异的视距外攻击能力，因此长机与僚机的距离分得很开，已超出目视范围，而在最后一次被雷达扫描到前，何子雨战机高度呈现快速下降状态。因此，他可能发生所谓的“空间迷向”，即在缺乏视觉判断标的的情况下，身体的平衡感与实际空间位置出现落差。台空军8日宣布，“幻影”战机即日起暂停例行演训。\r\n";
        }
    }
    //on messgage 
    //功能：从发射器接收完整情报信息 将每段情报分割为单页长度的字符串
    //输入：string[i]为情报第i-1段信息
    //输出：将每页字符串发送给PagesInfoMgr/PagesInfoTimer 进行储存
    public void SplitEntireText(string[] EntireText)
    {
        EntireText = InfoParagraphs;//测试使用 后期删除
        paragraphNum = EntireText.Length;
        for(int i=0;i<paragraphNum;i++)
        {
            string[] sendPages = SplitOneParaToPages(EntireText[i]);
            //发送给PagesTimer 进行存储

        }

    }
    public string[] SplitOneParaToPages(string onePara)
    {
        if(onePara.Length> paraMaxLength)
        {
            string oneParaTemp=onePara;
            int pageNum = onePara.Length / paraMaxLength + 1;
            pagesInOnePara = new string[pageNum];
            for(int i=0;i< pageNum; i++)
            {
                //切割段落分页显示 后期测试            
                int j = i * 300;
                if(i==pageNum-1)
                {
                    pagesInOnePara[i] = onePara.Substring(j, onePara.Length % paraMaxLength);
                }
                pagesInOnePara[i] = oneParaTemp.Substring(j, paraMaxLength);
            }          
        }
        else
        {
            pagesInOnePara = new string[1];
            pagesInOnePara[0] = onePara;
        }
        return pagesInOnePara;
        
    }

    public void testText()
    {
        for(int i=0;i< InfoParagraphs.Length;i++)
            SplitOneParaToPages(InfoParagraphs[i]);
        int pagesInOneParaNum =pagesInOnePara.Length;

    }
}
