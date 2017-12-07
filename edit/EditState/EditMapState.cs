using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMapState : EditState {

    public EditMapState() {
        stateName = "EditMapState";
    }

    public override void choosenObj(RaycastHit hitInfo) {
        GameObject selectedObj = hitInfo.collider.gameObject;
        if (selectedObj == ObjEarth.earth) {
            ObjEarth.instance.changeRotate();
        }
        if (selectedObj == RemoveCube.RemoveCubeBtn) {
            ObjEarth.instance.changeTexture();
        }
        for (int i = 0; i < 5; i++) {
            if (selectedObj == ObjEarth.SphereMapsCollection[i]) {
                EditManager.instance.SendMessageUpwards("onDebugInfo", "tap SphereMap" + i);
                ObjEarth.instance.changeTexture(i);
                return;
            }
        }
    }

    public override void showComponents() {
        ObjEarth.instance.showMapsCollection();
        Debug.Log("EditMapState show is called");
    }

    public override void hideComponents() {
        ObjEarth.instance.deleteMapsCollection();
        Debug.Log("EditMapState hide is called");
    }

}