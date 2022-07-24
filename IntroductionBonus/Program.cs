using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionBonus
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //soru: birinci çarpan alınır.Basamak sayısı önemli değildir. ikinci çarpan alınır ancak iki ya da üç basamaklıdır. çarpma işlemindeki birinci hata normalde bir basamak kaydırıp yazdığımız çarpım burada kaydırılmaz. ikinci hata ise toplama işleminde elde sayısı göz ardı edilir. buna göre yanlış yapan bir çarpma işlemi dizayn edilir. 
            
            long sayi1, sayi2, dogruSonuc, sayi2yitut;
            bool sayi1Mi, sayi2Mi;
            string sayi2Uzunluk, birinciCarpimUzunluk, ikinciCarpimUzunluk, ucuncuCarpimUzunluk;
            long birinciCarpim = 0, ikinciCarpim = 0, ucuncuCarpim = 0;

            


            Console.WriteLine("*****Bu uygulama yanlış ve doğru çarpma işleminin sonucunu ekrana yazdırır*****");
            #region Sayı Al
            do
            {
                Console.Write("Lütfen birinci sayıyı giriniz");
                sayi1Mi = Int64.TryParse(Console.ReadLine(), out sayi1);
                if (!sayi1Mi)
                {
                    Console.WriteLine("Lütfen sayısal bir değer girişi yapınız");
                }
                else if (sayi1 < 10)
                {
                    Console.WriteLine("Lütfen en az iki basamaklı sayı girişi yapınız");
                }

            } while (!sayi1Mi || sayi1 < 10);


            do
            {
                Console.Write("Lütfen ikinci sayıyı giriniz");
                sayi2Mi = Int64.TryParse(Console.ReadLine(), out sayi2);
                if (!sayi2Mi)
                {
                    Console.WriteLine("Lütfen sayısal bir değer girişi yapınız");
                }
                else if (sayi2 < 10 || sayi2 > 999)
                {
                    Console.WriteLine("Girdiğiniz değer iki veya üç basamaklı olmalıdır");
                }

            } while (!sayi2Mi || sayi2 < 10 || sayi2 > 999);
            sayi2yitut = sayi2;
            sayi2Uzunluk = sayi2.ToString();
            long[] basamaklarSayi2 = new long[sayi2Uzunluk.Length];

            dogruSonuc = sayi1 * sayi2;
            #endregion


            #region Sayı 2'nin basamaklarını diziye al
            for (long i = sayi2Uzunluk.Length - 1; i >= 0; i--)
            {
                basamaklarSayi2[i] = sayi2 % 10;
                sayi2 = sayi2 / 10;
            }
            #endregion


            #region Sayı2'nin basamaklarını sayı1 ile çarp
            if (sayi2yitut > 9 && sayi2yitut < 100)
            {
                birinciCarpim = sayi1 * basamaklarSayi2[basamaklarSayi2.Length - 1];
                ikinciCarpim = sayi1 * basamaklarSayi2[basamaklarSayi2.Length - 2];

            }

            else if (sayi2yitut > 99)
            {
                birinciCarpim = sayi1 * basamaklarSayi2[basamaklarSayi2.Length - 1];
                ikinciCarpim = sayi1 * basamaklarSayi2[basamaklarSayi2.Length - 2];
                ucuncuCarpim = sayi1 * basamaklarSayi2[basamaklarSayi2.Length - 3];

            }
            #endregion

            #region Çarpım sonuçlarından en uzununu bulmak
            birinciCarpimUzunluk = birinciCarpim.ToString();
            ikinciCarpimUzunluk = ikinciCarpim.ToString();
            ucuncuCarpimUzunluk = ucuncuCarpim.ToString();
            int maxUzunluk = 0;
            if (birinciCarpimUzunluk.Length >= ikinciCarpimUzunluk.Length && birinciCarpimUzunluk.Length >= ucuncuCarpimUzunluk.Length)
            {
                maxUzunluk = birinciCarpimUzunluk.Length;
            }
            else if (ikinciCarpimUzunluk.Length >= birinciCarpimUzunluk.Length && ikinciCarpimUzunluk.Length >= ucuncuCarpimUzunluk.Length)
            {
                maxUzunluk = ikinciCarpimUzunluk.Length;
            }
            else if (ucuncuCarpimUzunluk.Length >= ikinciCarpimUzunluk.Length && ucuncuCarpimUzunluk.Length >= ucuncuCarpimUzunluk.Length)
            {
                maxUzunluk = ucuncuCarpimUzunluk.Length;
            }
            #endregion


            #region En uzununa göre tüm dizileri eşitleyip sıfır atmak
            long[] birinciCarpimBasamaklar = new long[maxUzunluk];
            for (int i = 0; i < maxUzunluk; i++)
            {
                birinciCarpimBasamaklar[i] = 0;
            }
            long[] ikinciCarpimBasamaklar = new long[maxUzunluk];
            for (int i = 0; i < maxUzunluk; i++)
            {
                ikinciCarpimBasamaklar[i] = 0;
            }
            long[] ucuncuCarpimBasamaklar = new long[maxUzunluk];
            for (int i = 0; i < maxUzunluk; i++)
            {
                ucuncuCarpimBasamaklar[i] = 0;
            }

            #endregion

            #region Basamakları başında sıfırlı şekilde diziye at
            for (int i = birinciCarpimBasamaklar.Length - 1; i >= birinciCarpimBasamaklar.Length - birinciCarpimUzunluk.Length; i--)
            {
                birinciCarpimBasamaklar[i] = birinciCarpim % 10;
                birinciCarpim = birinciCarpim / 10;
            }
            for (int i = ikinciCarpimBasamaklar.Length - 1; i >= ikinciCarpimBasamaklar.Length - ikinciCarpimUzunluk.Length; i--)
            {
                ikinciCarpimBasamaklar[i] = ikinciCarpim % 10;
                ikinciCarpim = ikinciCarpim / 10;
            }
            for (int i = ucuncuCarpimBasamaklar.Length - 1; i >= ucuncuCarpimBasamaklar.Length - ucuncuCarpimUzunluk.Length; i--)
            {
                ucuncuCarpimBasamaklar[i] = ucuncuCarpim % 10;
                ucuncuCarpim = ucuncuCarpim / 10;
            }

            #endregion

            long[] toplamınBasamakları = new long[maxUzunluk];
            for (long i = 1, j = 0; j < maxUzunluk; i++, j++)
            {

                toplamınBasamakları[j] = birinciCarpimBasamaklar[birinciCarpimBasamaklar.Length - i] + ikinciCarpimBasamaklar[ikinciCarpimBasamaklar.Length - i] + ucuncuCarpimBasamaklar[ucuncuCarpimBasamaklar.Length - i];
                if (toplamınBasamakları[j] > 9)
                {
                    toplamınBasamakları[j] = toplamınBasamakları[j] % 10;
                }
            }

            Console.Write("Yanlış çarpma sonucu : ");
            for (int i = toplamınBasamakları.Length-1; i >= 0; i--)
            {
                Console.Write(toplamınBasamakları[i]);
            }

            
            Console.WriteLine($"\nDoğru sonuç : {dogruSonuc}");
            Console.ReadLine();



































            //if (sayi2yitut > 9 && sayi2yitut < 100)
            //{
            //    for (long i = 1, j = 0; i < maxUzunluk; i++, j++)
            //    {

            //        toplamınBasamakları[j] = birinciCarpimBasamaklar[birinciCarpimBasamaklar.Length - i] + ikinciCarpimBasamaklar[ikinciCarpimBasamaklar.Length - i];
            //        if (toplamınBasamakları[j] > 9)
            //        {
            //            toplamınBasamakları[j] = toplamınBasamakları[j] % 10;
            //        }
            //    }
            //}

            //else if (sayi2yitut > 99)
            //{

            //}






























        }
    }
}
