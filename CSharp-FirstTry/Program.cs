using System;
using System.Security;

namespace CSharp_Console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Startvariablen
            int player_input = 0;
            int player_try = 1;
            int secret = 0;
            int min_custom = 0;
            int max_custom = 0;
            int close_custom = 0;
            bool error = false;
            bool choice_level = false;

            // Schwierigkeitsgrad
            int level = -1;
            int[] min = new int[] { 0, 100, 1000, min_custom };
            int[] max = new int[] { 100, 1000, 10000, max_custom };
            int[] close = new int[] { 5, 10, 15, close_custom };

            // Auswahl Schwierigkeitsgrad
            while (choice_level != true)
            {
                try
                {
                    Console.WriteLine("Waehle einen Schwierigkeitsgrad:");
                    Console.WriteLine("0: Zahlen zwischen 0-100");
                    Console.WriteLine("1: Zahlen zwischen 100-1000");
                    Console.WriteLine("2: Zahlen zwischen 1000-10000");
                    Console.WriteLine("3: Eigener Bereich");
                    Console.WriteLine("Auswahl: ");

                    // Zusaetzliche Zeile nach Falscheingabe
                    if (error == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ungueltige Auswahl!");
                        Console.ResetColor();
                    }

                    // Cursorpositionierung
                    Console.SetCursorPosition(9, 5);
                    level = Convert.ToInt16(Console.ReadLine());

                    // Zufallszahl generieren
                    Random rnd = new Random();
                    secret = Convert.ToInt16(rnd.Next(min[level], max[level]));

                    // Zeilenversatz nach Fehler
                    if (error == true)
                    {
                        Console.SetCursorPosition(0, 7);
                    }
                    choice_level = true;
                }
                catch
                {
                    Console.Clear();
                    error = true;
                }

                // Konsolenfenster leeren
                Console.Clear();
            }

            //Eingabe und Prüfung
            while (player_input != secret)
            {
                Console.WriteLine(secret);

                try
                {
                    player_input = Convert.ToInt16(Console.ReadLine());
                }

                catch
                {
                    Console.WriteLine("Es sind nur Zahlen erlaubt.");
                    player_input = 0;
                }

                finally
                {
                    if (player_input < secret && player_input != 0)
                    {
                        if (player_input < secret - close[level])
                        {
                            Console.WriteLine("Zu niedrig.");
                            player_try += 1;
                        }
                        else
                        {
                            Console.WriteLine("Nah dran, aber leider zu niedrig.");
                            player_try += 1;
                        }
                    }
                    else if (player_input > secret && player_input != 0)
                    {
                        if (player_input > secret + close[level])
                        {
                            Console.WriteLine("Zu hoch");
                            player_try += 1;
                        }
                        else
                        {
                            Console.WriteLine("Nah dran, aber leider zu hoch.");
                            player_try += 1;
                        }
                    }
                    else if (player_input == secret)
                    {
                        Console.WriteLine("Super, du hast die gesuchte Zahl (" + secret + ") nach dem " + player_try + ". Versuch gefunden!");
                    }
                }
            }
        }
    }
}
