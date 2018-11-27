using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Zhoule
{

    public class MsgSpan
    {
        public const int Count = 3000;
    }

    public partial class QMgrID
    {
        public const int Framework = 0;
        public const int UI = Framework + MsgSpan.Count; // 3000
        public const int Audio = UI + MsgSpan.Count; // 6000
        public const int DigitalAssert = Audio + MsgSpan.Count;
        public const int FrameworkMsgModuleCount = 3;
    }


    public class EventDispatcher:ISingleton
    {
        public static EventDispatcher GetInstance()
        {
            return SingletonProperty<EventDispatcher>.Instance;
        }
        private EventDispatcher() { }

        private Dictionary<ModuleArea, AbsManager> dic_manager;

        public void Dispatcher(MessageArgs args)
        {
            int permodulecount = MsgSpan.Count;
            int moduleindex = args.opcode/ permodulecount * permodulecount;
            UnityEngine.Debug.Log("modueindex " + moduleindex);
            ModuleArea _ma = (ModuleArea)moduleindex;
           
            AbsManager absm = null;
            switch (_ma)
            {
                case ModuleArea.DigitalAssertManager:
                    absm = new DigitalAssertManager();
                    break;
                case ModuleArea.UIManager:
                    absm = new UIManager();
                    break;
                case ModuleArea.SoundManager:
                    
                    break;
            }

            if (!dic_manager.ContainsKey(_ma))
            {
                dic_manager.Add(_ma, absm);
            }
            else {
                dic_manager.TryGetValue(_ma, out absm);
            }


            absm.HandlerEvent(args);
            SafeObjectPool<MessageArgs>.Instance.Recycle(args);
        }

        public void OnSingletonInit()
        {
            dic_manager = new Dictionary<ModuleArea, AbsManager>();
        }
    }
}
