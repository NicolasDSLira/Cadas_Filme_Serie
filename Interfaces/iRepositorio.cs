using System.Collections.Generic;

namespace Cadastro_Series.Interfaces
{
    public interface iRepositorio<T>
    {
        List<T> Lista();

        T RetornaPorId(int id);

        void Insere(T entidade);

        void Excluir(int id);

        void Atualizar(int id, T entidade);

        int ProximoId();       
    }
}