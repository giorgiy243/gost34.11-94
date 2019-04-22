using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZI_4
{
    static class gost_28147_89
    {
        private static Int16[] message = new Int16[64];
        private static Int16[] L = new Int16[32];
        private static Int16[] R = new Int16[32];
        private static Int16[] key = new Int16[256];

        private static Int16[] key1 = new Int16[32];
        private static Int16[] key2 = new Int16[32];
        private static Int16[] key3 = new Int16[32];
        private static Int16[] key4 = new Int16[32];
        private static Int16[] key5 = new Int16[32];
        private static Int16[] key6 = new Int16[32];
        private static Int16[] key7 = new Int16[32];
        private static Int16[] key8 = new Int16[32];
        private static Int16[] key9 = new Int16[32];
        private static Int16[] key10 = new Int16[32];
        private static Int16[] key11 = new Int16[32];
        private static Int16[] key12 = new Int16[32];
        private static Int16[] key13 = new Int16[32];
        private static Int16[] key14 = new Int16[32];
        private static Int16[] key15 = new Int16[32];
        private static Int16[] key16 = new Int16[32];
        private static Int16[] key17 = new Int16[32];
        private static Int16[] key18 = new Int16[32];
        private static Int16[] key19 = new Int16[32];
        private static Int16[] key20 = new Int16[32];
        private static Int16[] key21 = new Int16[32];
        private static Int16[] key22 = new Int16[32];
        private static Int16[] key23 = new Int16[32];
        private static Int16[] key24 = new Int16[32];
        private static Int16[] key25 = new Int16[32];
        private static Int16[] key26 = new Int16[32];
        private static Int16[] key27 = new Int16[32];
        private static Int16[] key28 = new Int16[32];
        private static Int16[] key29 = new Int16[32];
        private static Int16[] key30 = new Int16[32];
        private static Int16[] key31 = new Int16[32];
        private static Int16[] key32 = new Int16[32];



        public static Int16[] Message {
            get { return message; }
            set
            {
                if (value.Length <= 64)
                {
                    message = value;
                }
            }
        }

        public static Int16[] Key
        {
            get { return key; }
            set
            {
                if (value.Length == 256)
                {
                    key = value;
                }
            }
        }

        // Заполняем ключи для шифрования
        private static void GetSubkeys()
        {
            for (int i = 0; i < key1.Length; i++)
            {
                key1[i] = key[i];
            }

            for (int i = 0; i < key2.Length; i++)
            {
                key2[i] = key[i + 32];
            }

            for (int i = 0; i < key3.Length; i++)
            {
                key3[i] = key[i + 2 * 32];
            }

            for (int i = 0; i < key4.Length; i++)
            {
                key4[i] = key[i + 3 * 32];
            }

            for (int i = 0; i < key5.Length; i++)
            {
                key5[i] = key[i + 4 * 32];
            }

            for (int i = 0; i < key6.Length; i++)
            {
                key6[i] = key[i + 5 * 32];
            }

            for (int i = 0; i < key7.Length; i++)
            {
                key7[i] = key[i + 6 * 32];
            }

            for (int i = 0; i < key8.Length; i++)
            {
                key8[i] = key[i + 7 * 32];
            }

            for (int i = 0; i < key9.Length; i++)
            {
                key9[i] = key1[i];
            }

            for (int i = 0; i < key10.Length; i++)
            {
                key10[i] = key2[i];
            }

            for (int i = 0; i < key11.Length; i++)
            {
                key11[i] = key3[i];
            }

            for (int i = 0; i < key12.Length; i++)
            {
                key12[i] = key4[i];
            }

            for (int i = 0; i < key13.Length; i++)
            {
                key13[i] = key5[i];
            }

            for (int i = 0; i < key14.Length; i++)
            {
                key14[i] = key6[i];
            }

            for (int i = 0; i < key15.Length; i++)
            {
                key15[i] = key7[i];
            }

            for (int i = 0; i < key16.Length; i++)
            {
                key16[i] = key8[i];
            }

            for (int i = 0; i < key17.Length; i++)
            {
                key17[i] = key1[i];
            }

            for (int i = 0; i < key18.Length; i++)
            {
                key18[i] = key2[i];
            }

            for (int i = 0; i < key19.Length; i++)
            {
                key19[i] = key3[i];
            }

            for (int i = 0; i < key20.Length; i++)
            {
                key20[i] = key4[i];
            }

            for (int i = 0; i < key21.Length; i++)
            {
                key21[i] = key5[i];
            }

            for (int i = 0; i < key22.Length; i++)
            {
                key22[i] = key6[i];
            }

            for (int i = 0; i < key23.Length; i++)
            {
                key23[i] = key7[i];
            }

            for (int i = 0; i < key24.Length; i++)
            {
                key24[i] = key8[i];
            }

            for (int i = 0; i < key25.Length; i++)
            {
                key25[i] = key8[i];
            }

            for (int i = 0; i < key26.Length; i++)
            {
                key26[i] = key7[i];
            }

            for (int i = 0; i < key27.Length; i++)
            {
                key27[i] = key6[i];
            }

            for (int i = 0; i < key28.Length; i++)
            {
                key28[i] = key5[i];
            }

            for (int i = 0; i < key29.Length; i++)
            {
                key29[i] = key4[i];
            }

            for (int i = 0; i < key30.Length; i++)
            {
                key30[i] = key3[i];
            }

            for (int i = 0; i < key31.Length; i++)
            {
                key31[i] = key2[i];
            }

            for (int i = 0; i < key32.Length; i++)
            {
                key32[i] = key1[i];
            }
        }

        // Делим исходное сообщение на правую и левую части
        private static void DividingMessage()
        {
            for (int i = 0; i < L.Length; i++)
            {
                L[i] = message[i];
            }

            for (int i = 0; i < R.Length; i++)
            {
                R[i] = message[i + L.Length];
            }
        }

        // Ксор
        private static Int16 XOR (Int16 a, Int16 b)
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

        private static Int16[] GetSumbolAfterSblocks(Int16[] BL, int n)
        {
            byte[] sBlock1 = { 4, 10, 9, 2, 13, 8, 0, 14, 6, 11, 1, 12, 7, 15, 5, 3 };
            byte[] sBlock2 = { 14, 11, 4, 12, 6, 13, 15, 10, 2, 3, 8, 1, 0, 7, 5, 9 };
            byte[] sBlock3 = { 5, 8, 1, 13, 10, 3, 4, 2, 14, 15, 12, 7, 6, 0, 9, 11 };
            byte[] sBlock4 = { 7, 13, 10, 1, 0, 8, 9, 15, 14, 4, 6, 12, 11, 2, 5, 3 };
            byte[] sBlock5 = { 6, 12, 7, 1, 5, 15, 13, 8, 4, 10, 9, 14, 0, 3, 11, 2 };
            byte[] sBlock6 = { 4, 11, 10, 0, 7, 2, 1, 13, 3, 6, 8, 5, 9, 12, 15, 14 };
            byte[] sBlock7 = { 13, 11, 4, 1, 3, 15, 5, 9, 0, 10, 14, 7, 6, 8, 2, 12 };
            byte[] sBlock8 = { 1, 15, 13, 0, 5, 7, 10, 4, 9, 2, 3, 14, 6, 11, 8, 12 };

            byte answer = 0;
            for (int i = 0; i < BL.Length; i++)
            {
                answer += Convert.ToByte(BL[i] * Math.Pow(2, i));
            }

            byte sumbol = 0;

            switch(n)
            {
                case 0:
                    for (int i = 0; i < sBlock1.Length; i++)
                    {
                        if (answer == sBlock1[i]) { sumbol = sBlock1[i]; }
                    }   break;
                case 1:
                    for (int i = 0; i < sBlock2.Length; i++)
                    {
                        if (answer == sBlock2[i]) { sumbol = sBlock2[i]; }
                    }   break;
                case 2:
                    for (int i = 0; i < sBlock3.Length; i++)
                    {
                        if (answer == sBlock3[i]) { sumbol = sBlock3[i]; }
                    }   break;
                case 3:
                    for (int i = 0; i < sBlock4.Length; i++)
                    {
                        if (answer == sBlock4[i]) { sumbol = sBlock4[i]; }
                    }   break;
                case 4:
                    for (int i = 0; i < sBlock5.Length; i++)
                    {
                        if (answer == sBlock5[i]) { sumbol = sBlock5[i]; }
                    }   break;
                case 5:
                    for (int i = 0; i < sBlock6.Length; i++)
                    {
                        if (answer == sBlock6[i]) { sumbol = sBlock6[i]; }
                    }   break;
                case 6:
                    for (int i = 0; i < sBlock7.Length; i++)
                    {
                        if (answer == sBlock7[i]) { sumbol = sBlock7[i]; }
                    }   break;
                case 7:
                    for (int i = 0; i < sBlock8.Length; i++)
                    {
                        if (answer == sBlock8[i]) { sumbol = sBlock8[i]; }
                    }   break;
            }

            Int16[] res = new Int16[4];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = Convert.ToInt16(sumbol % 2);
                sumbol /= 2;
            }

            return res;
        }


        // Сложение по модулю 2^32
        public static Int16[] AddingAsModule32(Int16[] A, Int16[] K)
        {
            Int16[] ans = new Int16[A.Length];
            int buf = 0;

            for (int i = 0; i < A.Length; i++)
            {
                int j = A[i] + K[i] + buf;

                switch (j)
                {
                    case 0: ans[i] = 0;
                        break;
                    case 1: ans[i] = 1;
                        break;
                    case 2: ans[i] = 1;
                        buf = 0;
                        break;
                    case 3: ans[i] = 1;
                        buf = 1;
                        break;
                }
            }

            Int16[] BL = new Int16[4];
            Int16[] newBL = new Int16[4];
            Int16[] res = new Int16[A.Length];  // Строка после применения с-блоков

            for (int j = 0; j < 8; j++)
            {
                // Берем текущую 4 ку значений
                for (int i = 0; i < BL.Length; i++)
                {
                    BL[i] = ans[i + j * 4];
                }

                // Находим новое значение по с-блокам
                newBL = GetSumbolAfterSblocks(BL, j);

                for (int i = 0; i < newBL.Length; i++)
                {
                    res[j * 4 + i] = newBL[i];
                }
            }

            // Циклический сдвиг вправо (к старшему биту) на 11
            for (int i = res.Length - 11 - 1; i >= 0; i--)
            {
                res[i + 11] = res[i];
            }

            for (int i = 0; i < 11; i++)
            {
                res[i] = 0;
            }

            return res;
        }

        private static void Rounds(int n)
        {

            Int16[] func = { };

            switch (n)
            {
                case 1:
                    func = AddingAsModule32(L, key1);
                    break;
                case 2:
                    func = AddingAsModule32(L, key2);
                    break;
                case 3:
                    func = AddingAsModule32(L, key3);
                    break;
                case 4:
                    func = AddingAsModule32(L, key4);
                    break;
                case 5:
                    func = AddingAsModule32(L, key5);
                    break;
                case 6:
                    func = AddingAsModule32(L, key6);
                    break;
                case 7:
                    func = AddingAsModule32(L, key7);
                    break;
                case 8:
                    func = AddingAsModule32(L, key8);
                    break;
                case 9:
                    func = AddingAsModule32(L, key9);
                    break;
                case 10:
                    func = AddingAsModule32(L, key10);
                    break;
                case 11:
                    func = AddingAsModule32(L, key11);
                    break;
                case 12:
                    func = AddingAsModule32(L, key12);
                    break;
                case 13:
                    func = AddingAsModule32(L, key13);
                    break;
                case 14:
                    func = AddingAsModule32(L, key14);
                    break;
                case 15:
                    func = AddingAsModule32(L, key15);
                    break;
                case 16:
                    func = AddingAsModule32(L, key16);
                    break;
                case 17:
                    func = AddingAsModule32(L, key17);
                    break;
                case 18:
                    func = AddingAsModule32(L, key18);
                    break;
                case 19:
                    func = AddingAsModule32(L, key19);
                    break;
                case 20:
                    func = AddingAsModule32(L, key20);
                    break;
                case 21:
                    func = AddingAsModule32(L, key21);
                    break;
                case 22:
                    func = AddingAsModule32(L, key22);
                    break;
                case 23:
                    func = AddingAsModule32(L, key23);
                    break;
                case 24:
                    func = AddingAsModule32(L, key24);
                    break;
                case 25:
                    func = AddingAsModule32(L, key25);
                    break;
                case 26:
                    func = AddingAsModule32(L, key26);
                    break;
                case 27:
                    func = AddingAsModule32(L, key27);
                    break;
                case 28:
                    func = AddingAsModule32(L, key28);
                    break;
                case 29:
                    func = AddingAsModule32(L, key29);
                    break;
                case 30:
                    func = AddingAsModule32(L, key30);
                    break;
                case 31:
                    func = AddingAsModule32(L, key31);
                    break;
                case 32:
                    func = AddingAsModule32(L, key32);
                    break;
            }

            Int16[] buf = new Int16[L.Length];

            for (int i = 0; i < L.Length; i++)
            {
                buf[i] = XOR(R[i], func[i]);
            }

            for (int i = 0; i < L.Length; i++)
            {
                R[i] = L[i];
                L[i] = buf[i];
            }
        }

        public static Int16[] GetEncription()
        {
            GetSubkeys();
            DividingMessage();

            for (int i = 0; i < 32; i++)
            {
                Rounds(i + 1);
            }

            Int16[] ans = new Int16[2 * L.Length];
            for (int i = 0; i < L.Length; i++)
            {
                ans[i] = L[i];
                ans[i + L.Length] = R[i];
            }

            return ans;
        }
    }
}
