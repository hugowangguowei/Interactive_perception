using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intelligenceManager : MonoBehaviour {
    public intelligenceManager instance;
	// Use this for initialization

    public void Awake() {

    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        generateIntelligence();
	}

    private void checkReceiver() {

    }

    private void generateIntelligence() {
        Intelligence intel = new Intelligence();
        string[] textList = new string[1];
        string text1 =
            "据台媒11月7日报道，“台湾空军司令部”今天稍早表示，新竹基地一架幻影2000战斗机（机号2040），由飞行员何子雨上尉驾驶，" +
            "18时43分于北部海域执行训练时雷达讯号消失，台空军已于19时05分派遣S-70C型直升机进行搜救，目前飞行员已经获救并送往医院。" +
            "据了解，这架战机消失位置大约在基隆彭佳屿外海40海里处。\n";
        string text2 =
            "按气象局卫星云图显示，“幻影”失踪的彭佳屿北方空域，事发时云多且有雨，天气不佳。张哲平称，失联的何子雨若弹射跳伞，身" +
            "上所穿的新式救生衣应该会自动发出求生用的无线电信号标示落海位置，并由人员操作语音通话装备导引救援兵力赶到现场，但“截" +
            "至今天（8日）中午为止，战管单位没有获得无线电信号”。据悉，台“幻影”战机2001年发生失事事件后，空军采购了防水防寒且" +
            "加装自动充气并配备无线电、信号弹等求生器材的救生衣。这套救生衣装备价格达40万元新台币，以增加飞行员落水后的生还概率。" +
            "到了8日晚间终于传出进展：空军直升机在附近海域发现疑似机上发出的求救信号，并且在附近海域目视海面有漂流物。\n";
        string text3 = 
            "有知情人士称，当时何子雨与其他飞行员执行的是“二对二的空中战斗训练”，由于“幻影”战机具有优异的视距外攻击能力，因此长" +
            "机与僚机的距离分得很开，已超出目视范围，而在最后一次被雷达扫描到前，何子雨战机高度呈现快速下降状态。因此，他可能发生所" +
            "谓的“空间迷向”，即在缺乏视觉判断标的的情况下，身体的平衡感与实际空间位置出现落差。台空军8日宣布，“幻影”战机即日起暂" +
            "停例行演训。";
        textList[0] = text1;
        textList[1] = text2;
        textList[2] = text3;
        string[] picList = new string[2];
        picList[0] = "Images/plane_1";
        picList[1] = "Images/plane_2";
        intel.textList = textList;
        intel.picList = picList;
    }


}
