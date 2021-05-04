using System;
using System.Collections.Generic;

namespace List
{
    public class Node<T>
    {
        public T value { get; set; }
        public Node<T> next { get; private set; }
        

        public Node(T value, Node<T> lowerNode)
        {
            this.value = value;
            next = lowerNode;
        }
        public void ChangePointer(Node<T> lowerNode) ///Функция для добавления у старого tail ссылки на новый tail 
        {
            next = lowerNode;
        }
    }
    public class listFixed<T>
    {

        protected Node<T> tail;
        protected Node<T> head;

        public int Count
        {
            get
            {
                int result = 0;
                var pointer = head;
                while (pointer.next != null)
                {
                    pointer = pointer.next;
                    result++;
                }
                return result;
            }
        }
        public listFixed()
        {
            tail = new Node<T>(default(T), null);
            head = tail;
        }
        public void Add(T value)
        {
            var newNode = new Node<T>(value, null);
            tail.ChangePointer(newNode);
            tail = newNode;
        }

        public T this[int index]
        {
            get
            {
                var pointer = GetElementByIndex(index);
                return pointer == default(Node<T>) ? default(T) : pointer.value ; 
            }
            set
            {
                var pointer = GetElementByIndex(index);
                pointer.value = value;
            }
        }

        private Node<T> GetElementByIndex(int index)
        {
            var pointer = head.next;
            for (int i = 1; i <= index; i++)
            {
                pointer = pointer.next;
            }
            return pointer;

        }

        public void Delete(int index)
        {
            if (index >= Count || index<0) { throw new IndexOutOfRangeException("Index was out of bounds");}
            var pointer = GetElementByIndex(index - 1);
            Node<T> prevPointer = pointer;
            pointer = pointer.next;
          var newPointer = pointer.next == default(Node<T>) ? null : pointer.next;
            prevPointer.ChangePointer(newPointer);
           

        }

        public void Insert (T value, int index)
        {
            if (index >= Count || index < 0) { throw new IndexOutOfRangeException("Index was out of bounds"); }
            if (index == 0) 
            {
               head.ChangePointer(new Node<T>(value, head.next));
               return;
            }
            
            var pointer = GetElementByIndex(index-1);
            
            var newPointer = new Node<T>(value, pointer.next== default(Node<T>)? null : pointer.next );
            pointer.ChangePointer(newPointer);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            char exitCheck = 'n';
            listFixed<string> listFixed = new listFixed<string>();
            while (exitCheck != 'y')
            {
                Console.WriteLine("Enter command name ");
                string menu = Console.ReadLine();
                switch (menu)
                {
                    case "0": //добавление

                        Console.WriteLine("Enter adding item");
                        string inputer = Console.ReadLine();
                        listFixed.Add(inputer);
                        Console.WriteLine("Current head is :");
                        Console.WriteLine(listFixed[listFixed.Count - 1]);
                        Console.WriteLine("---------------------------------------------------");
                        break;

                    case "1": //удаление
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Enter index to delete");
                        var inpute = Console.ReadLine();
                        Console.WriteLine(listFixed[int.Parse(inpute)]);
                        listFixed.Delete(int.Parse(inpute));
                        Console.WriteLine(listFixed[int.Parse(inpute)]);
                        Console.WriteLine("---------------------------------------------------");
                        break;
                    case "2":  //вставка
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Enter index to insert");
                        var input = Console.ReadLine();
                        Console.WriteLine("Enter value to insert");
                        var valuet = Console.ReadLine();
                        Console.WriteLine("Prev is ",listFixed[int.Parse(input)]);
                        listFixed.Insert(valuet,int.Parse(input));
                        Console.WriteLine("Cur is ",listFixed[int.Parse(input)]);
                        Console.WriteLine("---------------------------------------------------");
                        break;



                }

            }
            Console.ReadLine();
        }
    }


}
