

namespace Zhoule
{
    using System;

    /// <summary>
    /// Unity 游戏框架搭建 (十九) 简易对象池：http://qframework.io/post/24/ 的例子
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleObjectPool<T> : Pool<T>
    {
        readonly Action<T> mResetMethod;

        public SimpleObjectPool(Func<T> factoryMethod, Action<T> resetMethod = null,int initCount = 0)
        {
            mFactory = new CustomObjectFactory<T>(factoryMethod);
            mResetMethod = resetMethod;

            for (int i = 0; i < initCount; i++)
            {
                mCacheStack.Push(mFactory.Create());
            }
        }

        public override bool Recycle(T obj)
        {
            mResetMethod.InvokeGracefully(obj);
            mCacheStack.Push(obj);
            return true;
        }
    }
}