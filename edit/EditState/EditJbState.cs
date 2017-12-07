using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditJbState : EditState {
    public bool isDrawing = false;
    public bool isSelecting = true;
    public string choosenJBName;

    public EditJbState() {
        stateName = "EditJbState";
        choosenJBName = "bh10";
    }

    public void setChoosenJBName(string jbName) {
        choosenJBName = jbName;
    }

    public void choosenObj(GameObject obj) {

    }

    public override void choosenObj(RaycastHit hitInfo) {
        GameObject selectedObj = hitInfo.collider.gameObject;
        if (selectedObj == ObjEarth.earth) {
            addAObject(hitInfo);
        }
        else {

            foreach(AObject jb_i in AObjectManager.instance.JbList) {
                GameObject jbObject = jb_i.getGameObject();
                if(selectedObj == jbObject && !jb_i.isSelected) {
                    AObjectManager.instance.setAObjSingleSelected(jb_i);
                    return;
                }
                
            }
        }
    }

    public void addAObject(RaycastHit hitInfo) {
        EditManager.instance.SendMessageUpwards("onDebugInfo", "进入addModel");
        Vector3 real_position = hitInfo.point;
        AObjectManager.instance.addAObject(choosenJBName, real_position, hitInfo);
    }

}