using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditIdleState : EditState {

    public EditIdleState() {
        stateName = "EditIdleState";
        //进入空闲状态时显示地球上的情报信息点IntelligenceMark
    }

    public override void choosenObj(RaycastHit hitInfo) {
        GameObject selectedObj = hitInfo.collider.gameObject;

        if (selectedObj == AObjectManager.IntelligenceMarkTaiwan.getGameObject())
        {
            AObjectManager.instance.showIntelligenceDetail("");
            LandformManager.instance.changeLandform("taiwan1");
            VedioScript.instance.playvedio();
        }
            
        if (selectedObj == AObjectManager.IntelligenceMarkJinan.getGameObject())
        {
            AObjectManager.instance.hideIntelligenceDetail("tw");
            LandformManager.instance.changeLandform("jinan");
            VedioScript.instance.stopvedio();
        }
            
    }
    public override void showComponents()
    {
        Debug.Log("idle State show is called");
        AObjectManager.instance.addIntelligenceMarks("taiwan and jinan");
        
    }
    public override void hideComponents()
    {
        AObjectManager.instance.hideIntelligenceMarks("tw");
        AObjectManager.instance.hideIntelligenceDetail("tw");
        Debug.Log("idle State hide is called");
        LandformManager.instance.unfocusAllLandform();
        Debug.Log("!!!!!!!!!vedio");
        VedioScript.instance.stopvedio();        
    }
}