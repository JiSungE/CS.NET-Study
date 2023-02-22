using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _1006_회원관리프로그램
{
    internal static class FileIO
    {
        public static void SaveMax(int max)
        {
            Stream ws = new FileStream("member_max.txt", FileMode.Create);

            BinaryFormatter serializer = new BinaryFormatter();

            serializer.Serialize(ws, max);

            ws.Close();
        }

        public static void Save(Container container)
        {
            Stream ws = new FileStream("members.txt", FileMode.Create);
            
            BinaryFormatter serializer = new BinaryFormatter();

            int size = container.Size;
            serializer.Serialize(ws, size);

            for(int i=0; i<size; i++)
            {
                Data member = (Data)container[i];
                serializer.Serialize(ws, member); 
            }

            ws.Close();
        }

        public static void LoadMax(out int max)
        {
            Stream rs = new FileStream("member_max.txt", FileMode.Open);

            BinaryFormatter deserializer = new BinaryFormatter();

            max = (int)deserializer.Deserialize(rs);

            rs.Close();
        }

        public static void Load(Container container)
        {
            Stream rs = new FileStream("members.txt", FileMode.Open);
            
            BinaryFormatter deserializer = new BinaryFormatter();

            int size = (int)deserializer.Deserialize(rs); 

            for (int i = 0; i < size; i++)
            {
                Data member = (Data)deserializer.Deserialize(rs); 
                container.Insert(member);
            }

            rs.Close();
        }
    }
}
