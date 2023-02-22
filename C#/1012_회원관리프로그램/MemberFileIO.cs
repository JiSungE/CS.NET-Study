using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _1012_회원관리프로그램
{
    //직렬화 기반 FileIO (객체 기반으로 FileIO)
    internal static class MemberFileIO
    {
        public static void Save(Container container)
        {
            Stream ws = new FileStream("members.txt", FileMode.Create);
            
            BinaryFormatter serializer = new BinaryFormatter();

            int size = container.Size;
            serializer.Serialize(ws, size);

            //foreach (object m in members)
            for(int i=0; i<size; i++)
            {
                Member member = (Member)container[i];
                serializer.Serialize(ws, member); // 직렬화
            }

            ws.Close();
        }

        public static void Load(Container container)
        {
            Stream rs = new FileStream("members.txt", FileMode.Open);
            
            BinaryFormatter deserializer = new BinaryFormatter();

            int size = (int)deserializer.Deserialize(rs); // 역 직렬화

            for (int i = 0; i < size; i++)
            {
                Member member = (Member)deserializer.Deserialize(rs); // 역 직렬화
                container.Insert(member);
            }

            rs.Close();
        }
    }
}
