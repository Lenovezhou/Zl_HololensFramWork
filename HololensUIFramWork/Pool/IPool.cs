

namespace Zhoule
{
    public interface IPool<T>
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        T Allocate();

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool Recycle(T obj);
    }
}