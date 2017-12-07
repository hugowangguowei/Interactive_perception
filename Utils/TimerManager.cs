using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void TimerEnd();


public class TimerManager : MonoBehaviour {
    public static List<ATimer> timerList = new List<ATimer>();
    private static float idCount = 0;
    void Update() {
        for (int i = 0; i < timerList.Count; i++) {
            timerList[i].update();
        }
    }

    public static float generateTimerId() {
        idCount++;
        return idCount;
    }

    public static bool removeTimer(ATimer timer) {
        int Count = timerList.Count;
        for (int i = Count - 1; i >= 0; i--) {
            if (timerList[i].id == timer.id) {
                timerList.Remove(timerList[i]);
            }
            return true;
        }
        return false;
    }

};

public class ATimer {
    public float id;
    float duringTime;
    float oldTime = -1;
    bool flag;
    int loopCount;
    int loopNum;
    TimerEnd OnEnd;

    public ATimer(float time, TimerEnd endFunc, bool isLoop , int _loopNum) {
        id = TimerManager.generateTimerId();
        duringTime = time;
        OnEnd = endFunc;
        oldTime = Time.time;
        flag = isLoop;
        loopCount = 0;
        loopNum = _loopNum;
        TimerManager.timerList.Add(this);
    }

    public float getOldTime() { return oldTime; }

    public void stopTimer() { oldTime = -1; }

    public static void stopAllTimer() {
        foreach (var time in TimerManager.timerList)
            time.stopTimer();
    }

    public void update() {
        if (oldTime != -1 && Time.time > oldTime + duringTime) {
            OnEnd();
            if (flag) {
                oldTime = Time.time;
                loopCount++;
                if (loopNum > 0 && loopCount >= loopNum) {
                    oldTime = -1;
                    destroy();
                }
            }
            else {
                oldTime = -1;
                destroy();
            }
        }
    }

    public void destroy() {
        TimerManager.removeTimer(this);
    }
}