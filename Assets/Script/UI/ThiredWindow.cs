using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zhoule;

public class ThiredWindow : WindowBase {
    [SerializeField]
    Button testbutton;



    protected override void RefreshMe()
    {
        base.RefreshMe();
        testbutton.onClick.RemoveAllListeners();

        testbutton.onClick.AddListener(() =>
        {
            MessageArgs args = SafeObjectPool<MessageArgs>.Instance.Allocate();
            args.ma = ModuleArea.UIManager;
            args.opcode = (int)UIEvents.MainWindow;
            SendEvent(args);
            Hide();
        });

    }


    protected override void ResetMe()
    {
        base.ResetMe();
        Debug.Log("ResetMe--->>>> main");
    }
}
