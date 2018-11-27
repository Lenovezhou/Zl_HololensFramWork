using System;
using UnityEngine.UI;
using UnityEngine;
using Zhoule;

public class SecendWindow :WindowBase
{

    [SerializeField]
    private Button testbutton;
    [SerializeField]
    private Button testdigital;

    protected override void RefreshMe()
    {
        base.RefreshMe();

        testbutton.onClick.RemoveAllListeners();
        testdigital.onClick.RemoveAllListeners();
        testbutton.onClick.AddListener(
            () =>
            {
                MessageArgs args = SafeObjectPool<MessageArgs>.Instance.Allocate();
                args.ma = ModuleArea.UIManager;
                args.opcode = (int)UIEvents.MainWindow;
                SendEvent(args);
                Hide();
            });
        testdigital.onClick.AddListener(
            () => 
            {
                MessageArgs args = SafeObjectPool<MessageArgs>.Instance.Allocate();
                args.ma = ModuleArea.UIManager;
                args.opcode = (int)DigitalAssertEvent.Addmodle;
                SendEvent(args);
                Hide();
            });
    }

    protected override void ResetMe()
    {
        base.ResetMe();
        Debug.Log("ResetMe--->>>> secend");
    }
}