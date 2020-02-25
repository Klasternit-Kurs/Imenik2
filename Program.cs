using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imenik
{
	class Program
	{
		static void Main(string[] args)
		{		
			do
			{
				StampajMeni();
				char unos = Console.ReadKey().KeyChar;
				switch(unos)
				{
					case '1':
						Unos();
						break;
					case '2':
						Console.WriteLine();
						foreach(Osoba o in Osoba.Imenik)
						{
							Console.WriteLine(o);
						}
						break;
					case '3':
						Izmena();
						break;
					case '4':
						Brisanje();
						break;
					case '5':
						Environment.Exit(2);
						break;
					default:
						Console.WriteLine("Pogresan unos :(");
						break;
				}
			} while (true);
		}

		static void Izmena()
		{
			//TODO kao i kod brisanja, napraviti da radi sa indeksima
			//+ da moze da se menja i broj telefona a ne samo ime i prezime :) 

			Console.Write("\nUnesite broj telefona: ");
			string br = Console.ReadLine();
			if (Osoba.ProveriTelefon(br, out Osoba o))
			{
				Console.Write("\nUnesite ime i prezime: ");
				string[] imeIprezime = Console.ReadLine().Split(' ');
				if (imeIprezime.Length != 2)
				{
					Console.WriteLine("Greska u unosu!");
					return;
				}
				o.ime = imeIprezime[0];
				o.prezime = imeIprezime[1];
			}
			else
			{
				Console.WriteLine("Ne postoji broj :(");
			}
		}

		static void Brisanje()
		{
			//TODO napraviti brisanje preko indeksa koristenjem
			//for petlje i RemoveAt

			Console.Write("\nUnesite broj telefona: ");
			string br = Console.ReadLine();
			if (Osoba.ProveriTelefon(br, out Osoba o))
			{
				Osoba.Imenik.Remove(o);
			} else
			{
				Console.WriteLine("Ne postoji broj :(");
			}

		}

		static void Unos()
		{
			//TODO Za domaci da se napravi petlja ovde tako da se metoda ne zavrsi
			//odmah po pogresnom unosu
			Console.Write("\nUnesite ime i prezime: ");
			string[] imeIprezime = Console.ReadLine().Split(' ');
			if (imeIprezime.Length != 2)
			{
				Console.WriteLine("Greska u unosu!");
				return;
			}
			//TODO Za domaci da se napravi provera formata za broj
			//koristan split()
			//br.StartsWith("+381"); -- vraca true ako pocinje sa +381
			Console.Write("Unesite broj: ");
			string br = Console.ReadLine();

			if (Osoba.ProveriTelefon(br, out _))
			{
				Console.WriteLine("Telefon vec postoji!");
			}
			else
			{
				new Osoba(imeIprezime[0], imeIprezime[1], br);
			}
		}

		static void StampajMeni()
		{
			Console.WriteLine("\n1. Unos");
			Console.WriteLine("2. Ispis");
			Console.WriteLine("3. Izmena");
			Console.WriteLine("4. Brisanje");
			Console.WriteLine("5. Izlaz");
			Console.WriteLine("------------------");
			Console.Write("Unesite broj: ");
		}
	}

	class Osoba
	{
		static public List<Osoba> Imenik = new List<Osoba>();

		public string ime, prezime, broj;
		//public string prezime;


		public static bool ProveriTelefon(string t, out Osoba ob)
		{
			foreach (Osoba o in Imenik)
			{
				if (o.broj == t)
				{
					ob = o;
					return true;
				}
			}
			ob = null;
			return false;
		}

		public Osoba(string i, string p, string b) 
		{
			ime = i;
			prezime = p;
			broj = b;
			Imenik.Add(this);
		}

		public override string ToString()
		{
			return $"--- {ime} {prezime} -- {broj} ---";
		}
	}
}
