using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutinePlayer : MonoBehaviour {
    public static RoutinePlayer instance;
    public static bool isPlaying;

    private GameObject bottomBtns;
    private GameObject tips;
    private GameObject tips_left;
    private GameObject tips_right;
    private GameObject tips_bottom;
    void Awake() {
        instance = this;
        isPlaying = false;
    }
	void Start () {
        tips = GameObject.Find("TIPS");
        if(tips == null) {
            return;
        }
        setEnv();
    }

    private void setEnv() {
        if(bottomBtns == null) {
            bottomBtns = GameObject.Find("bottomBtns");
        }
        bottomBtns.SetActive(false);
        if(tips == null) {
            tips = GameObject.Find("TIPS");
        }
        tips.SetActive(false);
        SatelliteManager.instance.hideSatellite();
        
        //加载响应板
        GameObject action = Instantiate(Resources.Load<GameObject>("Prefabs/world/action"));
        action.transform.parent = GameObject.Find("world").transform;
        action.transform.localPosition = new Vector3(0, 0, -0.8f);

        //加载logo
        GameObject logo = Instantiate(Resources.Load<GameObject>("Prefabs/world/logo2"));
        logo.transform.parent = ObjEarth.earth.transform;
        //logo.transform.localPosition = new Vector3(1.57f, 0, 0.88f);
        logo.transform.localPosition = new Vector3(0, 0, 0);
        logo.transform.localScale = new Vector3(0.375f, 0.375f, 0.375f);
        logo.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        logo.name = "logo";

    }

    private void resetEnv() {
        EditIdleState idleState = (EditIdleState)EditManager.instance.changeState(new EditIdleState());
        LandformManager.instance.removeLandform();
        isPlaying = false;
     //   setEnv();
    }

    public void play() {
        if (isPlaying) {
            return;
        }
        isPlaying = true;
        beginIntroduce();//隐藏碰撞体       
        float totalT = 0;
        //触发演示================================================================================
        float t0 = 0; totalT += t0;
        ATimer timer0 = new ATimer(totalT, playAudio01, false, -1);
        float t0_1 = 9f; totalT += t0_1;
        ATimer timer0_1 = new ATimer(totalT, destroyLogo, false, -1);
       
        ////介绍面板================================================================================
        
       float t1 = 10;          totalT += t1;
       ATimer timer1 = new ATimer(totalT, playAudio02, false ,-1);
       float t1_0 = 1.0f; totalT += t1_0;
       ATimer timer1_0 = new ATimer(totalT, blinkBlock, false, -1);
       float t1_1 = 4.6f ;    totalT += t1_1;
       ATimer timer1_1 = new ATimer(totalT, blinkBlock_left, false ,-1);
       float t1_2 = 2.8f;        totalT += t1_2;
       ATimer timer1_2 = new ATimer(totalT, blinkBlock_right, false, -1);
       float t1_3 = 2.5f;        totalT += t1_3;
       ATimer timer1_3 = new ATimer(totalT, blinkBlock_bottom, false, -1);
       float t2 = 3f;       totalT += t2;
       ATimer timer2 = new ATimer(totalT, hideBlock, false, -1);

        ////地图数据================================================================================
        float t5_0 = 0; totalT += t5_0;
        ATimer timer5_0 = new ATimer(totalT, playAudio03, false, -1);
        float t5_1 = 11;totalT += t5_1;
        ATimer timer5_1 = new ATimer(totalT, mapEdit_1, false, -1);
        float t5_2 = 15.1f; totalT += t5_2;
        ATimer timer5_2 = new ATimer(totalT, mapEdit_2, false, -1);
        float t5_3 = 2.2f; totalT += t5_3;
        ATimer timer5_3 = new ATimer(totalT, mapEdit_3, false, -1);
        float t5_4 = 2.1f; totalT += t5_4;
        ATimer timer5_4 = new ATimer(totalT, mapEdit_4, false, -1);
        float t5_5 = 1.9f; totalT += t5_5;
        ATimer timer5_5 = new ATimer(totalT, mapEdit_5, false, -1);
        float t5_6 = 2.1f; totalT += t5_6;
        ATimer timer5_6 = new ATimer(totalT, mapEdit_6, false, -1);
        
        //标号操作================================================================================
        float t4_0 = 0.5f; totalT += t4_0;
        ATimer timer4_0 = new ATimer(totalT, playAudio04, false, -1);
        float t4_01 = 10f; totalT += t4_01;
        ATimer timer4_01 = new ATimer(totalT, jbEdit_0, false, -1);
        float t4_1 = 9;          totalT += t4_1;
        ATimer timer4_1 = new ATimer(totalT, jbEdit_1, false, -1);
        float t4_2 = 12;          totalT += t4_2;
        ATimer timer4_2 = new ATimer(totalT, jbEdit_2, false, -1);
        float t4_3 = 1.2f;          totalT += t4_3;
        ATimer timer4_3 = new ATimer(totalT, jbEdit_3, false, -1);
        float t4_4 = 1.2f; totalT += t4_4;
        ATimer timer4_4 = new ATimer(totalT, jbEdit_4, false, -1);
        float t4_5 = 1.3f; totalT += t4_5;
        ATimer timer4_5 = new ATimer(totalT, jbEdit_5, false, -1);

        //火箭控制================================================================================
        float t6_0 = 3; totalT += t6_0;
        ATimer timer6_0 = new ATimer(totalT, playAudio05, false, -1);
        float t6_1 = 0f; totalT += t6_0;
        ATimer timer6_ = new ATimer(totalT, rocEdit_1, false, -1);//进入状态
        float t6_2 = 12.1f; totalT += t6_2;
        ATimer timer6_2 = new ATimer(totalT, rocEdit_2, false, -1);//初始化
        float t6_3 = 9; totalT += t6_3;
        ATimer timer6_3 = new ATimer(totalT, rocEdit_3, false, -1);//发射
        float t6_4 = 5; totalT += t6_4;
        ATimer timer6_4 = new ATimer(totalT, rocEdit_4, false, -1);//暂停
        float t6_5 = 1; totalT += t6_5;
        ATimer timer6_5 = new ATimer(totalT, rocEdit_5, false, -1);//继续

        //情报信息================================================================================
        float t3_0 = 9; totalT += t3_0;
        ATimer timer3_0 = new ATimer(totalT, playAudio06, false, -1);
        float t3_1 = 0f; totalT += t3_1;
        ATimer timer3_1 = new ATimer(totalT, idleEdit_1, false, -1);
        float t3_2 = 22.5f; totalT += t3_2;
        ATimer timer3_2 = new ATimer(totalT, idleEdit_2, false, -1);
        float t3_3 = 9.5f; totalT += t3_3;
        ATimer timer3_3 = new ATimer(totalT, idleEdit_3, false, -1);

        //重置环境================================================================================
        float t7_0 = 16; totalT += t7_0;
        ATimer timer7_0 = new ATimer(totalT, playAudio07, false, -1);
        float t7_1 = 0; totalT += t7_1;
        ATimer timer7_1 = new ATimer(totalT, resetEnv, false, -1);

    }
    //设置环境
    private void beginIntroduce() {
        GameObject action = GameObject.Find("action(Clone)");
        if (action != null) {
            Destroy(action);
        }
     //   GameObject logo = GameObject.Find("logo");
     //   if(logo != null) {
     //       Destroy(logo);
     //   }
        //音频播放开始
      //  MusicPlayer.instance.Play("01功能介绍");
    }
    private void destroyLogo()
    {
        GameObject logo = GameObject.Find("logo");
        if (logo != null)
        {
            Destroy(logo);
        }
        //音频播放开始
        //  MusicPlayer.instance.Play("01功能介绍");
    }
   
    //模块闪烁
    private void blinkBlock() {
        tips.SetActive(true);
        tips_left = GameObject.Find("block_left");
        tips_right = GameObject.Find("block_right");
        tips_bottom = GameObject.Find("block_bottom");
    }

    private void blinkBlock_left() {
        new ATimer(0.2f, blinkObj_left, true , 4);
    }

    private bool isBOL = true;
    private void blinkObj_left() {
        tips_left.SetActive(!isBOL);
        isBOL = !isBOL;
    }
    private void blinkBlock_right() {
        new ATimer(0.2f, blinkObj_right, true, 4);
    }

    private bool isBOR = true;
    private void blinkObj_right() {
        tips_right.SetActive(!isBOR);
        isBOR = !isBOR;
    }

    private void blinkBlock_bottom() {
        new ATimer(0.2f, blinkObj_bottom, true, 4);
    }

    private bool isBOB = true;
    private void blinkObj_bottom() {
        tips_bottom.SetActive(!isBOB);
        isBOB = !isBOB;
    }

    private void hideBlock() {
        tips.SetActive(false);
        bottomBtns.SetActive(true);
    }
    private void idleEdit_1() {
        EditIdleState idleState = (EditIdleState)EditManager.instance.changeState(new EditIdleState());
    }
    //济南情报
    private void idleEdit_2() {
        AObjectManager.instance.hideIntelligenceDetail("tw");
        LandformManager.instance.changeLandform("jinan");
        VedioScript.instance.stopvedio();
    }
    //台湾情报
    private void idleEdit_3() {
        AObjectManager.instance.showIntelligenceDetail("");
        LandformManager.instance.changeLandform("taiwan1");
        VedioScript.instance.playvedio();
    }
    private void jbEdit_0()
    {
        EditJbState jbState = (EditJbState)EditManager.instance.changeState(new EditJbState());
    }
    //创建标号
    private void jbEdit_1() {
        EditJbState jbState = (EditJbState)EditManager.instance.changeState(new EditJbState());
        jbState.setChoosenJBName("bh10");
        Vector3 p0 = Camera.main.transform.position;
        Vector3 pDelta = new Vector3(0.2f,0.2f, 0);
        Vector3 p1 = ObjEarth.instance.gameObject.transform.position;
        p0 = p0 + pDelta;
        Ray ray = new Ray(p0,p1);
        RaycastHit hit;
        Vector3 dianV = ObjEarth.instance.gameObject.transform.position;
        Physics.Raycast(ray, out hit);
        jbState.addAObject(hit);
        
        ArrayList list = AObjectManager.instance.selectedJbList;
        GameObject go;
        foreach (AObject obj in list) {
            go = obj.getGameObject();
            float rotateX = (float)0.8 * go.transform.localRotation.x;
            float rotateY = (float)0.8 * go.transform.localRotation.y;
            float rotateZ = (float)0.8 * go.transform.localRotation.z;
            go.transform.Rotate(rotateX, rotateY + 45, rotateZ);
        }
    }
    //放大标号
    private void jbEdit_2() {
        ArrayList list = AObjectManager.instance.selectedJbList;
        GameObject go;
        foreach (AObject obj in list) {
            go = obj.getGameObject();
            float scale = (float)2 * go.transform.localScale.x;
            float scale2 = (float)2 * go.transform.localScale.y;
            float scale3 = (float)2 * go.transform.localScale.z;
            go.transform.localScale = new Vector3(scale, scale2, scale3);
        }
    }
    //缩小标号
    private void jbEdit_3() {
        ArrayList list = AObjectManager.instance.selectedJbList;
        GameObject go;
        foreach (AObject obj in list) {
            go = obj.getGameObject();
            float scale = (float)0.5 * go.transform.localScale.x;
            float scale2 = (float)0.5 * go.transform.localScale.y;
            float scale3 = (float)0.5 * go.transform.localScale.z;
            go.transform.localScale = new Vector3(scale, scale2, scale3);
        }
    }
    //旋转标号
    private void jbEdit_4() {
        ArrayList list = AObjectManager.instance.selectedJbList;
        GameObject go;
        foreach (AObject obj in list) {
            go = obj.getGameObject();
            float rotateX = (float)0.8 * go.transform.localRotation.x;
            float rotateY = (float)0.8 * go.transform.localRotation.y;
            float rotateZ = (float)0.8 * go.transform.localRotation.z;
            go.transform.Rotate(rotateX, rotateY + 45, rotateZ);
        }
    }
    //删除标号
    private void jbEdit_5() {
        ArrayList list = AObjectManager.instance.selectedJbList;

        for (int i = list.Count - 1; i >= 0; i--) {
            AObjectManager.instance.removeAObject((AObject)list[i]);
        }
    }
    //切换地图状态
    private void mapEdit_1() {
        EditMapState mapState = (EditMapState)EditManager.instance.changeState(new EditMapState());
        
    }
    private void mapEdit_2() {
        ObjEarth.instance.changeTexture(1);
    }
    private void mapEdit_3() {
        ObjEarth.instance.changeTexture(4);
    }
    private void mapEdit_4() {
        ObjEarth.instance.changeTexture(0);
    }
    private void mapEdit_5() {
        ObjEarth.instance.changeTexture(2);
    }
    private void mapEdit_6() {
        ObjEarth.instance.changeTexture(3);
    }
    //切换火箭状态
    private void rocEdit_1() {
        EditRocketState mapState = (EditRocketState)EditManager.instance.changeState(new EditRocketState());
    }
    //初始化火箭
    private void rocEdit_2() {
        RocketsManager.instance.AddRocket(1);
    }
    //发射火箭
    private void rocEdit_3() {
        RocketsManager.instance.top().setState(Rocket.s2);
    }
    //暂停火箭
    private void rocEdit_4() {
        RocketsManager.instance.top().setState(Rocket.s1);
    }
    //继续火箭
    private void rocEdit_5() {
        RocketsManager.instance.top().setState(Rocket.s2);
    }
    private void playAudio01()
    {
        ObjEarth.instance.changeRotate(true);
        MusicPlayer.instance.Play("01功能介绍");
        return;
    }
    private void playAudio02()
    {
        MusicPlayer.instance.Play("02界面");
        return;
    }
    private void playAudio03()
    {
        MusicPlayer.instance.Play("03地图");
        return;
    }
    private void playAudio04()
    {
        MusicPlayer.instance.Play("04交互布局");
        return;
    }
    private void playAudio05()
    {
        MusicPlayer.instance.Play("05数据推演");
        return;
    }
    private void playAudio06()
    {
        MusicPlayer.instance.Play("06信息展示");
        return;
    }
    private void playAudio07()
    {
        MusicPlayer.instance.Play("07演示结束");
        return;
    }
    

    void Update () {
		
	}
}
