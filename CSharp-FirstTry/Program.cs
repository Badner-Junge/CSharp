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
            int secret = -1;
            int line = 3;
            int min_custom = 0;
            int max_custom = 0;
            int close_custom = 0;
            bool error = false;
            bool choice_level = false;

            // Schwierigkeitsgrad
            int level = 0;
            int[] min = new int[] { 0, 100, 1000, min_custom};
            int[] max = new int[] { 101, 1001, 10001, max_custom};
            int[] close = new int[] { 5, 10, 15, close_custom};

            //Eingabe und Prüfung
            while (player_input != secret)
            {
                // Auswahl Schwierigkeitsgrad
                while (choice_level != true)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("*********** Zahlenraten ***********");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("Waehle einen Schwierigkeitsgrad:");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("1");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Zahlen zwischen 0-100");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("2");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Zahlen zwischen 100-1000");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("3");
                        Console.ResetColor();
                        Console.WriteLine(": Zahlen zwischen 1000-10000");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("4");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Eigener Bereich");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("0");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(": Beenden");
                        Console.WriteLine("Auswahl: ");

                        // Zusaetzliche Zeile nach Falscheingabe
                        if (error == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("");
                            Console.WriteLine("Ungueltige Auswahl!");
                            Console.ResetColor();
                        }

                        // Cursorpositionierung nach Falscheingabe
                        Console.SetCursorPosition(9, 8);
                        level = Convert.ToInt16(Console.ReadLine()) - 1;

                        // Auswahl verarbeiten
                        switch (level)
                        {
                            // Beenden
                            case -1:
                                Environment.Exit(0);
                                break;

                            // Eigener Bereich
                            case 3:
                                Console.WriteLine("");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Kleinste Zahl: ");
                                min[level] = Convert.ToInt16(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Groesste Zahl: ");
                                max[level] = Convert.ToInt16(Console.ReadLine()) + 1;
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Nah dran bei: ");
                                close[level] = Convert.ToInt16(Console.ReadLine());

                                //close_custom = Convert.ToInt16(Console.ReadLine());
                                Console.ResetColor();

                                // Zufallszahl generieren
                                Random rnd_custom = new Random();
                                secret = Convert.ToInt16(rnd_custom.Next(min[level], max[level]));
                                choice_level = true;
                                break;

                            default:
                                // Zufallszahl generieren
                                Random rnd = new Random();
                                secret = Convert.ToInt16(rnd.Next(min[level], max[level]));
                                choice_level = true;
                                break;
                        }
                    }

                    // Fehler abfangen
                    catch
                    {
                        Console.Clear();
                        error = true;
                    }

                    // Konsolenfenster leeren
                    Console.Clear();

                    // Zahlenbereich anzeigen
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("*********** Zahlenraten *********** (" + secret + ")");
                    Console.ResetColor();
                    Console.Write("Die Zahl ist zwischen: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(min[level]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" und ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(max[level] - 1);
                    Console.ResetColor();
                    Console.WriteLine("");
                }

                // Eingabe / Auswertung
                try
                {
                    Console.Write("Dein Tip: ");
                    player_input = Convert.ToInt16(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("Es sind nur Zahlen erlaubt.");
                    player_input = 0;
                    Console.ResetColor();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("");
                    Console.SetCursorPosition(0, line);


                }

                if (player_input < secret && player_input != 0)
                {
                    Console.SetCursorPosition(20, line);
                    if (player_input < secret - close[level])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zu niedrig.");
                        player_try += 1;
                        line += 1;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Nah dran, aber leider zu niedrig.");
                        player_try += 1;
                        line += 1;
                        Console.ResetColor();
                    }
                }
                else if (player_input > secret && player_input != 0)
                {
                    Console.SetCursorPosition(20, line);
                    if (player_input > secret + close[level])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Zu hoch");
                        player_try += 1;
                        line += 1;
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Nah dran, aber leider zu hoch.");
                        player_try += 1;
                        line += 1;
                        Console.ResetColor();
                    }
                }
                else if (player_input == secret)
                {
                    Console.WriteLine("");
                    Console.Write("Super, du hast die gesuchte Zahl (");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(secret);
                    Console.ResetColor();
                    Console.WriteLine(")");
                    Console.Write("nach dem ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(player_try + ".");
                    Console.ResetColor();
                    Console.WriteLine(" Versuch gefunden!");
                }
            }
        }
    }
}
