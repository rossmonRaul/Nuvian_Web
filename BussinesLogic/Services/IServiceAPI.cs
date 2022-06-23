using BussinesLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Services
{
    public interface IServiceAPI
    {
        //Tarea para listar todos los usuarios que se encuentren en la base de datos
        Task<List<UsuariosAll>> ListarUsuarios();
        //Tarea para obtener un solo usuario usando la ID_USR 
        Task<List<UsuariosbyID>> ObtenerUsuario(int id);
        //Tarea para editar los datos de los usuarios
        Task<bool> EditarUsuario(ActualizarUsuario actualizar);
        UserModel Create(UserModel usuarios);

        bool Delete(int ID_USR);
    }
}
