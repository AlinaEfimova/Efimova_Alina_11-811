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

        //public MyLinkedList2 NewList(int j)
        //{
        //    int n = 0;
        //    var temp = Temp;
        //    var newList = new MyLinkedList2();
        //    while (temp.Prev != null)
        //    {
        //        temp = temp.Prev;
        //    }
        //    while
        //}

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
