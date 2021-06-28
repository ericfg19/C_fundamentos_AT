using ClassAgenda;
using System.Collections.Generic;

namespace AgendaRepositorio
{
    public interface IAgendaRepositorio
    {
        void DeleteAmigo(int IdSku);
        List<Amigo> GetAll();
        Amigo GetAmigoById(int IdSku);
        void InsertAmigo(Amigo amigo);
        void UpdateAmigo(Amigo amigo, int IdSku);
    }
}