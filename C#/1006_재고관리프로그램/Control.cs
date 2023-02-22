using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_재고관리프로그램
{
    internal class Control
    {
        Product[] products;
        public static int maxsize;

        public Control(int size)
        {
            maxsize = size;
            products = new Product[maxsize];
        }

        public void printall()
        {
            int idx = 0;
            foreach(Product product in products)
            {
                if(product != null)
                {
                    Console.Write("{0} : ", idx);
                    product.print();
                    idx++;
                }
            }
        }

        public void insert()
        {
            Console.WriteLine("[제품 정보 저장]\n");
            int idx;

            string temp = String.Format("저장할 인덱스(0 ~ {0})", maxsize - 1);
            idx = wblib.getint(temp);

            if (products[idx] != null)
            {
                Console.WriteLine("데이터가 존재하는 인덱스 입니다.");
                return;
            }

            string name = wblib.getstring("제품 이름");
            int amount = wblib.getint("재고량");
            int price = wblib.getint("가격");
            int type = wblib.getint("1: 가전제품 2: 식품 3: 가구 4: 생필품");

            Product product = new Product(name,amount,price,(etype)type);
            products[idx] = product;
            Console.WriteLine("저장되었습니다.");
        }

        public void select()
        {
            Console.WriteLine("[제품 정보 검색]\n");

            string name = wblib.getstring("검색할 이름");

            int idx = nametoidx(name);
            if(idx == -1)
            {
                Console.WriteLine("존재하지 않는 이름입니다.");
                return;
            }
            Product product = products[idx];
            product.println();
        }

        public void update()
        {
            Console.WriteLine("[제품 정보 검색]\n");

            string name = wblib.getstring("변경할 제품");

            int idx = nametoidx(name);
            if (idx == -1)
            {
                Console.WriteLine("존재하지 않는 이름입니다.");
                return;
            }

            Product product = products[idx];

            product.Price = wblib.getint("가격");

            Console.WriteLine("수정완료");
        }

        public void substract()
        {
            Console.WriteLine("[제품 재고 빼기]\n");

            string name = wblib.getstring("재고량을 뺄 제품");

            int idx = nametoidx(name);
            if (idx == -1)
            {
                Console.WriteLine("존재하지 않는 이름입니다.");
                return;
            }

            int sub = wblib.getint("뺄 수량");

            if ((products[idx].Amount - sub) < 0)
            {
                Console.WriteLine("재고가 부족합니다.");
            }
            else if((products[idx].Amount - sub) == 0)
            {
                products[idx] = null;
                Console.WriteLine("재고를 모두 소진하여 제품을 삭제했습니다.");
            }
            else
            {
                int temp = products[idx].Amount;
                products[idx].Amount = temp - sub;
                Console.WriteLine("재고를 뺐습니다.");
            }
        }

        public void add()
        {
            Console.WriteLine("[제품 재고 추가]\n");

            string name = wblib.getstring("재고량을 추가할 제품");

            int idx = nametoidx(name);
            if (idx == -1)
            {
                Console.WriteLine("존재하지 않는 이름입니다.");
                return;
            }

            int sub = wblib.getint("추가할 수량");


                int temp = products[idx].Amount;
                products[idx].Amount = temp + sub;
                Console.WriteLine("재고를 추가했습니다.");
            
        }



        private int nametoidx(string name)
        {
            for(int i = 0; i < products.Length; i++)
            {
                Product product = products[i];
                if(product != null && product.Name == name)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
