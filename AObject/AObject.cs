using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightingSystem;

public class AObject {
    public string AObjName { get; set; }
    public Transform AObjTransform { get; set; }
    public bool isSelected;

    public AObject(string name, Transform trans) {
        AObjName = name;
        AObjTransform = trans;
        isSelected = false;
    }

    public GameObject getGameObject() {
        return AObjTransform.gameObject;
    }

    public bool changeSelect(bool state) {
        isSelected = state;
        setSelect();
        return isSelected;
    }

    private void setSelect() {
        GameObject gameObj = getGameObject();
        Highlighter hL = gameObj.GetComponent<Highlighter>();
        if (isSelected) {
            if (!hL) {
                Highlighter h = gameObj.AddComponent<Highlighter>();
                h.ConstantOn(Color.yellow);
            }
        }
        else {
            if (hL) {
                hL.Die();
            }
        }
    }
}
