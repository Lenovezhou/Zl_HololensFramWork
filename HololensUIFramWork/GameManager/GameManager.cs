
using UnityEngine;
using Zhoule;


public class GameManager:MonoBehaviour
{
    private void Start()
    {
        MessageArgs args = SafeObjectPool<MessageArgs>.Instance.Allocate();/*new MessageArgs();*/
        //args.ma = ModuleArea.GameManager;
        args.opcode = (int)UIEvents.MainWindow;
        EventDispatcher.GetInstance().Dispatcher(args);
    }

}