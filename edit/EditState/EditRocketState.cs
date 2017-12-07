using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditRocketState : EditState {
    public GameObject graticules;
    public EditRocketState() {
        stateName = "EditRocketState";
        
    }

    public override void choosenObj(RaycastHit hitInfo) {
        GameObject selectedObj = hitInfo.collider.gameObject;
        if (selectedObj == ObjEarth.earth) {
           // IdleManager.instance.showCube("place");
        }
        if (selectedObj == RemoveCube.RemoveCubeBtn) {
           // IdleManager.instance.deleteCube("place");
        }
    }
    public override void showComponents()
    {
        ObjEarth.instance.changeTexture(0);
     //   ObjEarth.instance.addGraticule();
    }
    public override void hideComponents()
    {
        ObjEarth.instance.changeTexture(3);
    //    ObjEarth.instance.deleteGraticule();
    }
}
