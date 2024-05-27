

namespace OrganTransplant
{
    internal class Bernt
    {
        private bool _isHurt = false;
        private int healthyKidneys = 2;
        private int damagedKidneys = 0;
        private bool _isDead = false;


        public void Kekw()
        {
            while (true)
            {

            
            Console.WriteLine(
                @"En varm sommerdag sitter Bernt ute i sola og koser seg. Han merker at han begynner å bli tørst. Hva gjør Bernt videre?
1: finner seg et stort glass vann
2: finner seg en øl eller ti
3: gjør ingenting og blir sittende i sola");
            string answerOne = Console.ReadLine();
            if (answerOne == "1")
            {
                Console.WriteLine(
                    $"Bernt finner seg et stort glass vann som han drikker. Alt er fint. Bernt har {healthyKidneys} sunne nyrer.");
                break;
            }
            else if (answerOne == "2")
            {
                healthyKidneys--;
                damagedKidneys++;
                _isHurt = true;
                Console.WriteLine(@$"Bernt finner seg en øl eller ti. 
Han blir full og får til slutt leversvikt av alkoholinntaket, 
som igjen fører til hormonendringer som påvirker blodstrømmen og blodtrykket i nyrene.
Dette fører igjen til at en av nyrene blir skadet og slutter å fungere.
Bernt har nå {healthyKidneys} sunn nyre og {damagedKidneys} skadd nyre.");
                break;
            }
            else if (answerOne == "3")
            {
                healthyKidneys--;
                damagedKidneys++;
                _isHurt = true;
                Console.WriteLine(@$"Bernt blir sittende i sola og blir til slutt dehydrert.
Dette fører til at en nyre tørker inn og blir skadet.
Bernt har nå {healthyKidneys} sunn nyre og {damagedKidneys} skadd nyre.");
                break;
            }
            else
            {
                Console.WriteLine("Vennligst velg 1, 2 eller 3.");
            }
            }
        

            if (_isHurt)
            {
                Console.WriteLine($@"
Bernt kommer seg omsider til sykehuset og får beskjed om at han må ha en nyretransplantasjon.
Fetteren hans, Kåre besøker Bernt på sykehuset og får nyheten om tilstanden til Bernt. Hva gjøre Kåre?
1: drar hjem
2: foreslår å se om han er kompapibel til å donere en nyre
3: Nekter å gjennomføre tester, men fortsatt donerer en nyre til Bernt.");
                string answerTwo = Console.ReadLine();
                if (answerTwo == "1")
                {
                    Console.WriteLine(@$"Kåre drar hjem. Barnt står nå på ventelisten av en ny nyre.
Bernt har fortsatt {healthyKidneys} sunn nyre og {damagedKidneys} skadd nyre.
");
                }
                else if (answerTwo == "2")
                {
                    healthyKidneys++;
                    damagedKidneys--;
                    Console.WriteLine(@$"Kåre gjennomfører en rekke tester og finner ut at
har mulighet til å donere en nyre til Bernt. 
Operasjonen var en suksess!
Bernt har {healthyKidneys} sunne nyrer og {damagedKidneys} skadde nyrer.
");
                }
                else if (answerTwo == "3")
                {
                    _isHurt = false;
                    _isDead = true;
                    Console.WriteLine($@"Kåre nekter å gjennomføre tester for å se om han 
er kompapibel til å donere en nyre til Bernt, men donerer en nyre allikevel.");
                }
                else
                {
                    Console.WriteLine("Vennligst velg 1, 2 eller 3.");
                }
            }

            if (_isDead)
            {
                Console.WriteLine(@"Nyren som Bernt fikk var ikke bra for han.
Dette medfører komplikasjoner og Bernt er nå død.");
                Environment.Exit(0);
            }
        }
    }
    }       

