using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intelligence {
    public bool isChecked { get; set; }
    public int id { get; set; }
    public string[] textList;
    public string[] picList;
    public string[] videoList;

    public Intelligence() {
        textList = new string[0];
        picList = new string[0];
        videoList = new string[0];
    }
}
