using System;
using System.Collections.Generic;

namespace Zhoule
{
    public abstract class AbsManager
    {
        protected ModuleArea modulearea;
        protected List<int> attentionevents = new List<int>();

      
        protected abstract void SetupModule();

        protected virtual void RegisterEvent(MessageArgs args)
        {
            attentionevents.Add(args.opcode);
        }

        protected virtual void UnRegisterEvent(int opcode)
        {

        }


        protected virtual void SendEvent(MessageArgs args) 
        {
            EventDispatcher.GetInstance().Dispatcher(args);
        }

        public bool Attention_thisE(int opcode)
        {
            return attentionevents.Contains(opcode);
        }

        public abstract void HandlerEvent(MessageArgs args);

    }

}
