using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Zhoule
{
    /// <summary>
    /// 模块码
    /// </summary>
    public enum ModuleArea
    {
        UIManager = QMgrID.UI,
        SoundManager= QMgrID.Audio,
        DigitalAssertManager = QMgrID.DigitalAssert

    }

    /// <summary>
    /// 消息内容
    /// </summary>
    public class MessageArgs:IPoolable
    {
        /// <summary>
        /// 模块
        /// </summary>
        public ModuleArea ma;


        /// <summary>
        /// 操作码
        /// </summary>
        public int opcode;


        /// <summary>
        /// 子操作
        /// </summary>
        public int subcode;

        /// <summary>
        /// 参数
        /// </summary>
        public object param;

        public bool IsRecycled { get; set; }

        public void OnRecycled()
        {
            opcode = 0;
            subcode = 0;
            param = null;
            IsRecycled = true;
        }
    }
}

