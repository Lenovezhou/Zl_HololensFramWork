using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zhoule;

public class TestClick:MonoBehaviour,  IPointerClickHandler
{
    protected Action<MessageArgs> SendEventCall;
    public void Init(Action<MessageArgs> Call)
    {
        SendEventCall = Call;
    }


    
    public void OnPointerClick(PointerEventData eventData)
    {
        MessageArgs args = new MessageArgs();
        args.ma = ModuleArea.DigitalAssertManager;
        args.opcode = (int)UIEvents.ThirdWindow;
        SendEventCall(args);
        //Hide();
    }
}
