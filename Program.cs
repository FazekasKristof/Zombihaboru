namespace Zombihaboru
{
    internal class Program
    {
        static Random r = new Random();
        static string[] NevekLetrehozasa(int db)
        {
            string[] nevekOsszes = {"Kristóf", "Ádám", "Bence", "Csaba", "Dávid", "Erik", "Ferenc", "Gábor", "Hunor", "István",
                                    "János", "Károly", "Levente", "Márk", "Norbert", "Péter", "Richárd", "Sándor", "Tamás",
                                    "Viktor", "Zoltán", "Anna", "Barbara", "Csilla", "Dóra", "Eszter", "Fanni", "Hanna",
                                    "Kata", "Lilla", "Zsófia" };
            string[] nevek = new string[db];
            for (int i = 0; i < db; i++)
            {
                int index = r.Next(0, nevekOsszes.Length);
                nevek[i] = nevekOsszes[index];
            }
            return nevek;
        }
        static void Kiir(string[] nevek)
        {
            foreach (var item in nevek)
            {
                Console.WriteLine(item + "");
            }
            Console.WriteLine();
        }
        static int[] EleteroBeallitasa(int lakossagSzama)
        {
            int[] eleterok = new int[lakossagSzama];
            for (int i = 0; i < lakossagSzama; i++)
            {
                eleterok[i] = 100;
            }
            return eleterok;
        }
        static int[] TamadoEroBeallitasa(int zombikSzama)
        {
            int[] tamadoEreje = new int[zombikSzama];
            for (int i = 0; i < zombikSzama; i++)
            {
                tamadoEreje[i] = r.Next(10, 25);
            }
            return tamadoEreje;
        }
        static void KiirSzamok(int[] tomb)
        {
            foreach (var item in tomb)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static bool VanEEloLakos(int[] eleterok)
        {
            foreach (int item in eleterok)
            {
                if (item > 0)
                {
                    return true;
                }
            }
            return false;
        }
        static bool VanEEloZombi(int[] zombikTamadoEreje)
        {
            foreach (int item in zombikTamadoEreje)
            {
                if (item > 0)
                {
                    return true;
                }
            }
            return false;
        }
        static void Jatek(int[] lakossagEletereje, int[] zombikTamadoEreje, string[] zombik)
        {
            int korokSzama = 1;
            while (VanEEloLakos(lakossagEletereje) && VanEEloZombi(zombikTamadoEreje))
            {
                Console.WriteLine($"--- {korokSzama}. kör ---");
                for (int i = 0; i < zombikTamadoEreje.Length; i++)
                {
                    int index = r.Next(0, lakossagEletereje.Length);
                    if (zombikTamadoEreje[i] > 0)
                    {
                        lakossagEletereje[index] -= 50;
                        Console.WriteLine($"{zombik[i]} 25 sebzést okoz az egyik lakosnak.");
                        zombikTamadoEreje[i] -= 5;
                    }
                }
                KiirSzamok(lakossagEletereje);
                KiirSzamok(zombikTamadoEreje);
                korokSzama++;
            }
            if (!VanEEloLakos(lakossagEletereje))
            {
                Console.WriteLine("Kihalt az összes lakos!");
            }
            else if (!VanEEloZombi(zombikTamadoEreje))
            {
                Console.WriteLine("Kihalt az összes zombi!");
            }
        }
        static void Main(string[] args)
        {
            int lakossagSzama = 5;
            int zombikSzama = 3;
            string[] lakossag = NevekLetrehozasa(lakossagSzama);
            string[] zombik = NevekLetrehozasa(zombikSzama);
            Console.Write("Lakosság: ");
            Kiir(lakossag);
            Console.Write("Zombik: ");
            Kiir(zombik);
            int[] lakossagEletereje = EleteroBeallitasa(lakossagSzama);
            int[] zombikTamadoEreje = TamadoEroBeallitasa(zombikSzama);
            Console.Write("Lakosság eletereje: ");
            KiirSzamok(lakossagEletereje);
            Console.Write("Zombik támadó ereje: ");
            KiirSzamok(zombikTamadoEreje);
            Jatek(lakossagEletereje, zombikTamadoEreje, zombik);
        }
    }
}
