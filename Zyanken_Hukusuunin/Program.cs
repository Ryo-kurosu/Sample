﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zyanken_Taninzuu
{
    class inputhand
    {

        static void Main(string[] args)
        {
            Console.WriteLine("おい、俺たちとジャンケンしろよ。\n");
            Console.WriteLine("ジャンケンしてあげますか？");

            while (true)
            {
                Console.WriteLine("ジャンケンする：Yを入力");
                Console.WriteLine("もう帰る：Nを入力");

                string yn = Console.ReadLine();

                if (yn == "y" || yn == "Y" || yn == "yes" || yn == "YES")
                {
                    DefinitionInput();
                }
                else if (yn == "n" || yn == "N" || yn == "no" || yn == "NO")
                {
                    Console.WriteLine("\n帰りたいのを無理に引き留めるのは気が引けるから帰っていいよ\n");
                    Environment.Exit(0);   
                }
                else
                {
                    Console.WriteLine("\nYESかNOか聞かれたならYESかNOで答えろよ\n");
                }
            }
        }
        static void ArrayRegistration(ref int FriendNumber, int EnemyNumber, int TimesNumber)
        {
            //各プレイヤーの手を格納する配列。
            int[] IntFriend = new int[FriendNumber];
            int[] IntEnemy = new int[EnemyNumber];
            //N番目のプレイヤーが出した手をグー、チョキ、パーとして文字列で格納する配列。
            string[] StrFriend = new string[FriendNumber];
            string[] StrEnemy = new string[EnemyNumber];
            //各プレイヤーの勝敗数を格納する配列。
            int[] FriendWinCount = new int[FriendNumber];
            int[] Enemywincount = new int[EnemyNumber];
            int[] FriendLoseCount = new int[FriendNumber];
            int[] EnemyLoseCount = new int[EnemyNumber];
            //各プレイヤーの勝率を格納する配列。
            float[] FriendWinPercent = new float[FriendNumber];
            float[] EnemyWinPercent = new float[EnemyNumber];
            //各プレイヤーとCPUの出した手の数値を格納する配列。
            int[] IntAllHand = new int[FriendNumber + EnemyNumber];
            string[] StrAllHand = new string[FriendNumber + EnemyNumber];

            //TimesNumberで指定したKaisuになるまでジャンケンを行う
            for (int Kaisu = 0; Kaisu < TimesNumber; Kaisu++)
            {
                Console.WriteLine((Kaisu + 1) + "回戦\n");
                for (int i = 0; i < FriendNumber; i++)      //仲間全員の手が揃うまで選択
                {
                    Console.WriteLine("\n仲間" + (i + 1) + "の手を選択し、以下の数字で入力");
                    Console.WriteLine("1:グー　2:チョキ　3:パー");
                    IntFriend[i] = GetInt(ref i); //プレイヤーの入力した数値を格納する変数
                    StrFriend[i] = Convert(IntFriend[i]); //数値をグー、チョキ、パーの文字列に変換
                    IntAllHand[i] = IntFriend[i];
                    StrAllHand[i] = Convert(IntFriend[i]);
                }
                Random EnemyHand = new System.Random();
                for (int i = 0; i < EnemyNumber; i++)
                {
                    IntEnemy[i] = EnemyHand.Next(1, 4); //1～３の乱数を取得し敵の手とする。
                    StrEnemy[i] = Convert(IntEnemy[i]); //数値をグー、チョキ、パーの文字列に変換
                    IntAllHand[i + FriendNumber] = IntEnemy[i];
                    StrAllHand[i + FriendNumber] = Convert(IntEnemy[i]);
                }
                //それぞれのプレイヤーが出した手を表示
                for (int i = 0; i < FriendNumber; i++)
                {
                    Console.Write("\n仲間" + (i + 1) + ":" + StrAllHand[i] + " ");
                }
                for (int i = FriendNumber; i < FriendNumber + EnemyNumber; i++)
                {
                    Console.Write("\n　敵" + (i - FriendNumber + 1) + ":" + StrAllHand[i] + " ");
                }
                //それぞれの手を出したプレイヤー数をカウント
                int RockCount = 0;
                int ScissorsCount = 0;
                int PaperCount = 0;
                for (int i = 0; i < IntAllHand.Length; i++)
                {
                    switch (IntAllHand[i])
                    {
                        case 1:
                            RockCount += 1;
                            break;
                        case 2:
                            ScissorsCount += 1;
                            break;
                        case 3:
                            PaperCount += 1;
                            break;
                    }
                }
                //場がすべての手・グーのみ・チョキのみ・パーのみの時にそれぞれ真を返すbool
                bool AllPattern = (RockCount != 0 && ScissorsCount != 0 && PaperCount != 0); 
                bool AllRock = (ScissorsCount == 0 && PaperCount == 0); 
                bool AllScissors = (PaperCount == 0 && RockCount == 0); 
                bool AllPaper = (RockCount == 0 && ScissorsCount == 0); 

                while (AllPaper || AllRock || AllScissors || AllPattern) //↑のboolはすべてあいこになるパターン
                {
                    Console.WriteLine("\n\n>>>あいこだぜ!!<<<");
                    Console.WriteLine("あいこが出たのでもう一度↓\n");

                    //じゃんけんカウント初期化
                    RockCount = 0;
                    ScissorsCount = 0;
                    PaperCount = 0;

                    for (int i = 0; i < FriendNumber; i++)
                    {
                        Console.WriteLine("\n仲間" + (i + 1) + "の手を選択し、以下の数字で入力");
                        Console.WriteLine("1:グー　2:チョキ　3:パー");
                        IntFriend[i] = GetInt(ref i); //プレイヤーの入力した数値を格納する変数
                        StrFriend[i] = Convert(IntFriend[i]); //数値をグー、チョキ、パーの文字列に変換
                        IntAllHand[i] = IntFriend[i];
                        StrAllHand[i] = Convert(IntFriend[i]);
                    }
                    for (int i = 0; i < EnemyNumber; i++)
                    {
                        IntEnemy[i] = EnemyHand.Next(1, 4); 
                        StrEnemy[i] = Convert(IntEnemy[i]); 
                        IntAllHand[i + FriendNumber] = IntEnemy[i];
                        StrAllHand[i + FriendNumber] = Convert(IntEnemy[i]);
                    }
                    Console.WriteLine("\n\n");
                    for (int i = 0; i < IntAllHand.Length; i++)
                    {
                        switch (IntAllHand[i])
                        {
                            case 1:
                                RockCount += 1;
                                break;
                            case 2:
                                ScissorsCount += 1;
                                break;
                            case 3:
                                PaperCount += 1;
                                break;
                        }
                    }
                    //敵味方全員分の手を出力
                    for (int i = 0; i < FriendNumber; i++)
                    {
                        Console.Write("\n仲間" + (i + 1) + ":" + StrAllHand[i] + " ");
                    }
                    for (int i = FriendNumber; i < FriendNumber + EnemyNumber; i++)
                    {
                        Console.Write("\n　敵" + (i - FriendNumber + 1) + ":" + StrAllHand[i] + " ");
                    }
                    Console.WriteLine("\n");
                    AllPaper = (RockCount == 0 && ScissorsCount == 0);
                    AllRock = (ScissorsCount == 0 && PaperCount == 0);
                    AllScissors = (PaperCount == 0 && RockCount == 0);
                    AllPattern = (RockCount != 0 && ScissorsCount != 0 && PaperCount != 0);
                }

                //パーがいないときにはグーが勝つ
                if (PaperCount == 0)
                {
                    Console.WriteLine("\n\n＞＞＞グーの勝ちだぜ！！＜＜＜");
                    Console.WriteLine("\n勝者\n");
                    for (int i = 0; i < FriendNumber; i++)
                    {
                        if (IntFriend[i] == 1)
                        {
                            FriendWinCount[i] += 1;
                            Console.WriteLine("仲間" + (i + 1));
                        }
                        else
                        {
                            FriendLoseCount[i] += 1;
                        }
                    }
                    for (int i = 0; i < EnemyNumber; i++)
                    {
                        if (IntEnemy[i] == 1)
                        {
                            Enemywincount[i] += 1;
                            Console.WriteLine("　敵" + (i + 1));
                        }
                        else
                        {
                            EnemyLoseCount[i] += 1;
                        }
                    }
                    Console.WriteLine("\n--------------------------------------");
                }
                //グーが居ないときにはチョキが勝つ
                else if (RockCount == 0)
                {
                    Console.WriteLine("\n\n＞＞＞チョキの勝ちだぜ！！＜＜＜");
                    Console.WriteLine("\n勝者\n");
                    for (int i = 0; i < FriendNumber; i++)
                    {
                        if (IntFriend[i] == 2)
                        {
                            FriendWinCount[i] += 1;
                            Console.WriteLine("仲間" + (i + 1));
                        }
                        else
                        {
                            FriendLoseCount[i] += 1;
                        }
                    }
                    for (int i = 0; i < EnemyNumber; i++)
                    {
                        if (IntEnemy[i] == 2)
                        {
                            Enemywincount[i] += 1;
                            Console.WriteLine("　敵" + (i + 1));
                        }
                        else
                        {
                            EnemyLoseCount[i] += 1;
                        }
                    }
                    Console.WriteLine("\n--------------------------------------");
                }
                //チョキが居ない場合にはパーが勝つ
                else
                {
                    Console.WriteLine("\n\n＞＞＞パーの勝ちだぜ！！＜＜＜");
                    Console.WriteLine("\n勝者\n");
                    for (int i = 0; i < FriendNumber; i++)
                    {
                        if (IntFriend[i] == 3)
                        {
                            FriendWinCount[i] += 1;
                            Console.WriteLine("仲間" + (i + 1));
                        }
                        else
                        {
                            FriendLoseCount[i] += 1;
                        }
                    }
                    for (int i = 0; i < EnemyNumber; i++)
                    {
                        if (IntEnemy[i] == 3)
                        {
                            Enemywincount[i] += 1;
                            Console.WriteLine("　敵" + (i + 1));
                        }
                        else
                        {
                            EnemyLoseCount[i] += 1;
                        }
                    }
                    Console.WriteLine("\n--------------------------------------");
                }
            }
            //結果発表
            while (true)
            {
                Console.WriteLine("\n成績を見たいですか？");
                Console.WriteLine("Y:見たい　　N：興味ないね");
                string yn = Console.ReadLine();
                if (yn == "y" || yn == "Y" || yn == "yes" || yn == "YES")
                {
                    Console.WriteLine("「結果発表～～～～～～～～～～～～～～～～～～～～～～～」(cv.浜田雅功)\n");
                    for (int i = 0; i < FriendNumber; i++)
                    {
                        FriendWinPercent[i] = ((float)FriendWinCount[i] / (float)TimesNumber) * 100;
                        Console.Write("仲間" + (i + 1) + ":" + "勝ち:" + FriendWinCount[i] + "回" + ", " + "負け:" + FriendLoseCount[i] + "回" + ", " + "勝率:" + FriendWinPercent[i].ToString("f3") + "%\n");
                    }
                    for (int i = 0; i < EnemyNumber; i++)
                    {
                        EnemyWinPercent[i] = ((float)Enemywincount[i] / (float)TimesNumber) * 100;
                        Console.Write("　敵" + (i + 1) + ":" + "勝ち:" + Enemywincount[i] + "回" + ", " + "負け:" + EnemyLoseCount[i] + "回" + ", " + "勝率:" + EnemyWinPercent[i].ToString("f3") + "%\n");
                    }
                    
                    Console.WriteLine("\n\nもう一度遊びますか？\n");
                    break;
                }
                else if (yn == "n" || yn == "N" || yn == "no" || yn == "NO")
                {
                    Console.WriteLine("\n\nもう一度遊びますか？\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nYESかNOか聞かれたならYESかNOで答えろよ\n"); //入力が適正でない場合入力に戻る
                }
            }
        }
        static void DefinitionInput()
        {
            try
            {
                Console.WriteLine("\n仲間の数を入力してください");
                int FriendNumber = int.Parse(Console.ReadLine()); //プレイヤーの数を入力
                if (FriendNumber < 0)
                {
                    throw new InvalidOperationException();
                }
                Console.WriteLine("\n敵の数を入力してください（2人以上のみ）");
                int EnemyNumber = int.Parse(Console.ReadLine()); //CPUの数を入力
                if (EnemyNumber < 2)
                {
                    throw new InvalidOperationException();
                }
                Console.WriteLine("\n勝負回数を入力してください");
                int TimesNumber = int.Parse(Console.ReadLine()); //何回勝負にするか入力
                if (TimesNumber < 1)
                {
                    throw new InvalidOperationException();
                }
                Console.WriteLine("\n\n闇のゲームの始まりだ\n");
                ArrayRegistration(ref FriendNumber, EnemyNumber, TimesNumber);
            }
            catch (FormatException)
            {
                Console.Write("\n適切な値を入力してください\n");
                Console.Write("仲間人数の入力に戻ります\n");
                DefinitionInput();
            }
            catch (OverflowException)
            {
                Console.Write("\n適切な値を入力してください\n");
                Console.Write("仲間人数の入力に戻ります\n");
                DefinitionInput();
            }
            catch (InvalidOperationException)
            {
                Console.Write("\n適切な値を入力してください\n");
                Console.Write("仲間人数の入力に戻ります\n");
                DefinitionInput();
            }
        }
        static int GetInt(ref int x)
        {
            int i;
            while (true)
            {
                try
                {
                    i = int.Parse(Console.ReadLine());
                    if(i > 3)
                    {
                        throw new InvalidOperationException();
                    }
                    if(i < 1)
                    {
                        throw new InvalidOperationException();
                    }
                }
                catch (FormatException)
                {
                    Console.Write("\n正しい値を入力してください\n");
                    Console.WriteLine("1:グー　2:チョキ　3:パー");
                    continue ;
                }
                catch (OverflowException)
                {
                    Console.Write("\n正しい値を入力してください\n");
                    Console.WriteLine("1:グー　2:チョキ　3:パー");
                    continue ;
                }
                catch (InvalidOperationException)
                {
                    Console.Write("\n正しい値を入力してください\n");
                    Console.WriteLine("1:グー　2:チョキ　3:パー");
                    continue;
                }
                break;
            }
            return i;
        }
        static string Convert(int num) //入力した１～３の値をジャンケンの文字に変換
        {
            switch (num) 
            {
                case 1:
                    return "グー";
                case 2:
                    return "チョキ";
                case 3:
                    return "パー";
                default:
                    return "";
            }
        }
        /*文字列からの部分文字列の抽出を右から行います
           </summary>
           <param name="target" />対象の文字列
           <param name="length" />部分文字列の長さ
           <returns>文字列の右から抽出された部分文字列</returns> */
        static string SubstringRight(string target, int length)
        {
            return target.Substring(target.Length - length, length);
        }
    }
}