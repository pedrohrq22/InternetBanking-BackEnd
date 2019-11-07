using System.Linq;
using InternetBanking.Models;
using System.Collections.Generic;

namespace InternetBanking.Repositorio
{
    public class FamiliaresRepositorio : IfamiliaresRepositorio
    {
        private readonly ClienteDB _contexto;
        public FamiliaresRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }
        public void AddFamiliares(Familiares familiares)
        {
            _contexto.InfoFamiliares.Add(familiares);
            _contexto.SaveChanges();
        }
        public Familiares FindByFam(int Fam)
        {
            return _contexto.InfoFamiliares.FirstOrDefault(
                e => e.ID_CLIENTE == Fam
            );
        }
        public IEnumerable<Familiares> GetAll()
        {
            return _contexto.InfoFamiliares.ToList();
        }
    }
}