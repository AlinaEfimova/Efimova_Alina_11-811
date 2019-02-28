using System;
using System.Text;
using System.IO;

namespace MyLinkedList2
{
     class Elem 
    {
        public int Info { get; set; }
        public Elem Prev { get; set; }
        public Elem Next { get; set; }

        public override string ToString()
        {
            return "" + Info;
        }
    }

    class MyLinkedList2
    {
        public Elem Temp { get; set; }
        public MyLinkedList2() {}
        
        public MyLinkedList2(int[] arr)
        {
            foreach (var e in arr)
            {
                Add(e);
            }
        }

        public void Add(int x)
        {
            var el = new Elem() { Info = x, Prev = Temp, Next = null };
            if (Temp != null)
                Temp.Next = el;
            Temp = el;
        }

        public void Decode()
        {
            string str = ToString();
            File.WriteAllText("Out.txt", str);
        }
        
        public void Insert(int k)
        {
            var temp = Temp;
            var el = new Elem() { Info = k, Prev = null, Next = null };
            if (temp == null)
            {
                Add(k);
                return;
            }
            while (temp != null)
            {
                if (temp.Info <= k)
                {
                    el.Prev = temp;
                    el.Next = temp.Next;
                    if (temp.Next == null)
                        Add(k);
                    else
                    {
                        el.Prev.Next = el;
                        el.Next.Prev = el;
                    }
                    break;
                }
                if (temp.Prev == null)
                {
                    el.Next = temp;
                    el.Next.Prev = el;
                    break;
                }
                temp = temp.Prev;
            }
        }

        public void Delete(int k)
        {
            var temp = Temp;
            while (temp != null)
            {
                if (temp.Info == k)
                {
                    if (temp.Next == null)
                    {
                        Temp = Temp.Prev;
                        Temp.Next = null;
                        return;
                    }
                    if (temp.Prev != null)
                        temp.Prev.Next = temp.Next;
                    if (temp.Next != null)
                        temp.Next.Prev = temp.Prev;
                    return;
                }
                temp = temp.Prev;
            }
            throw new Exception("List does not contain this item");
        }

        public void Merge(MyLinkedList2 mll)
        {
            var temp = mll.Temp;
            while (temp != null)
            {
                Insert(temp.Info);
                temp = temp.Prev;
            }
        }
        
        public MyLinkedList2[] Divide()
        {
            var div3 = new MyLinkedList2();
            var other = new MyLinkedList2();
            var temp = Temp;
            while (temp.Next != null)
                temp = temp.Next;
            while (temp != null)
            {
                if (temp.Info % 3 == 0)
                    div3.Insert(temp.Info);
                else other.Insert(temp.Info);
                temp = temp.Prev;
            }
            return new MyLinkedList2[] { div3, other };
        }

        public int MaxNum()
        {
            int max = 0;
            int temp = 0;
            var prev = Temp;
            var el = Temp;
            while (el != null)
            {
                if (el.Info == prev.Info)
                    temp++;
                else
                {
                    prev = el;
                    temp = 1;
                }
                if (temp > max) max = temp;
                el = el.Prev;
            }
            return max;
        }

        public MyLinkedList2 NewList()
        {
            var result = new MyLinkedList2();
            var tail = Temp;
            var head = Temp;
            var count = Count();
            count = (count + 1) / 2;
            while (head.Prev != null)
            {
                head = head.Prev;
            }
            for (int i = 0; i < count; i++)
            {
                result.Add(head.Info * tail.Info);
                head = head.Next;
                tail = tail.Prev;
            }
            return result;
        }

        public int Count()
        {
            var temp = Temp;
            int result = 0;
            while (temp != null)
            {
                result++;
                temp = temp.Prev;
            }
            return result;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var el = Temp;
            while (el != null)
            {
                sb.Insert(0, $"{el.Info} ");
                el = el.Prev;
            }
            return sb.ToString();
            
        }
    }
}

