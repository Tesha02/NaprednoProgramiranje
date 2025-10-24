using Common;
using Common.Domain;
using DBBroker;
using Server.SystemOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
	public class Controller
	{
		private Broker broker;

		private static Controller instance;
		public static Controller Instance
		{
			get
			{
				if (instance == null) instance = new Controller();
				return instance;
			}
		}
		private Controller() { broker = new Broker(); }

		public Radnik Login(Radnik r)
		{
			LoginSO so = new LoginSO(r);
			so.ExecuteTemplate();
			return so.Result;

		}

		public BindingList<Artikal> VratiArtikle()
		{
			VratiArtikleSO so = new VratiArtikleSO();
			so.ExecuteTemplate();
			return so.Result;
		}

		public List<Kupac> VratiKupce()
		{
			VratiKupceSO so = new VratiKupceSO();
			so.ExecuteTemplate();
			return so.Result;
		}

		public List<Mesto> VratiMesta()
		{
			VratiMestaSO so = new VratiMestaSO();
			so.ExecuteTemplate();
			return so.Result;
		}

		public List<Porudzbenica> VratiPorudzbenice()
		{
			VratiPorudzbeniceSO so = new VratiPorudzbeniceSO();
			so.ExecuteTemplate();
			return so.Result;
		}

		public List<StrSprema> VratiStrucneSpreme()
		{
			VratiStrSpremeSO so = new VratiStrSpremeSO();
			so.ExecuteTemplate();
			return so.Result;
		}

		public Kupac DodajKupca(Kupac k)
		{
			DodajKupcaSO so = new DodajKupcaSO(k);
			so.ExecuteTemplate();
			return so.Result;
		}

		public Kupac VratiKupca(Kupac k)
		{
			VratiKupcaSO so = new VratiKupcaSO(k);
			so.ExecuteTemplate();
			return so.Result;
		}

		public Artikal VratiArtikal(Artikal a)
		{
			VratiArtikalSO so = new VratiArtikalSO(a);
			so.ExecuteTemplate();
			return so.Result;
		}

		public Porudzbenica VratiPorudzbenicu(Porudzbenica a)
		{
			VratiPorudzbenicuSO so = new VratiPorudzbenicuSO(a);
			so.ExecuteTemplate();
			return so.Result;
		}

		public StrSprema VratiStrSpremu(StrSprema ss)
		{
			VratiStrSpremuSO so = new VratiStrSpremuSO(ss);
			so.ExecuteTemplate();
			return so.Result;
		}

		public Porudzbenica DodajPorudzbenicu(Porudzbenica p)
		{
			DodajPorudzbenicuSO so = new DodajPorudzbenicuSO(p);
			so.ExecuteTemplate();
			return so.Result;
		}

		public Artikal DodajArtikal(Artikal a)
		{
			DodajArtikalSO so = new DodajArtikalSO(a);
			so.ExecuteTemplate();
			return so.Result;
		}

		public void DodajMesto(Mesto m)
		{
			DodajMestoSO so = new DodajMestoSO(m);
			so.ExecuteTemplate();
		}

		public StrSprema DodajStrSpremu(StrSprema ss)
		{
			DodajStrSpremuSO so = new DodajStrSpremuSO(ss);
			so.ExecuteTemplate();
			return so.Result;
		}

		public Artikal AzurirajArtikal(Artikal a)
		{
			AzurirajArtikalSO so = new AzurirajArtikalSO(a);
			so.ExecuteTemplate();
			return a;
		}

		public Porudzbenica AzurirajPorudzbenicu(Porudzbenica p)
		{
			AzurirajPorudzbenicuSO so=new AzurirajPorudzbenicuSO(p);
			so.ExecuteTemplate() ;
			return p;
		}

		public Kupac AzurirajKupca(Kupac k)
		{
			AzurirajKupcaSO so = new AzurirajKupcaSO(k);
			so.ExecuteTemplate() ;
			return k;
		}

		public StrSprema AzurirajStrSpremu(StrSprema ss)
		{
			AzurirajStrSpremuSO so = new AzurirajStrSpremuSO(ss);
			so.ExecuteTemplate();
			return ss;
		}
		
		public void ObrisiMesto(Mesto m)
		{
			ObrisiMestoSO so = new ObrisiMestoSO(m);
			so.ExecuteTemplate();
		}

		public void ObrisiStrSpremu(StrSprema ss)
		{
			ObrisiStrSpremuSO so = new ObrisiStrSpremuSO(ss);
			so.ExecuteTemplate();
		}

		public void ObrisiPorudzbenicu(Porudzbenica p)
		{
			ObrisiPorudzbenicuSO so = new ObrisiPorudzbenicuSO(p);
			so.ExecuteTemplate();
		}

		internal object VratiTipove()
		{
			return Enum.GetValues(typeof(Tip))
			   .Cast<Tip>()
			   .ToList();
		}
	}
}
