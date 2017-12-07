using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour {
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    private int moshi_Count = 0;
    private int man_yoo_Count = 0;
    private int di_tu_count = 0;
    // Use this for initialization
    void Start() {

        keywords.Add("change state", () => {
            this.BroadcastMessage("speechInput_changeState");
        });

        keywords.Add("change map", () => {
            this.BroadcastMessage("speechInput_changeMap");
        });

        
        //测试文字列表==========================================================================================
        
        keywords.Add("drug type", () => {
            moshi_Count++;
            this.BroadcastMessage("speechInput_debugInfo", "drug type:状态" + moshi_Count);
        });


        keywords.Add("man yoo", () => {
            man_yoo_Count++;
            this.BroadcastMessage("speechInput_debugInfo", "man yoo:漫游" + man_yoo_Count);
        });
        
        keywords.Add("deep too", () => {
            di_tu_count++;
            this.BroadcastMessage("speechInput_debugInfo","deep too:地图" + di_tu_count);
        });
        

        //------------------------------------------------------------------------------------------------------

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction)) {
            keywordAction.Invoke();
        }
    }
}