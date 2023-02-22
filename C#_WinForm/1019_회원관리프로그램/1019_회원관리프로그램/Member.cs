using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1019_회원관리프로그램
{
    public class Member
    {
		public string Id		{ get; private set; }
		public string PassWord	{ get; private set; }
		public string Name		{ get; private set; }
		public string Phone		{ get; set; }		
		public DateTime  Date   { get; private set; }

        #region 
        public Member(string id, string password, string name, string phone)
			:this(id, password, name, phone, DateTime.Now)
        {
        }

		public Member(string id, string password, string name, string phone, DateTime date)
		{
			Id = id;
			PassWord = password;
			Name = name;	
			Phone = phone;
			Date = date;
		}
        #endregion 
    
	}
}
