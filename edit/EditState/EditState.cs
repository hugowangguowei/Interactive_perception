using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditState{
    public string stateName;
    
    public EditState() {

    }

    public virtual void choosenObj(RaycastHit hitInfo) {

        //detail
    }

    public virtual void showComponents() {
        //detail
    }

    public virtual void hideComponents() {
        //detail
    }
}
