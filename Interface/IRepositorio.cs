using System.Collections.Generic;

namespace Dio.Serie.Interface
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetonarPorId(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}