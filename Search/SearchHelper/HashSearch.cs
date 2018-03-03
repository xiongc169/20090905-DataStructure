/***********************************************************************************************************************************
 * 
 * 功能：查找算法——哈希查找
 * 
 * 作者：chaoxiong
 * 
 * 时间：2014-08-01
 * 
 * 参考：
 * http://www.cnblogs.com/huangxincheng/archive/2011/11/24/2261074.html
 * 
 * 备注：
 * 哈希查找；
 * 
 * 哈希函数的两点原则：
 * key(散列地址)尽可能的分散，若“6”和“5”都返回“2”，那么这样的哈希函数不尽完美；
 * 哈希函数尽可能的简单、快速；
 * 
 * 哈希函数的设计方法：
 * 1、直接定址法，key = Value + C ；
 * 2、除法取余法，key = value % c ；
 * 3、数字分析法；
 * 4、平方取中法；
 * 5、折叠法；
 * 
 * 哈希函数散列地址冲突的解决办法：
 * 1、开放地址法；
 * 2、链接法；
 * 
 ***********************************************************************************************************************************/

namespace Search.SearchHelper
{
    /// <summary>
    /// 哈希查找
    /// </summary>
    public class HashSearch
    {
        ///<summary>
        /// Hash表检索数据
        ///</summary>
        ///<param name="hash"></param>
        ///<param name="hashLength"></param>
        ///<param name="key"></param>
        ///<returns></returns>
        public static int SearchHash(int[] hash, int hashLength, int key)
        {
            //哈希函数
            int hashAddress = key % hashLength;

            //指定hashAdrress对应值存在但不是关键值，则用开放寻址法解决
            while (hash[hashAddress] != 0 && hash[hashAddress] != key)
            {
                hashAddress = (++hashAddress) % hashLength;
            }

            //查找到了开放单元，表示查找失败
            if (hash[hashAddress] == 0)
                return -1;
            return hashAddress;
        }

        ///<summary>
        ///数据插入Hash表
        ///</summary>
        ///<param name="hash">哈希表</param>
        ///<param name="hashLength"></param>
        ///<param name="data"></param>
        public static void InsertHash(int[] hash, int hashLength, int data)
        {
            //设计哈希函数——除法取余法
            int hashAddress = data % 13;
            //如果key存在，则说明已经被别人占用，此时必须解决冲突
            while (hash[hashAddress] != 0)
            {
                //用开放寻址法找到
                hashAddress = (++hashAddress) % hashLength;
            }

            //将data存入字典中
            hash[hashAddress] = data;
        }
    }
}
