using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ZI_4
{
    class Program
    {
        static Int16[] Key1 = new Int16[256];
        static Int16[] Key2 = new Int16[256];
        static Int16[] Key3 = new Int16[256];
        static Int16[] Key4 = new Int16[256];

        static Int16[] message = new Int16[256];
        static Int16[] H = new Int16[256];
        static Int16[] Hesh = new Int16[256];

        static Int16[] C2 = new Int16[256];
        static Int16[] C4 = new Int16[256];
        static Int16[] C3 = { 1, 1, 1, 1, 1, 1, 1, 1,   // 1^8
                              0, 0, 0, 0, 0, 0, 0, 0,   // 0^8
                              1, 1, 1, 1, 1, 1, 1, 1,   // 1^16
                              1, 1, 1, 1, 1, 1, 1, 1,
                              0, 0, 0, 0, 0, 0, 0, 0,   // 0^24
                              0, 0, 0, 0, 0, 0, 0, 0,
                              0, 0, 0, 0, 0, 0, 0, 0,
                              1, 1, 1, 1, 1, 1, 1, 1,   // 1^16
                              1, 1, 1, 1, 1, 1, 1, 1,
                              0, 0, 0, 0, 0, 0, 0, 0,   // 0^8
                              0, 0, 0, 0, 0, 0, 0, 0,   // 0^8  // х2
                              1, 1, 1, 1, 1, 1, 1, 1,   // 1^8  //
                              0, 0, 0, 0, 0, 0, 0, 0,   
                              1, 1, 1, 1, 1, 1, 1, 1,
                              1, 1, 1, 1, 1, 1, 1, 1,   // 1^8
                              0, 0, 0, 0, 0, 0, 0, 0,   // 0^8
                              0, 0, 0, 0, 0, 0, 0, 0,   // 0^8  // х4
                              1, 1, 1, 1, 1, 1, 1, 1,   // 1^8  //
                              0, 0, 0, 0, 0, 0, 0, 0,
                              1, 1, 1, 1, 1, 1, 1, 1,
                              0, 0, 0, 0, 0, 0, 0, 0,   
                              1, 1, 1, 1, 1, 1, 1, 1,   
                              0, 0, 0, 0, 0, 0, 0, 0,
                              1, 1, 1, 1, 1, 1, 1, 1,
                              1, 1, 1, 1, 1, 1, 1, 1,   // 1^8     // х4
                              0, 0, 0, 0, 0, 0, 0, 0,   // 0^8      //
                              1, 1, 1, 1, 1, 1, 1, 1,  
                              0, 0, 0, 0, 0, 0, 0, 0,   
                              1, 1, 1, 1, 1, 1, 1, 1,  
                              0, 0, 0, 0, 0, 0, 0, 0,   
                              1, 1, 1, 1, 1, 1, 1, 1,  
                              0, 0, 0, 0, 0, 0, 0, 0,   };

        static string path;
        static int pointer;


        private static void GetNewKeys()
        {
            Int16[] U = new Int16[256];     /* ? */
            Int16[] V = new Int16[256];     /* ? */
            Int16[] W = new Int16[256];     /* ? */

            //-------------------------------------- key1 ---------------------------------------------
            for (int i = 0; i < U.Length; i++)
            {
                U[i] = H[i];
                V[i] = message[i];
                W[i] = XOR(U[i], V[i]);
            }
            Key1 = MoveP(W);

            //-------------------------------------- key2 ---------------------------------------------
            Int16[] buf = new Int16[256];

            buf = MoveA(U);
            for (int i = 0; i < U.Length; i++)
            {
                U[i] = XOR(buf[i], C2[i]);
            }

            buf = MoveA(V);
            V = MoveA(buf);

            for (int i = 0; i < W.Length; i++)
            {
                W[i] = XOR(U[i], V[i]);
            }

            Key2 = MoveP(W);

            //-------------------------------------- key3 ---------------------------------------------
            buf = MoveA(U);
            for (int i = 0; i < U.Length; i++)
            {
                U[i] = XOR(buf[i], C3[i]);
            }

            buf = MoveA(V);
            V = MoveA(buf);

            for (int i = 0; i < W.Length; i++)
            {
                W[i] = XOR(U[i], V[i]);
            }

            Key3 = MoveP(W);

            //-------------------------------------- key4 ---------------------------------------------
            buf = MoveA(U);
            for (int i = 0; i < U.Length; i++)
            {
                U[i] = XOR(buf[i], C4[i]);
            }

            buf = MoveA(V);
            V = MoveA(buf);

            for (int i = 0; i < W.Length; i++)
            {
                W[i] = XOR(U[i], V[i]);
            }

            Key4 = MoveP(W);
        }

        private static Int16[] MoveA(Int16[] A)
        {
            Int16[] Ans = new short[A.Length];

            for (int i = 0; i < A.Length / 4; i++)
            {
                Ans[i] = XOR(A[i], A[i + A.Length / 4]);
                Ans[i + A.Length / 4] = A[i + 3 * (A.Length / 4)];
                Ans[i + 2 * (A.Length / 4)] = A[i + 2 * (A.Length / 4)];
                Ans[i + 3 * (A.Length / 4)] = A[i + A.Length / 4];
            }
            return Ans;
        }

        private static Int16[] MoveP(Int16[] data)
        {
            Int16[] outData = new short[256];

            for (int i = 0; i < 8; i++)
            {
                outData[i] = data[i];
                outData[8 + i] = data[4 * 8 + i];
                outData[2 * 8 + i] = data[8 * 8 + i];
                outData[3 * 8 + i] = data[12 * 8 + i];
                outData[4 * 8 + i] = data[16 * 8 + i];
                outData[5 * 8 + i] = data[20 * 8 + i];
                outData[6 * 8 + i] = data[24 * 8 + i];
                outData[7 * 8 + i] = data[28 * 8 + i];

                outData[8 * 8 + i] = data[8 + i];
                outData[9 * 8 + i] = data[5 * 8 + i];
                outData[10 * 8 + i] = data[9 * 8 + i];
                outData[11 * 8 + i] = data[13 * 8 + i];
                outData[12 * 8 + i] = data[17 * 8 + i];
                outData[13 * 8 + i] = data[21 * 8 + i];
                outData[14 * 8 + i] = data[25 * 8 + i];
                outData[15 * 8 + i] = data[29 * 8 + i];

                outData[16 * 8 + i] = data[2 * 8 + i];
                outData[17 * 8 + i] = data[6 * 8 + i];
                outData[18 * 8 + i] = data[10 * 8 + i];
                outData[19 * 8 + i] = data[14 * 8 + i];
                outData[20 * 8 + i] = data[18 * 8 + i];
                outData[21 * 8 + i] = data[22 * 8 + i];
                outData[22 * 8 + i] = data[26 * 8 + i];
                outData[23 * 8 + i] = data[30 * 8 + i];

                outData[24 * 8 + i] = data[3 * 8 + i];
                outData[25 *8 + i] = data[7 * 8 + i];
                outData[26 *8 + i] = data[11 * 8 + i];
                outData[27 *8 + i] = data[15 * 8 + i];
                outData[28 *8 + i] = data[19 * 8 + i];
                outData[29 *8 + i] = data[23 * 8 + i];
                outData[30 *8 + i] = data[27 * 8 + i];
                outData[31 *8 + i] = data[31 * 8 + i];
            }
            return outData;
        }

        private static Int16[] MovePSI(Int16[] data)
        {
            Int16[] buf = new short[16];
            Int16[] ans = new short[data.Length];

            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = XOR(data[i], data[16 + i]);
            }

            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = XOR(buf[i], data[2 * 16 + i]);
            }

            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = XOR(data[i], data[3 * 16 + i]);
            }

            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = XOR(data[i], data[12 * 16 + i]);
            }

            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = XOR(data[i], data[15 * 16 + i]);
            }

            for (int i = 0; i < buf.Length; i++)
            {
                ans[i] = buf[i];
                ans[buf.Length + i] = data[15 * buf.Length + i];
                ans[2 * buf.Length + i] = data[14 * buf.Length + i];
                ans[3 * buf.Length + i] = data[13 * buf.Length + i];
                ans[4 * buf.Length + i] = data[12 * buf.Length + i];
                ans[5 * buf.Length + i] = data[11 * buf.Length + i];
                ans[6 * buf.Length + i] = data[10 * buf.Length + i];
                ans[7 * buf.Length + i] = data[9 * buf.Length + i];
                ans[8 * buf.Length + i] = data[8 * buf.Length + i];
                ans[9 * buf.Length + i] = data[7 * buf.Length + i];
                ans[10 * buf.Length + i] = data[6 * buf.Length + i];
                ans[11 * buf.Length + i] = data[5 * buf.Length + i];
                ans[12 * buf.Length + i] = data[4 * buf.Length + i];
                ans[13 * buf.Length + i] = data[3 * buf.Length + i];
                ans[14 * buf.Length + i] = data[2 * buf.Length + i];
                ans[15 * buf.Length + i] = data[buf.Length + i];
            }
            return ans;
        }

        private static Int16 XOR(Int16 a, Int16 b)
        {
            if (a + b == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private static void ConvertToBL(byte sumbol)
        {
            Int16[] buf = new Int16[8];

            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = Convert.ToInt16(sumbol % 2);
                sumbol /= 2;
            }

            for (int i = 0; i < buf.Length; i++)
            {
                message[(message.Length - pointer * 8 - 1 - i)] = buf[i];
            }

            pointer++;
        }

        private static void GetHesh()
        {
            Int16[] buf = new Int16[64];

            // ---------------------------------------- 1 часть -------------------------------
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = message[i];
            }

            gost_28147_89.Key = Key1;
            gost_28147_89.Message = buf;
            buf = gost_28147_89.GetEncription();

            for (int i = 0; i < buf.Length; i++)
            {
                H[i] = buf[i];
            }

            // ---------------------------------------- 2 часть -------------------------------
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = message[i + buf.Length];
            }

            gost_28147_89.Key = Key2;
            gost_28147_89.Message = buf;
            buf = gost_28147_89.GetEncription();

            for (int i = 0; i < buf.Length; i++)
            {
                H[i + buf.Length] = buf[i];
            }

            // ---------------------------------------- 3 часть -------------------------------
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = message[i + 2 * buf.Length];
            }

            gost_28147_89.Key = Key3;
            gost_28147_89.Message = buf;
            buf = gost_28147_89.GetEncription();

            for (int i = 0; i < buf.Length; i++)
            {
                H[i + 2 * buf.Length] = buf[i];
            }

            // ---------------------------------------- 4 часть -------------------------------
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = message[i + 3 * buf.Length];
            }

            gost_28147_89.Key = Key4;
            gost_28147_89.Message = buf;
            buf = gost_28147_89.GetEncription();

            for (int i = 0; i < buf.Length; i++)
            {
                H[i + 3 * buf.Length] = buf[i];
            }
        }

        private static void GetGlobalHesh()
        {
            Int16[] buf = new Int16[256];

            for (int i = 0; i < 12; i++)
            {
                buf = MovePSI(H);
            }

            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = XOR(buf[i], message[i]);
            }

            buf = MovePSI(buf);

            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = XOR(Hesh[i], buf[i]);
            }

            for (int i = 0; i < 61; i++)
            {
                Hesh = MovePSI(buf);
            }
        }

        private static void ReadBinaryFile()
        {
            byte symbol;

            Console.Write("Введите абсолютый путь к файлу: ......... ");
            path = Console.ReadLine();
            path += @"\";
            Console.Write("Введите имя файла с расширением: ........ ");
            string file = Console.ReadLine();

            BinaryReader br = new BinaryReader(File.Open(path + file, FileMode.Open), Encoding.UTF8);
            while (br.BaseStream.Position != br.BaseStream.Length) // Пока не достигли конца файла
            {
                symbol = br.ReadByte();
                ConvertToBL(symbol); // Запись байта в message

                if (pointer == 32)  // Если считали 256 бит
                {
                    pointer = 0;

                    GetNewKeys(); // Получаем ключи
                    GetHesh(); // Получаем новый ХЕШ по госту
                    GetGlobalHesh(); // Получаем основной ХЕШ

                    for (int i = 0; i < message.Length; i++)    
                    {
                        message[i] = 0;
                    }   // обнуляем считанный массив
                }
            }
            br.Close();

            if (pointer != 0)
            {
                GetNewKeys(); // Получаем ключи
                GetHesh(); // Получаем новый ХЕШ по госту
                GetGlobalHesh(); // Получаем основной ХЕШ
            }   // Контроль по остаткам
        }

        private static Byte[] ConvertBLtoByte(Int16[] data)
        {
            Byte[] ans = new Byte[data.Length / 8];

            for (int i = 0; i < ans.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ans[i] += Convert.ToByte(data[i * 8 + j] * Math.Pow(2, j));
                }
            }
            return ans;
        }

        private static void ShowHeshCode()
        {
            byte[] ans = new byte[Hesh.Length / 8];
            ans = ConvertBLtoByte(Hesh);

            BinaryWriter bw = new BinaryWriter(File.Open(path + "heshcode.txt", FileMode.OpenOrCreate),Encoding.UTF8);
            for (int i = 0; i < ans.Length; i++)
            {
//                Console.Write(ans[i]);
                bw.Write(ans[i]);
            }
            bw.Close();
        }

        static void Main(string[] args)
        {
            ReadBinaryFile();
            ShowHeshCode();

            Console.Read();
        }
    }
}
