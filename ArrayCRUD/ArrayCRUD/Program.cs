using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayCRUD
{
    class ArrayOperations
    {
        private int[] array;
        private int count;

        public ArrayOperations(int size)
        {
            array = new int[size];
            count = 0;
        }

        public void Add(int value)
        {
            if (count < array.Length)
            {
                array[count] = value;
                count++;
            }
            else
            {
                Console.WriteLine("Dizi dolu, ekleme yapılamaz.");
            }
        }

        public void Delete(int value)
        {
            int index = Search(value);
            if (index != -1)
            {
                int[] newArray = new int[array.Length];
                int newIndex = 0;
                for (int i = 0; i < count; i++)
                {
                    if (i != index)
                    {
                        newArray[newIndex++] = array[i];
                    }
                }
                array = newArray;
                count--;
            }
            else
            {
                Console.WriteLine("Silinecek eleman bulunamadı.");
            }
        }

        public void Update(int oldValue, int newValue)
        {
            int index = Search(oldValue);
            if (index != -1)
            {
                array[index] = newValue;
            }
            else
            {
                Console.WriteLine("Güncellenecek eleman bulunamadı.");
            }
        }

        public int Search(int value)
        {
            for (int i = 0; i < count; i++)
            {
                if (array[i] == value)
                    return i;
            }
            return -1;
        }

        public void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main()
        {
            ArrayOperations arrOps = new ArrayOperations(5);

            arrOps.Add(10);
            arrOps.Add(20);
            arrOps.Add(30);
            arrOps.Print(); // 10 20 30

            arrOps.Update(20, 25);
            arrOps.Print(); // 10 25 30

            arrOps.Delete(10);
            arrOps.Print(); // 25 30

            int index = arrOps.Search(30);
            Console.WriteLine("30 değeri indeks: " + index);
        }
    }
}
