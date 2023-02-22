using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


// int형 싱글연결리스트
namespace Linked_list_int
{
    class Node
    {
        public Node(int data) // 노드 생성자
        {
            this.data = data;
            next = null;
        }

        internal int data; // 데이터
        internal Node next; // 다음 데이터
    }

    class LinkedList
    {
        Node head;

        // data를 갖는 노드를 만들고 맨 앞에 추가
        internal void InsertFront(int data)
        {
            Node node = new Node(data);
            node.next = head;
            head = node;
        }

        internal Node GetLastNode()
        {
            Node temp = head;
            while (temp.next != null)//노드의 끝에 도달
            {
                temp = temp.next;  //temp에 마지막 노드 저장
            }
            return temp; //리턴
        }

        internal void InsertAfter(int prev, int data)
        {
            Node prevNode = null;

            for (Node temp = head; temp != null; temp = temp.next)
                if (temp.data == prev) //노드를 앞에서 부터 훝어서 값이 prev인 곳을 찾는다.
                    prevNode = temp;

            if (prevNode == null)
            {
                Console.WriteLine("{0} data is not in the list");
                return;
            }

            Node node = new Node(data);
            node.next = prevNode.next; //사이에 낑겨넣기
            prevNode.next = node;
        }

        internal void DeleteNode(int key)
        {
            int cnt = 0;
            Node current = head;
            Node prev = null;

            if(key == 0)
            {
                head = current.next;
                return;
            }

            while(key != cnt)
            {
                prev = current;
                current = current.next;
                cnt++;
            }
            prev.next = current.next;
            
        }

        internal void Reverse()
        {
            Node Prev = null;
            Node current = head;
            Node temp = null;
            while (current != null)
            {
                temp = current.next;
                current.next = Prev;
                Prev = current;
                current = temp;
            }
            head = Prev;
        }

        internal void Print()
        {
            for (Node node = head; node != null; node = node.next)
                Console.Write(node.data + " -> ");
            Console.WriteLine();
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList link = new LinkedList();
            link.InsertFront(10);
            link.InsertFront(30);
            link.InsertAfter(10, 60);
            link.Print();
            link.DeleteNode(2);
            link.Print();
        }
    }
}