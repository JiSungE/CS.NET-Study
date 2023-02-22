using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1013_Client
{
    public enum enumGender { 없음, 남자, 여자 }

    [Serializable]
    internal class Member
    {
        private static int s_number = 1000;

        public int Number { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; set; }

        int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0)
                    age = value;
            }
        }
        public enumGender Gender { get; private set; }

        public Member(string _name, string _phone, int _age, enumGender _gender)
        {
            Number = s_number++;
            Name = _name;
            Phone = _phone;
            Age = _age;
            Gender = _gender;
        }

        public void Print()
        {
            Console.Write("[" + Number + "] ");
            Console.Write(Name + "\t");
            Console.Write(Phone + "\t");
            Console.Write(Age + "\t");
            Console.WriteLine(Gender);
        }

        public void Println()
        {
            Console.WriteLine("회원번호 : {0}", Number);
            Console.WriteLine("이    름 : " + Name);
            Console.WriteLine("전화번호 : {0}", Phone);
            Console.WriteLine("나    이 : {0}", Age);
            Console.WriteLine("성    별 : {0}", Gender);
        }
    }
}
