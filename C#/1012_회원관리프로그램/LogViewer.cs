using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1012_회원관리프로그램
{
    internal class LogViewer
    {
        const string FileName = "log.txt";
        public LogViewer()
        {
            Control con = Control.Singleton;
            //이벤트 처리기 등록
            con.AddMemberEvent += new AddMemberEvent(mm_AddMemberEventHandler);
            con.SelectMemberEvent += new SelectMemberEvent(mm_AddMemberEventHandler);
            con.UpdateDele = new UpdateMemberEvent(mm_updateMemberEventHandler);
        }
        void mm_AddMemberEventHandler(object obj, AddMemberEventArgs e)
        {
            FileStream fs = new FileStream(FileName, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            //Console.WriteLine("회원이 추가되었습니다.");
            //Console.WriteLine("회원번호:{0} 이름:{1}", e.Number, e.Name);
            sw.Write("[회원추가] {0} : ", DateTime.Now);
            sw.WriteLine("{0}", e.Number + ", " + e.Name);

            sw.Close();
            fs.Close();
        }

        void mm_AddMemberEventHandler(object obj, SelectMemberEventArgs e)
        {
            FileStream fs = new FileStream(FileName, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write("[회원검색] {0} : ", DateTime.Now);
            sw.WriteLine("{0}", e.Name);

            sw.Close();
            fs.Close();
        }

        void mm_updateMemberEventHandler(object obj, UpdateMemberEventArgs e)
        {
            FileStream fs = new FileStream(FileName, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);

            sw.Write("[회원 수정] {0} : ", DateTime.Now);
            sw.WriteLine("{0}", e.Name + ", " + e.Phone + ", " + e.Age);

            sw.Close();
            fs.Close();
        }
    }
}
