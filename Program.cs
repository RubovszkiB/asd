using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
   static List<Barlang> barlangok = new List<Barlang>();
    static void Main()
    {
        
        StreamReader sr = new StreamReader("barlangok.txt", Encoding.UTF8);

        // első sor a mezőneveket tartalmazza, ezt kihagyjuk
        sr.ReadLine();

        while (!sr.EndOfStream)
        {
            string sor = sr.ReadLine();
            barlangok.Add(new Barlang(sor));
        }

        sr.Close();

        Console.WriteLine($"4. feladat: A barlangok száma: {barlangok.Count}");
    }
    static void AtlagosMiskolciMelyseg(List<Barlang> barlangok)
    {
        double osszeg = 0;
        int db = 0;

        foreach (Barlang b in barlangok)
        {
            if (b.Telepules.StartsWith("Miskolc"))
            {
                osszeg += b.Melyseg;
                db++;
            }
        }

        double atlag = osszeg / db;
        Console.WriteLine($"5. feladat: A miskolci barlangok átlagos mélysége: {atlag:F3} m");
    }
    static void HetedikFeladat()
    {
        Dictionary<string,int> statisztika = new Dictionary<string,int>();
        foreach (Barlang b in barlangok)
        {
          if(!statisztika.ContainsKey(b.Vedettseg))
          {
            statisztika.Add(b.Vedettseg,1);
            
            }
          else 
                statisztika[b.Vedettseg]++;
        }
        Console.WriteLine("sTATAISZTIKA VEDETETTSEGI SITENKENT:");

    }
    static void hatosfeladat()
    {
        Console.Write("6. feladat: Kérek egy településnevet: ");
        string telepules = Console.ReadLine();
        int max = barlangok.Melyseg[0];


        for (int i = 0; i < barlangok.Count; i++)
        {
            if (barlangok.Melyseg[i]>max)
            {
                max = barlangok[i];
            }
        }
    }

}
