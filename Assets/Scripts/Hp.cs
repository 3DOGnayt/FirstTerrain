using UnityEngine;


public class Hp: MonoBehaviour
{
    private string _message;
    public GUISkin test;
    private Rect buttonRect;    

#if UNITY_EDITOR
    void OnGUI()
    {
        //”гловые панели
        GUI.Box(new Rect(0, 0, 50, 25), "Hp");
        
    }
#endif
}
