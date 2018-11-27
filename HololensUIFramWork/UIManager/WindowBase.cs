using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zhoule
{
    public class WindowBase : MonoBehaviour
    {
        protected bool needrefresh;
        ///自身缓存数据
        protected object data;

        protected List<string> attention_events;

        protected Action<MessageArgs> SendEventCall;


        public void Init(Action<MessageArgs> Call)
        {
            SendEventCall = Call;
        }



        public void Show(object param = null)
        {
            RefreshMe();
        }
        public void Hide()
        {
            ResetMe();
            gameObject.SetActive(false);
        }


        /// <summary>
        /// 刷新页面
        /// </summary>
        protected virtual void RefreshMe()
        {
            gameObject.SetActive(true);
        }

        protected virtual void RefreshMe(object param)
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }
            //TODO Refresh
            data = param;
        }

        /// <summary>
        /// 注册关注事件
        /// </summary>
        /// <param name="eventname"></param>
        /// <returns></returns>
        protected virtual bool RegisterHandler(string eventname)
        {
            if (attention_events.Contains(eventname))
            {
                return false;
            }
            attention_events.Add(eventname);
            return true;
        }

        protected virtual void SendEvent(MessageArgs args)
        {
            SendEventCall(args);
        }


        /// <summary>
        /// 响应事件
        /// </summary>
        /// <param name="eventname"></param>
        /// <param name="param"></param>
        public virtual void HandleEvent(string eventname, object param = null) { }
        /// <summary>
        /// 是否关心此事件
        /// </summary>
        /// <param name="eventname"></param>
        /// <returns></returns>
        public bool ContainsEvent(string eventname) { return attention_events.Contains(eventname); }
        /// <summary>
        /// 重置页面
        /// </summary>
        protected virtual void ResetMe() { }
    }

}
