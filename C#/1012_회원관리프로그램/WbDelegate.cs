using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    // 1) delegate에서 사용할 arg클래스 정의
    // 2) delegate 정의
namespace _1012_회원관리프로그램
{
    #region 회원 검색 관련 델리게이트

    public class SelectMemberEventArgs:EventArgs
    {
        public string Name { get; private set; }

        public SelectMemberEventArgs(string name)
        {
            Name = name;
        }
    }

    internal delegate void SelectMemberEvent(object sender, SelectMemberEventArgs e);
    #endregion

    #region 회원저장 델리게이트 지정
    /// <summary>
    /// 회원저장 관련 인자 클래스
    /// </summary>
    public class AddMemberEventArgs: EventArgs
    {
        public int Number { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; set; }
        int age;
        public int Age
        {
            get { return age; }
            private set
            {
                if (value > 0)
                    age = value;
            }
        }

        public enumGender Gender { get; private set; }

        public AddMemberEventArgs(int number, string name, string phone, int age, enumGender gender)
        {
            Number = number;
            Name = name;
            Phone = phone;
            Age = age;
            Gender = gender;
        }
    }

    public delegate void AddMemberEvent(object obj, AddMemberEventArgs e);
    #endregion

    #region 회원 수정 관련 델리게이트

    public class UpdateMemberEventArgs : EventArgs
    {
        public string Name { get; private set; }

        public string Phone { get; set; }

        public int Age { get; private set; }

        public UpdateMemberEventArgs(string name, string phone, int age)
        {
            Name = name;
            Phone = phone;
            Age = age;
        }
    }

    internal delegate void UpdateMemberEvent(object sender, UpdateMemberEventArgs e);
    #endregion
}
