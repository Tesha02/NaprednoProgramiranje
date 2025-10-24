using Common.Communication;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	public class ClientHandler
	{
		private JsonNetworkSerializer serializer;
		private Socket socket;
		private readonly Server server;

		public ClientHandler(Socket socket, Server server)
		{
			this.socket = socket;
			this.server = server;
			serializer = new JsonNetworkSerializer(socket);
		}

		public void HandleRequest()
		{
			try
			{
				while (true)
				{
					Request req = serializer.Receive<Request>();
					Response r = ProcessRequest(req);
					serializer.Send(r);
				}
			}
			catch (SocketException)
			{
				Debug.WriteLine("Komunikacija sa klijentom je prekinuta");
			}
			catch (IOException)
			{
				Debug.WriteLine("Komunikacija sa klijentom je prekinuta");
			}
			finally
			{
				if (socket.Connected)
				{
					socket.Close();
				}
				server.RemoveClient(this);
			}
		}

		private Response ProcessRequest(Request req)
		{
			Response r = new Response();
			try
			{
				switch (req.Operation)
				{
					case Operation.Login:
						{
							r.Result= Controller.Instance.Login(serializer.ReadType<Radnik>(req.Argument));
							break;
						}
					case Operation.DodajKupca:
						{
							r.Result=(Controller.Instance.DodajKupca(serializer.ReadType<Kupac>(req.Argument))).Id;
							break;
						}
					case Operation.DodajPorudzbenicu:
						{
							r.Result=Controller.Instance.DodajPorudzbenicu(serializer.ReadType<Porudzbenica>(req.Argument)).Id;
							break;
						}
					case Operation.DodajArtikal:
						{
							r.Result=Controller.Instance.DodajArtikal(serializer.ReadType<Artikal>(req.Argument)).Id;
							break;
						}
					case Operation.DodajMesto:
						{
							Controller.Instance.DodajMesto(serializer.ReadType<Mesto>(req.Argument));
							break;
						}
					case Operation.DodajStrSpremu:
						{
							r.Result=Controller.Instance.DodajStrSpremu(serializer.ReadType<StrSprema>(req.Argument)).Id;
							break;
						}
					case Operation.VratiArtikle:
						{
							r.Result=Controller.Instance.VratiArtikle();
							break;
						}
					case Operation.VratiKupce:
						{
							r.Result= Controller.Instance.VratiKupce();
							break;
						}
					case Operation.VratiMesta:
						{
							r.Result = Controller.Instance.VratiMesta();
							break;
						}
					case Operation.VratiPorudzbenice:
						{
							r.Result = Controller.Instance.VratiPorudzbenice();
							break;
						}
					case Operation.VratiStrSpreme:
						{
							r.Result = Controller.Instance.VratiStrucneSpreme();
							break;
						}
					case Operation.VratiTipove:
						{
							r.Result = Controller.Instance.VratiTipove();
							break;
						}
					case Operation.VratiKupca:
						{
							r.Result = Controller.Instance.VratiKupca(serializer.ReadType<Kupac>(req.Argument));
							break;
						}
					case Operation.VratiArtikal:
						{
							r.Result = Controller.Instance.VratiArtikal(serializer.ReadType<Artikal>(req.Argument));
							break;
						}
					case Operation.VratiPorudzbenicu:
						{
							r.Result = Controller.Instance.VratiPorudzbenicu(serializer.ReadType<Porudzbenica>(req.Argument));
							break;
						}
					case Operation.VratiStrSpremu:
						{
							r.Result = Controller.Instance.VratiStrSpremu(serializer.ReadType<StrSprema>(req.Argument));
							break;
						}
					case Operation.AzurirajArtikal:
						{
							r.Result = Controller.Instance.AzurirajArtikal(serializer.ReadType<Artikal>(req.Argument));
							break;
						}
					case Operation.AzurirajKupca:
						{
							r.Result = Controller.Instance.AzurirajKupca(serializer.ReadType<Kupac>(req.Argument));
							break;
						}
					case Operation.AzurirajPorudzbenicu:
						{
							r.Result = Controller.Instance.AzurirajPorudzbenicu(serializer.ReadType<Porudzbenica>(req.Argument));
							break;
						}
					case Operation.AzurirajStrSpremu:
						{
							r.Result = Controller.Instance.AzurirajStrSpremu(serializer.ReadType<StrSprema>(req.Argument));
							break;
						}
					case Operation.ObrisiMesto:
						{
							Controller.Instance.ObrisiMesto(serializer.ReadType<Mesto>(req.Argument));
							break;
						}
					case Operation.ObrisiStrSpremu:
						{
							Controller.Instance.ObrisiStrSpremu(serializer.ReadType<StrSprema>(req.Argument));
							break;
						}
					case Operation.ObrisiPorudzbenicu:
						{
							Controller.Instance.ObrisiPorudzbenicu(serializer.ReadType<Porudzbenica>(req.Argument));
							break;
						}



				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				Debug.WriteLine(r.ExceptionMessage);
				r.ExceptionMessage = ex.Message;
			}
			return r;
		}

		internal void CloseSocket()
		{
			socket.Close();
		}
	}
}
