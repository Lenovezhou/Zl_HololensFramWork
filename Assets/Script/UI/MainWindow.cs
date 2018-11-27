using UnityEngine.UI;
using UnityEngine;
using Zhoule;

public class MainWindow : WindowBase {

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
            args.opcode = (int)UIEvents.SecendWindow;
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
