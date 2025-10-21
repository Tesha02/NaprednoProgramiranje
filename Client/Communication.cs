using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
	public class Communication
	{
		public Radnik Radnik { get; set; }
		private static Communication _instance;
		public bool IsConnected;

		public static Communication Instance
		{
			get
			{
				if (_instance == null) _instance = new Communication();
				return _instance;
			}
		}
		private Communication()
		{

		}

		private Socket socket;
		private JsonNetworkSerializer serializer;

		public void Connect()
		{

			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect("127.0.0.1", 9999);
			serializer = new JsonNetworkSerializer(socket);
		}

		internal Response Login(Radnik r)
		{
			try
			{
				Request req = new Request
				{
					Argument = r,
					Operation = Operation.Login
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();

				response.Result = serializer.ReadType<Radnik>(response.Result); // deserijalizujemo result u user-a
				Radnik = (Radnik)response.Result;
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };
			}
		}

		internal Response UnesiKorisnika(Kupac k)
		{
			try
			{
				Request req = new Request
				{
					Argument = k,
					Operation = Operation.DodajKupca
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = JsonSerializer.Deserialize<long>((JsonElement)response.Result);

				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };
			}
		}

		internal Response DodajArtikal(Artikal a)
		{
			try
			{
				Request req = new Request
				{
					Argument = a,
					Operation = Operation.DodajArtikal
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = JsonSerializer.Deserialize<long>((JsonElement)response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response UnesiMesto(Mesto m)
		{
			try
			{
				Request req = new Request
				{
					Argument = m,
					Operation = Operation.DodajMesto
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response UnesiStrSpremu(StrSprema ss)
		{
			try
			{
				Request req = new Request
				{
					Argument = ss,
					Operation = Operation.DodajStrSpremu
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = JsonSerializer.Deserialize<long>((JsonElement)response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response VratiKupce()
		{
			try
			{
				Request req = new Request
				{
					Operation = Operation.VratiKupce
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<BindingList<Kupac>>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };
			}
		}

		internal Response VratiMesta()
		{
			try
			{
				Request req = new Request
				{
					Operation = Operation.VratiMesta
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<BindingList<Mesto>>(response.Result); // deserijalizujemo result u user-a
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response VratiArtikle()
		{
			try
			{
				Request req = new Request
				{
					Operation = Operation.VratiArtikle
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<BindingList<Artikal>>(response.Result); // deserijalizujemo result u user-a
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response VratiTipove()
		{
			try
			{
				Request req = new Request
				{
					Operation = Operation.VratiTipove
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();

				response.Result = serializer.ReadType<List<Tip>>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}

		}

		internal Response DodajPorudzbenicu(Porudzbenica p)
		{
			try
			{
				Request req = new Request
				{
					Argument = p,
					Operation = Operation.DodajPorudzbenicu
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = JsonSerializer.Deserialize<long>((JsonElement)response.Result);

				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response VratiArtikal(Artikal a)
		{
			try
			{
				Request req = new Request
				{
					Argument = a,
					Operation = Operation.VratiArtikal
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<Artikal>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response VratiKupca(Kupac k)
		{
			try
			{
				Request req = new Request
				{
					Argument = k,
					Operation = Operation.VratiKupca
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<Kupac>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response AzurirajArtikal(Artikal artikalZaIzmenu)
		{
			try
			{
				Request req = new Request
				{
					Argument = artikalZaIzmenu,
					Operation = Operation.AzurirajArtikal
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<Artikal>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response AzurirajKupca(Kupac kupacZaIzmenu)
		{
			try
			{
				Request req = new Request
				{
					Argument = kupacZaIzmenu,
					Operation = Operation.AzurirajKupca
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();

				response.Result = serializer.ReadType<Kupac>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response ObrisiMesto(Mesto? m)
		{
			try
			{
				Request req = new Request
				{
					Argument = m,
					Operation = Operation.ObrisiMesto
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };
			}
		}

		internal Response VratiStrSpreme()
		{
			try
			{
				Request req = new Request
				{
					Operation = Operation.VratiStrSpreme
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<BindingList<StrSprema>>(response.Result); // deserijalizujemo result u user-a
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response ObrisiStrSpremu(StrSprema? sprema)
		{
			try
			{
				Request req = new Request
				{
					Argument = sprema,
					Operation = Operation.ObrisiStrSpremu
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response VratiStrSpremu(StrSprema strSpremaZaIzmenu)
		{
			try
			{
				Request req = new Request
				{
					Argument = strSpremaZaIzmenu,
					Operation = Operation.VratiStrSpremu
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<StrSprema>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response AzurirajStrSpremu(StrSprema strSpremaZaIzmenu)
		{
			try
			{
				Request req = new Request
				{
					Argument = strSpremaZaIzmenu,
					Operation = Operation.AzurirajStrSpremu
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();

				response.Result = serializer.ReadType<StrSprema>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response VratiPorudzbenice()
		{
			try
			{
				Request req = new Request
				{
					Operation = Operation.VratiPorudzbenice
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<BindingList<Porudzbenica>>(response.Result); // deserijalizujemo result u user-a
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response ObrisiPorudzbenicu(Porudzbenica? p)
		{
			try
			{
				Request req = new Request
				{
					Argument = p,
					Operation = Operation.ObrisiPorudzbenicu
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response VratiPorudzbenicu(Porudzbenica porudzbenicaZaIzmenu)
		{
			try
			{
				Request req = new Request
				{
					Argument = porudzbenicaZaIzmenu,
					Operation = Operation.VratiPorudzbenicu
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();
				response.Result = serializer.ReadType<Porudzbenica>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal Response AzurirajPorudzbenicu(Porudzbenica porudzbenicaZaIzmenu)
		{
			try
			{
				Request req = new Request
				{
					Argument = porudzbenicaZaIzmenu,
					Operation = Operation.AzurirajPorudzbenicu
				};
				serializer.Send(req);
				Response response = serializer.Receive<Response>();

				response.Result = serializer.ReadType<Porudzbenica>(response.Result);
				return response;
			}
			catch (Exception)
			{

				return new Response { ExceptionMessage = "Server je zaustavljen ili nije dostupan." };

			}
		}

		internal void Disconnect()
		{
			try
			{
				if (socket != null && socket.Connected)
				{
					socket.Shutdown(SocketShutdown.Both);
					socket.Close();
				}
			}
			catch { }
			finally
			{
				socket = null;
			}
		}

		//internal void DodajStavkuPorudzbenice(StavkaPorudzbenice sp)
		//{
		//	Request req = new Request
		//	{
		//		Argument = sp,
		//		Operation = Operation.DodajStavku
		//	};
		//	serializer.Send(req);
		//	Response response = serializer.Receive<Response>();
		//}

		//internal BindingList<Artikal> VratiArtiklePoTipu()
		//{
		//	Request req = new Request
		//	{
		//		Operation = Operation.VratiArtiklePoTipu
		//	};
		//	serializer.Send(req);
		//	Response response = serializer.Receive<Response>();

		//	response.Result = serializer.ReadType<BindingList<Artikal>>(response.Result);
		//	return (BindingList<Artikal>)response.Result;
		//}
	}
}
