using System;
using UnityEngine;
using Zhoule;


public enum DigitalAssertEvent
{
    Begin = QMgrID.DigitalAssert,
    Addmodle
}



public class DigitalAssertManager : AbsManager
{
    public override void HandlerEvent(MessageArgs args)
    {
        Debug.Log("shoudao");
        switch (args.opcode)
        {
            case (int)DigitalAssertEvent.Addmodle:
                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position =(new Vector3(0, 0, 2));
                obj.AddComponent<TestClick>().Init(SendEvent);
                break;
            default:
                break;
        }
    }

    protected override void SetupModule()
    {
        this.modulearea = ModuleArea.DigitalAssertManager;
    }



}
