using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zhoule;



//2018.11.24整理框架
//ui框架应具备的功能
//需和其他manager交互
//缓存所有窗口
//show，hide，hideall，EventHandler
//动态收发事件
//子物体完成动作回调注册到窗口内

/// <summary>
/// 窗体类型来决定其Z轴坐标，根据Z轴坐标SetSbling
/// </summary>
public enum WindowType
{
    
}



public enum UIEvents
{
    Begin = QMgrID.UI,
       MainWindow,
       SecendWindow,
       ThirdWindow
}



public class UIManager : AbsManager
{
    protected override void SetupModule()
    {
        modulearea = ModuleArea.UIManager;
        attentionevents.Add((int)UIEvents.MainWindow);
        attentionevents.Add((int)UIEvents.SecendWindow);
        attentionevents.Add((int)UIEvents.ThirdWindow);
    }


    /// <summary>
    /// 窗体字典缓存
    /// </summary>
    private Dictionary<string, WindowBase> dic_window = new Dictionary<string, WindowBase>();

    private WindowBase ShowWindow(string windowname)
    {
        WindowBase w = null;
        dic_window.TryGetValue(windowname, out w);
        if (!w)
        {
            GameObject obj = GameObject.Instantiate(Resources.Load("UI/" + windowname)as GameObject);
            WindowBase objw = obj.GetComponent<WindowBase>();
            objw.Init(SendEvent);
            w = objw;
            if (obj && objw)
            {
                dic_window.Add(windowname, w);
            }
            else
            {
                Debug.LogError("检查资源路径,且是否挂载window");
            }
        }
        w.Show();
        dic_window.TryGetValue(windowname, out w);
        return w;
    }

    private void HideWindow(string windowname)
    {
        WindowBase w = null;
        dic_window.TryGetValue(windowname, out w);
        if (w)
        {
            GameObject obj = w.gameObject;
            if (obj)
            {
                obj.SetActive(false);
            }
            else
            {
                Debug.LogError("窗体： " + windowname +"未实例");
            }
        }
    }

    public override void HandlerEvent(MessageArgs args)
    {
        int window = args.opcode;
        UIEvents uie = (UIEvents)window;
        WindowBase wb = ShowWindow(uie.ToString());  

        string newline = "\r\n";
        Debug.Log("--------->>>>>> " + args.ma.ToString() + newline + args.opcode.ToString());
       
    }

    protected override void RegisterEvent(MessageArgs args)
    {

    }



}
