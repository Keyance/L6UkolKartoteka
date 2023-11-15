var kartoteka = new Dictionary<string, string>();

kartoteka.Add("Tera Dostalíková", "1999");
kartoteka.Add("Radek Pavel", "1985");
kartoteka.Add("Nela Nechtěná", "1995");
kartoteka.Add("Alice Johnson", "1990");
kartoteka.Add("Bob Smith", "1985");
kartoteka.Add("Emily Davis", "1993");
kartoteka.Add("John Miller", "1980");
kartoteka.Add("Samantha White", "1998");

bool jeKonec = false;

while (!jeKonec)
{
    Console.WriteLine("1 - Přidat osobu");
    Console.WriteLine("2 - Smazat osobu");
    Console.WriteLine("3 - Vypsat osoby");
    Console.WriteLine("4 - Vyhledávat v kartotéce");
    Console.WriteLine("5 - Statistika kartotéky");
    Console.WriteLine("0 - Konec");

    int volba = Convert.ToInt32(Console.ReadLine());
    if (volba < 0 || volba > 5)
    {
        Console.WriteLine("Nebylo zadáno validní číslo. Prosím zadejte číslo od 0 do 5.");
    }
    else
    {

        switch (volba)
        {
            case 0:
                jeKonec = true;
                break;
            case 1:
                {
                    Console.WriteLine("Zadej křestní jméno:");
                    string jmeno = Console.ReadLine();
                    Console.WriteLine("Zadej příjmení:");
                    string prijmeni = Console.ReadLine();
                    string celeJmeno = jmeno + " " + prijmeni;
                    Console.WriteLine("Zadej rok narození:");
                    string rokNarozeni = Console.ReadLine();
                    kartoteka.Add(celeJmeno, rokNarozeni);
                    break;
                }
            case 2:
                {
                    Console.WriteLine("Zadej jméno (křestní i příjmení) osoby, kterou chceš smazat:");
                    string jmeno = Console.ReadLine();
                    if (kartoteka.Remove(jmeno))
                    {
                        Console.WriteLine("Položka byla smazána.");
                    }
                    else { Console.WriteLine("položka nebyla nalezena."); }
                    break;
                }
            case 3:
                {
                    Console.WriteLine("1 - vypsat osoby dle pořadí v kartrotéce.");
                    Console.WriteLine("2 - vypsat osoby dle abecedy.");
                    Console.WriteLine("3 - vypsat osoby dle roku narození.");

                    int volba2 = Convert.ToInt32(Console.ReadLine());

                    if (volba2 < 1 || volba2 > 3)
                    { Console.WriteLine("Nebylo zadáno validní číslo. Prosím zadejte číslo od 1 do 3."); }
                    else
                    {
                        switch (volba2)
                        {
                            case 1:
                                {
                                    int i = 0;
                                    foreach (var o in kartoteka)
                                    {
                                        Console.WriteLine($"{i}\t{o.Key}\t{o.Value}");
                                        i++;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    foreach (var o in kartoteka.OrderBy(o => o.Key))
                                    {
                                        Console.WriteLine($"{o.Key}\t{o.Value}");
                                    }
                                }
                                break;

                            case 3:
                                {
                                    foreach (var o in kartoteka.OrderBy(o => o.Value))
                                    {
                                        Console.WriteLine($"{o.Value} - {o.Key}");
                                    }
                                }
                                break;
                        }
                    }
                    break;
                }

            case 4:
                {
                    Console.WriteLine("1 - vyhledat dle začátku jména.");
                    Console.WriteLine("2 - vyhledat dle narození.");

                    int volba3 = Convert.ToInt32(Console.ReadLine());

                    if (volba3 < 1 || volba3 > 2)
                    {
                        Console.WriteLine("Nebylo zadáno validní číslo. Prosím zadejte číslo od 1 do 2.");
                    }
                    else
                    {
                        switch (volba3)
                        {
                            case 1:
                                {
                                    Console.WriteLine("Zadej počátek hledané osoby:");
                                    string pocatek = Console.ReadLine();
                                    var jmeno = kartoteka.Where(x => x.Key.StartsWith(pocatek)).Select(z => z).ToList();
                                    foreach (var jm in jmeno.OrderBy(jm => jm.Key))
                                    {
                                        Console.WriteLine(jm.Key + " " + jm.Value);
                                    }
                                }
                                break;

                            case 2:
                                {
                                    Console.WriteLine("Zadej počátek roku narození:");
                                    string pocatek = Console.ReadLine();
                                    var jmeno = kartoteka.Where(x => x.Value.StartsWith(pocatek)).Select(z => z).ToList();
                                    foreach (var jm in jmeno.OrderBy(jm => jm.Value))
                                    {
                                        Console.WriteLine(jm.Value + " " + jm.Key);
                                    }
                                }
                                break;

                        }
                    }
                    break;
                }
            case 5:
                {
                    Console.WriteLine("1 - počet osob dle roku narození");
                    Console.WriteLine("2 - nejstarší osoba v kartotéce");
                    Console.WriteLine("3 - pouze osoby narozené po roce 1990");
                    int volba3 = Convert.ToInt16(Console.ReadLine());
                    if (volba3 < 1 || volba3 > 3)
                    {
                        Console.WriteLine("Nebylo zadáno validní číslo. Prosím zadejte číslo od 1 do 3.");
                    }
                    else
                    {
                        switch (volba3)
                        {
                            case 1:
                                {
                                    var skupinyDleVeku = kartoteka.GroupBy(c => c.Value);

                                    foreach (var skupina in skupinyDleVeku)
                                    {
                                        Console.WriteLine($"Osoby narozené v roce {skupina.Key}:");
                                        foreach (var jeden in skupina)
                                        {
                                            Console.WriteLine($"  {jeden.Key}");
                                        }
                                    }
                                }
                                break;
                            case 2:
                                {

                                }
                                break;
                        }
                            
                    }
                }
                break;
        }
    }
}