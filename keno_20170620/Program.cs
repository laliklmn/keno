using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keno_20170616

{
    class Program
    {
        static int szamolo_2(int[,] sorsolasok, int sorszamolo, int oszlopszamolo_egyik, int oszlopszamolo_masik, int lotto_number_first, int lotto_number_second, int talal)
        {

            if (sorsolasok[sorszamolo, oszlopszamolo_egyik] == lotto_number_first)
            {

                talal = szamolo(sorsolasok, sorszamolo, oszlopszamolo_masik, lotto_number_second, talal);
            }
            else
            {
                if (sorsolasok[sorszamolo, oszlopszamolo_egyik] == lotto_number_second)
                {
                    talal = szamolo(sorsolasok, sorszamolo, oszlopszamolo_masik, lotto_number_first, talal);
                }
            }
            return talal;
        }

        static int szamolo(int[,] sorsolasok, int sorszamolo, int oszlopszamolo, int lotto_number, int talal)
        {
            talal++;
            if (sorsolasok[sorszamolo, (oszlopszamolo)] == lotto_number)
            {
                talal++;
            }
            return talal;
        }

        static int Find_2(int[,] sorsolasok, int sorszamolo, int oszlopszamolo_egyik, int oszlopszamolo_masik, int oszlopszamolo_harmadik, int lotto_number_first, int lotto_number_second, int lotto_number_third, int talal)
        {
            if (sorsolasok[sorszamolo, (oszlopszamolo_egyik)] == lotto_number_second)
            {
                talal++;
                talal = szamolo_2(sorsolasok, sorszamolo, oszlopszamolo_masik, oszlopszamolo_harmadik, lotto_number_first, lotto_number_third, talal);
            }
            else
            {
                if (sorsolasok[sorszamolo, (oszlopszamolo_egyik)] == lotto_number_third)
                {
                    talal++;
                    talal = szamolo_2(sorsolasok, sorszamolo, oszlopszamolo_masik, oszlopszamolo_harmadik, lotto_number_first, lotto_number_second, talal);
                }
            }
            return talal;
        }

        static int Find_3(int[,] sorsolasok, int sorszamolo, int oszlopszamoloharmas_egyik, int oszlopszamoloharmas_masik, int oszlopszamoloharmas_harmadik, int harmas_a, int harmas_b, int harmas_c, int talal3)
        {
            if (sorsolasok[sorszamolo, (oszlopszamoloharmas_egyik)] == harmas_a)
            {
                talal3++;
                talal3 = szamolo_2(sorsolasok, sorszamolo, oszlopszamoloharmas_masik, oszlopszamoloharmas_harmadik, harmas_b, harmas_c, talal3);
            }
            else
            {
                talal3 = Find_2(sorsolasok, sorszamolo, oszlopszamoloharmas_egyik, oszlopszamoloharmas_masik, oszlopszamoloharmas_harmadik, harmas_a, harmas_b, harmas_c, talal3);
            }
            return talal3;
        }

        static int Find_4(int[,] sorsolasok, int sorszamolo, int oszlopszamolonegyes_egyik, int oszlopszamolonegyes_masik, int oszlopszamolonegyes_harmadik, int oszlopszamolonegyes_negyedik, int negyes_a, int negyes_b, int negyes_c, int negyes_d, int talal4)
        {
            if (sorsolasok[sorszamolo, (oszlopszamolonegyes_egyik)] == negyes_a)
            {
                talal4++;
                talal4 = Find_3(sorsolasok, sorszamolo, oszlopszamolonegyes_masik, oszlopszamolonegyes_harmadik, oszlopszamolonegyes_negyedik, negyes_b, negyes_c, negyes_d, talal4);

            }
            else
            {
                if (sorsolasok[sorszamolo, (oszlopszamolonegyes_egyik)] == negyes_b)
                {
                    talal4++;
                    talal4 = Find_3(sorsolasok, sorszamolo, oszlopszamolonegyes_masik, oszlopszamolonegyes_harmadik, oszlopszamolonegyes_negyedik, negyes_a, negyes_c, negyes_d, talal4);
                }
                else
                {
                    if (sorsolasok[sorszamolo, (oszlopszamolonegyes_egyik)] == negyes_c)
                    {
                        talal4++;
                        talal4 = Find_3(sorsolasok, sorszamolo, oszlopszamolonegyes_masik, oszlopszamolonegyes_harmadik, oszlopszamolonegyes_negyedik, negyes_b, negyes_a, negyes_d, talal4);

                    }
                    else
                    {
                        if (sorsolasok[sorszamolo, (oszlopszamolonegyes_egyik)] == negyes_d)
                        {
                            talal4++;
                            talal4 = Find_3(sorsolasok, sorszamolo, oszlopszamolonegyes_masik, oszlopszamolonegyes_harmadik, oszlopszamolonegyes_negyedik, negyes_b, negyes_c, negyes_a, talal4);
                        }
                    }
                }
            }
            return talal4;
        }

        static int Find_5(int[,] sorsolasok, int sorszamolo, int oszlopszamolootos_egyik, int oszlopszamolootos_masik, int oszlopszamolootos_harmadik, int oszlopszamolootos_negyedik, int oszlopszamolootos_otodik, int otos_a, int otos_b, int otos_c, int otos_d, int otos_e, int talal5)
        {

            if (sorsolasok[sorszamolo, (oszlopszamolootos_egyik)] == otos_a)
            {
                talal5++;
                talal5 = Find_4(sorsolasok, sorszamolo, oszlopszamolootos_masik, oszlopszamolootos_harmadik, oszlopszamolootos_negyedik, oszlopszamolootos_otodik, otos_b, otos_c, otos_d, otos_e, talal5);

            }
            else // masodik
                 //------------------------------------------------------------------------------------------------------------------------------------------------------------
            {
                if (sorsolasok[sorszamolo, (oszlopszamolootos_egyik)] == otos_b)
                {
                    talal5++;
                    talal5 = Find_4(sorsolasok, sorszamolo, oszlopszamolootos_masik, oszlopszamolootos_harmadik, oszlopszamolootos_negyedik, oszlopszamolootos_otodik, otos_a, otos_c, otos_d, otos_e, talal5);
                }
                else //harmadik	
                     //---------------------------------------------------------------------------------------------------------------------------------------
                {
                    if (sorsolasok[sorszamolo, (oszlopszamolootos_egyik)] == otos_c)
                    {
                        talal5++;
                        talal5 = Find_4(sorsolasok, sorszamolo, oszlopszamolootos_masik, oszlopszamolootos_harmadik, oszlopszamolootos_negyedik, oszlopszamolootos_otodik, otos_c, otos_b, otos_d, otos_e, talal5);
                    }
                    else //negyedik
                         //-----------------------------------------------------------------------------------------------------------------------------------------------------
                    {
                        if (sorsolasok[sorszamolo, (oszlopszamolootos_egyik)] == otos_d)
                        {
                            talal5++;
                            talal5 = Find_4(sorsolasok, sorszamolo, oszlopszamolootos_masik, oszlopszamolootos_harmadik, oszlopszamolootos_negyedik, oszlopszamolootos_otodik, otos_a, otos_b, otos_c, otos_e, talal5);
                        }
                        else //ötödik
                             //--------------------------------------------------------------------------------------------------------------------------------------------------------
                        {
                            if (sorsolasok[sorszamolo, (oszlopszamolootos_egyik)] == otos_e)
                            {
                                talal5++;
                                talal5 = Find_4(sorsolasok, sorszamolo, oszlopszamolootos_masik, oszlopszamolootos_harmadik, oszlopszamolootos_negyedik, oszlopszamolootos_otodik, otos_a, otos_b, otos_c, otos_d, talal5);
                            }
                        }
                    }
                }
            }
            return talal5;
        }


        static void Main(string[] args)
        {
            int sorok = 0;

            Console.WriteLine("Az adatok beolvasásához nyomj le egy billentyűt!");
            Console.ReadKey();
            StreamReader f = new StreamReader("keno.csv");
            int[] kenoszamok = new int[80];
            int[] kenoszamok_nagyobb = new int[80];


            Console.WriteLine("A keno.csv beolvasása elkezdődött....");
            while (!f.EndOfStream)
            {
                string[] adatok_keno = f.ReadLine().Split(';');
                sorok = sorok + 1;
                for (int i = 4; i <= 23; i++)
                {
                    kenoszamok[Convert.ToInt32(adatok_keno[i]) - 1]++;
                }

            }
            f.Close();
            Console.WriteLine("A keno.csv beolvasása folyamatban...");
            int[,] sorsolasok = new int[sorok, 20];
            int ss, so;
            ss = 0;
            StreamReader f_sorsolas = new StreamReader("keno.csv");
            while (!f_sorsolas.EndOfStream)
            {
                string[] adatok_sorsolas = f_sorsolas.ReadLine().Split(';');
                so = 0;
                for (int i_feltolt = 4; i_feltolt <= 23; i_feltolt++)
                {
                    sorsolasok[ss, so] = Convert.ToInt32(adatok_sorsolas[i_feltolt]);
                    so++;
                }
                ss++;
            }
            f_sorsolas.Close();
            Console.WriteLine("A keno.csv beolvasása elkészült...");
            Console.WriteLine("A nyerőszámokat kimásolom ....");
            string filenev = "keno_szam_sorolasok_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
            Console.WriteLine("A " + filenev + " létrehozása....");
            StreamWriter f2_sorsolas = new StreamWriter(filenev, false);
            f2_sorsolas.WriteLine("A kenó nyerőszámai (" + sorok + " sorsolás adatai alapján):");

            for (int sorkiir = 0; sorkiir < sorok; sorkiir++)
            {
                for (int oszlopkiir = 0; oszlopkiir < 20; oszlopkiir++)
                {
                    f2_sorsolas.Write(sorsolasok[sorkiir, oszlopkiir] + ";");
                }
                f2_sorsolas.WriteLine();
                f2_sorsolas.Flush();
            }
            f2_sorsolas.WriteLine();
            f2_sorsolas.Close();
            Console.WriteLine("Az eddig kihúzott kenó számokat a " + filenev + "-ben találod.");

            Console.WriteLine("Megszámolom, hogy az egyes kenó számokat eddig mennyiszer húzták ki....");
            for (int kk = 0; kk < 80; kk++)
            {
                kenoszamok_nagyobb[kk] = kenoszamok[kk];
            }

            filenev = "keno_szam_gyakorisag_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
            Console.WriteLine("A " + filenev + " létrehozása....");
            StreamWriter f2keno = new StreamWriter(filenev, false);
            Console.WriteLine();
            f2keno.WriteLine();
            f2keno.WriteLine("A kenó számai előforulás szerint rendezve, csökkenő sorrenben (" + sorok + " sorsolás adatai alapján):");
            f2keno.WriteLine();
            int[] maxi_szamok = new int[80];
            int[] maxi_szamok_db = new int[80];
            for (int i = 0; i < 80; i++)
            {
                int maxi_index = 0; //maximum kiválasztáshoz, ez jelöli,hogy a tömbben, mi az indexe a leggyakoribb számnak
                for (int j = 0; j < 80; j++)
                {
                    if (kenoszamok_nagyobb[maxi_index] < kenoszamok_nagyobb[j])
                    {
                        maxi_index = j;
                    }
                }
                maxi_szamok[i] = maxi_index + 1;
                maxi_szamok_db[i] = kenoszamok_nagyobb[maxi_index];
                f2keno.WriteLine("[ " + (i + 1) + ". szám: " + maxi_szamok[i] + " (" + maxi_szamok_db[i] + " előfordulás) ] " /*+ minimax*/);
                f2keno.Flush();
                kenoszamok_nagyobb[maxi_index] = 0;
            }
            Console.WriteLine("A kenó számai előforulás szerint rendezve, csökkenő sorrendben.");
            Console.WriteLine(" A listát a " + filenev + "-ben találod.");
            f2keno.WriteLine();
            f2keno.Close();

            Console.WriteLine("Megszámolom, a kettes kombinációkat eddig mennyiszer húzták ki....");
            filenev = "keno_szamok_(2)_kettesevel_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";

            int talal2 = 0;
            int db_kettes = 0;
            string chk_row;
            List<string> CheckList = new List<string>();
            List<string> CountedList = new List<string>();
            bool result;

            bool[,] check_2 = new bool[80, 81];
            
                for (int check_2_1 = 0; check_2_1 < 80; check_2_1++)
                {
                    for (int check_2_2 = 0; check_2_2 < 81; check_2_2++)
                    {
                        check_2[check_2_1, check_2_2] = false;
                    }
                }
            

            for (int RowCounterOut = 0; RowCounterOut < sorok; RowCounterOut++)
            {
                Console.WriteLine("kenó 2: " + RowCounterOut + " / " + sorok);

                for (int ColumnCounterOut_1 = 0; ColumnCounterOut_1 < 19; ColumnCounterOut_1++)
                {
                    for (int ColumnCounterOut_2 = (ColumnCounterOut_1+1); ColumnCounterOut_2 < 20; ColumnCounterOut_2++)
                    {
                       

                        if (check_2[sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2]] == false)
                        {
                            check_2[sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2]] = true;
                            db_kettes = 0;
                                for (int RowCounterIn = (RowCounterOut + 1); RowCounterIn < sorok; RowCounterIn++)
                                {
                                    for (int ColumnCounterIn_1 = 0; ColumnCounterIn_1 < 19; ColumnCounterIn_1++)
                                    {
                                        for (int ColumnCounterIn_2 = (ColumnCounterIn_1 + 1); ColumnCounterIn_2 < 20; ColumnCounterIn_2++)
                                        {
                                            talal2 = 0;
                                            talal2 = szamolo_2(sorsolasok, RowCounterIn, ColumnCounterIn_1, ColumnCounterIn_2, sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2], talal2);
                                            if (talal2 == 2)
                                            {
                                                db_kettes++;
                                            }
                                        }
                                    }
                                }


                                if (db_kettes > 0)
                                {
                                CountedList.Add("kenó számok kettesével: ;" + sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2] + "; előfordulás ;" + db_kettes);
                                       db_kettes = 0;
                                }
                         }
                    }
                }
            }
            CheckList.Clear();
            
            Console.WriteLine("A " + filenev + " létrehozása....");
            StreamWriter f_keno_kettes = new StreamWriter(filenev, false);
            for (int i = 0; i < CountedList.Count; i++)
            {
                f_keno_kettes.WriteLine(CountedList[i]);
            }            
            f_keno_kettes.Close();
            CountedList.Clear();
            Console.WriteLine("A kettes kombinációkat megszámoltam.");
            Console.WriteLine("A listát a " + filenev + "-ben találod.");
            Console.WriteLine();


            Console.WriteLine("Megszámolom, a 3-as kombinációkat eddig mennyiszer húzták ki....");
            filenev = "keno_szamok_(3)_harmasaval_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";

            bool[,,] check_3 = new bool[79,80,81];
            for (int check_3_1 = 0; check_3_1 < 79; check_3_1++)
            {
                for (int check_3_2 = 0; check_3_2 < 80; check_3_2++)
                {
                    for (int check_3_3 = 0; check_3_3 < 81; check_3_3++)
                    {
                        check_3[check_3_1, check_3_2, check_3_3] = false;
                    }
                }
            }

            
            //StreamWriter f_keno_harmas_log = new StreamWriter("keno_3_log.txt", false);
            int talal3 = 0;
            int db_harmas = 0;
            for (int RowCounterOut = 0; RowCounterOut < sorok; RowCounterOut++)
            {
                Console.WriteLine("kenó 3: " + RowCounterOut + " / " + sorok);
                for (int ColumnCounterOut_1 = 0; ColumnCounterOut_1 < 18; ColumnCounterOut_1++)
                {
                    for (int ColumnCounterOut_2 = (ColumnCounterOut_1 + 1); ColumnCounterOut_2 < 19; ColumnCounterOut_2++)
                    {
                        for (int ColumnCounterOut_3 = (ColumnCounterOut_2 + 1); ColumnCounterOut_3 < 20; ColumnCounterOut_3++)
                        {
                            //f_keno_harmas_log.WriteLine(RowCounterOut + ";" + ColumnCounterOut_1 + ";" + ColumnCounterOut_2 + ";" + ColumnCounterOut_3);
                            //f_keno_harmas_log.Flush();

                           
                           if (check_3[sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2], sorsolasok[RowCounterOut, ColumnCounterOut_3]] == false)
                            {

                             
                                check_3[sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2], sorsolasok[RowCounterOut, ColumnCounterOut_3]] = true;

                                for (int RowCounterIn = (RowCounterOut + 1); RowCounterIn < sorok; RowCounterIn++)
                                {
                                    //Console.WriteLine("kenó 3: " + RowCounterIn + " / " + RowCounterOut);
                                    for (int ColumnCounterIn_1 = 0; ColumnCounterIn_1 < 18; ColumnCounterIn_1++)
                                    {
                                        for (int ColumnCounterIn_2 = (ColumnCounterIn_1 + 1); ColumnCounterIn_2 < 19; ColumnCounterIn_2++)
                                        {
                                            for (int ColumnCounterIn_3 = (ColumnCounterIn_2 + 1); ColumnCounterIn_3 < 20; ColumnCounterIn_3++)
                                            {
                                                talal3 = 0;
                                                talal3 = Find_3(sorsolasok, RowCounterIn, ColumnCounterIn_1, ColumnCounterIn_2, ColumnCounterIn_3, sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2], sorsolasok[RowCounterOut, ColumnCounterOut_3], talal3);
                                                if (talal3 == 3)
                                                {
                                                    db_harmas++;
                                                }
                                            }
                                        }
                                    }
                                }
                                if (db_harmas > 0)
                                {
                                    CountedList.Add("kenó számok hármasával: ;" + sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_3] + "; előfordulás ;" + db_harmas);                               
                                    db_harmas = 0;
                                }
                            }
                        }
                    }
                }
            }
            CheckList.Clear();
            Console.WriteLine("A " + filenev + " létrehozása....");
            StreamWriter f_keno_harmas = new StreamWriter(filenev, false);

            for (int i = 0; i < CountedList.Count; i++)
            {
                f_keno_harmas.WriteLine(CountedList[i]);
            }
            
            f_keno_harmas.Close();
            CountedList.Clear();
            Console.WriteLine("A hármas kombinációkat megszámoltam.");
            Console.WriteLine("A listát a " + filenev + "-ben találod.");
            Console.WriteLine();

            Console.WriteLine("Megszámolom, a 4-es kombinációkat eddig mennyiszer húzták ki....");
            filenev = "keno_szamok_(4)_negyesevel_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";       
            //StreamWriter f_keno_negyes_log = new StreamWriter("keno_4_log.txt", false);
            int talal4 = 0;
            int db_negyes = 0;
            for (int RowCounterOut = 0; RowCounterOut < sorok; RowCounterOut++)
            {
                Console.WriteLine("kenó 4: " + RowCounterOut + " / " + sorok);
                for (int ColumnCounterOut_1 = 0; ColumnCounterOut_1 < 17; ColumnCounterOut_1++)
                {
                    for (int ColumnCounterOut_2 = (ColumnCounterOut_1 + 1); ColumnCounterOut_2 < 18; ColumnCounterOut_2++)
                    {
                        for (int ColumnCounterOut_3 = (ColumnCounterOut_2 + 1); ColumnCounterOut_3 < 19; ColumnCounterOut_3++)
                        {
                            for (int ColumnCounterOut_4 = (ColumnCounterOut_3 + 1); ColumnCounterOut_4 < 20; ColumnCounterOut_4++)
                            {

                                chk_row = sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_3] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_4];
                                if (!(result = CheckList.Contains(chk_row)))
                                {
                                    CheckList.Add(chk_row);
                                    for (int RowCounterIn = (RowCounterOut + 1); RowCounterIn < sorok; RowCounterIn++)
                                    {
                                        //Console.WriteLine("kenó 4: " + RowCounterIn + " / " + RowCounterOut);
                                        for (int ColumnCounterIn_1 = 0; ColumnCounterIn_1 < 17; ColumnCounterIn_1++)
                                        {
                                            for (int ColumnCounterIn_2 = (ColumnCounterIn_1 + 1); ColumnCounterIn_2 < 18; ColumnCounterIn_2++)
                                            {
                                                for (int ColumnCounterIn_3 = (ColumnCounterIn_2 + 1); ColumnCounterIn_3 < 19; ColumnCounterIn_3++)
                                                {
                                                    for (int ColumnCounterIn_4 = (ColumnCounterIn_3 + 1); ColumnCounterIn_4 < 20; ColumnCounterIn_4++)
                                                    {
                                                        talal4 = 0;
                                                        talal4 = Find_4(sorsolasok, RowCounterIn, ColumnCounterIn_1, ColumnCounterIn_2, ColumnCounterIn_3, ColumnCounterIn_4, sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2], sorsolasok[RowCounterOut, ColumnCounterOut_3], sorsolasok[RowCounterOut, ColumnCounterOut_4], talal4);
                                                        if (talal4 == 4)
                                                        {
                                                            db_negyes++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (db_negyes > 0)
                                    {
                                        CountedList.Add("kenó számok négyesével: ;" + sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_3] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_4] + "; előfordulás ;" + db_negyes);
                                        db_negyes = 0;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            CheckList.Clear();
            Console.WriteLine("A " + filenev + " létrehozása....");
            StreamWriter f_keno_negyes = new StreamWriter(filenev, false);
            for (int i = 0; i < CountedList.Count; i++)
            {
                f_keno_negyes.WriteLine(CountedList[i]);
            }
            f_keno_negyes.Close();
            CountedList.Clear();
            Console.WriteLine("A négyes kombinációkat megszámoltam.");
            Console.WriteLine("A listát a " + filenev + "-ben találod.");
            Console.WriteLine();


            Console.WriteLine("Megszámolom, az 5-ös kombinációkat eddig mennyiszer húzták ki....");
            filenev = "keno_lotto_szamok_(5)_otosevel_" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + ".txt";
            int talal5 = 0;
            int db_otos = 0;
            for (int RowCounterOut = 0; RowCounterOut < sorok; RowCounterOut++)
            {
                Console.WriteLine("kenó 5: " + RowCounterOut + " / " + sorok);
                for (int ColumnCounterOut_1 = 0; ColumnCounterOut_1 < 16; ColumnCounterOut_1++)
                {
                    for (int ColumnCounterOut_2 = (ColumnCounterOut_1 + 1); ColumnCounterOut_2 < 17; ColumnCounterOut_2++)
                    {
                        for (int ColumnCounterOut_3 = (ColumnCounterOut_2 + 1); ColumnCounterOut_3 < 18; ColumnCounterOut_3++)
                        {
                            for (int ColumnCounterOut_4 = (ColumnCounterOut_3 + 1); ColumnCounterOut_4 < 19; ColumnCounterOut_4++)
                            {
                                for (int ColumnCounterOut_5 = (ColumnCounterOut_4 + 1); ColumnCounterOut_5 < 20; ColumnCounterOut_5++)
                                {
                                    chk_row = sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_3] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_4]+ ";" + sorsolasok[RowCounterOut, ColumnCounterOut_5];
                                    if (!(result = CheckList.Contains(chk_row)))
                                    {
                                        CheckList.Add(chk_row);
                                        for (int RowCounterIn = (RowCounterOut + 1); RowCounterIn < sorok; RowCounterIn++)
                                        {
                                            //Console.WriteLine("kenó 5: " + RowCounterIn + " / " + RowCounterOut);
                                            for (int ColumnCounterIn_1 = 0; ColumnCounterIn_1 < 16; ColumnCounterIn_1++)
                                            {
                                                for (int ColumnCounterIn_2 = (ColumnCounterIn_1 + 1); ColumnCounterIn_2 < 17; ColumnCounterIn_2++)
                                                {
                                                    for (int ColumnCounterIn_3 = (ColumnCounterIn_2 + 1); ColumnCounterIn_3 < 18; ColumnCounterIn_3++)
                                                    {
                                                        for (int ColumnCounterIn_4 = (ColumnCounterIn_3 + 1); ColumnCounterIn_4 < 19; ColumnCounterIn_4++)
                                                        {
                                                            for (int ColumnCounterIn_5 = (ColumnCounterIn_4 + 1); ColumnCounterIn_5 < 20; ColumnCounterIn_5++)
                                                            {
                                                                talal5 = 0;
                                                                talal5 = Find_5(sorsolasok, RowCounterIn, ColumnCounterIn_1, ColumnCounterIn_2, ColumnCounterIn_3, ColumnCounterIn_4, ColumnCounterIn_5, sorsolasok[RowCounterOut, ColumnCounterOut_1], sorsolasok[RowCounterOut, ColumnCounterOut_2], sorsolasok[RowCounterOut, ColumnCounterOut_3], sorsolasok[RowCounterOut, ColumnCounterOut_4], sorsolasok[RowCounterOut, ColumnCounterOut_5], talal5);
                                                                if (talal5 == 5)
                                                                {
                                                                    db_otos++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        if (db_otos > 0)
                                        {
                                            CountedList.Add("kenó számok ötösével: ;" + sorsolasok[RowCounterOut, ColumnCounterOut_1] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_2] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_3] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_4] + ";" + sorsolasok[RowCounterOut, ColumnCounterOut_5] + "; előfordulás ;" + db_otos);
                                            db_otos = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            CheckList.Clear();
            Console.WriteLine("A " + filenev + " létrehozása....");
            StreamWriter f_keno_otos = new StreamWriter(filenev, false);
            for (int i = 0; i < CountedList.Count; i++)
            {
                f_keno_otos.WriteLine(CountedList[i]);
            }

            f_keno_otos.Close();
            CountedList.Clear();
            Console.WriteLine("A kenó kombinációkat megszámoltam.");
            Console.WriteLine("A listát a " + filenev + "-ben találod.");
            Console.WriteLine();

            Console.WriteLine("A számolás vége! Sok szerencsét! A kilépéshez nyomj le egy billentyűt!");
            Console.ReadKey();
        }
    }
}

