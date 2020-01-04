using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Test
    {
        private static int[] array = new int[6] { 5, 3, 6, 2, -1, 8 };

        static void Main(string[] args)
        {
            //MaoPao(array);
            //ZhiJie(array);
            //KuaiSu(array, 0, array.Length - 1);
            Shell(array);
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="array"></param>
        private static void MaoPao(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            Show("冒泡排序：", array);

        }
        /// <summary>
        /// 直接排序
        /// </summary>
        /// <param name="array"></param>
        private static void ZhiJie(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int index = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[j] < array[index])
                    {
                        index = j;
                    }
                }
                int temp = array[index];
                array[index] = array[i];
                array[i] = temp;
            }
            Show("直接排序：", array);
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="lowIndex">头索引编号 初始值为0</param>
        /// <param name="hightIndex">尾索引编号 初始值为array.length-1</param>
        private static void KuaiSu(int[] array, int lowIndex, int hightIndex)
        {
            int i, j, key;
            i = lowIndex;
            j = hightIndex;
            key = array[i];
            if (i >= j) return;
            while (i < j)
            {
                while (array[j] > key && i < j)
                    j--;
                int temp = array[j];
                array[j] = array[i];
                array[i] = temp;

                while (array[i] < key && i < j)
                    i++;
                temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
            //对基准左侧进行排序
            KuaiSu(array, lowIndex, i - 1);
            //对基准右侧进行排序
            KuaiSu(array, i + 1, hightIndex);

            Show("快速排序:", array);
        }

        /// <summary>
        /// 遍历已排好数组
        /// </summary>
        /// <param name="sortName"></param>
        /// <param name="array"></param>
        private static void Show(string sortName, int[] array)
        {
            Console.WriteLine(sortName);
            int count = array.Length - 1;
            foreach (int arr in array)
            {
                Console.Write(arr);
                if (count > 0)
                {
                    Console.Write(",");
                    count--;
                }
            }
            Console.WriteLine("\n----------------------------------");
        }

        /// <summary>
        /// 直接插入排序  5, 3, 6, 2, -1, 8
        /// </summary>
        /// <param name="array"></param>
        public static void ChaRu(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < array[i - 1])
                {
                    int temp = array[i];
                    int j = 0;
                    for (j = i - 1; j >= 0 && temp < array[j]; j--)
                    {
                        array[j + 1] = array[j];
                    }
                    array[j + 1] = temp;
                }
                Show("直接插入排序过程:", array);
            }
            Show("直接插入排序:", array);
        }

        /// <summary>
        /// 希尔排序 
        /// </summary>
        /// <param name="array"></param>
        public static void Shell(int[] array)
        {
            int gap = array.Length / 2;
            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    if (array[i] < array[i - 1])
                    {
                        int temp = array[i];
                        int j = 0;
                        for (j = i - gap; j >= 0 && temp < array[j]; j-= gap)
                        {
                            array[j + gap] = array[j];
                        }
                        array[j + gap] = temp;
                    }
                    Show("shell排序过程:", array);
                }
                gap /= 2;
            }
            Show("shell排序:", array);
        }
    }
}
