﻿using Common.Communication;
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
