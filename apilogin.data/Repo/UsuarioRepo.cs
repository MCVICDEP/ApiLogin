using apilogin.modelo;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apilogin.data.Repo
{
    public class UsuarioRepo : ILoginRepo
    {
        private readonly MySqlConfiguration _connectionString;
        public UsuarioRepo(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbconexion()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> EliminarUsuario(Usuario usuario)
        {
            var db = dbconexion();
            var sql = @"DELETE FROM usuario WHERE idusuario = @Id";
            var result = await db.ExecuteAsync(sql, new { Id = usuario.idusuario });
            return result > 0;
        }

        public async Task<Usuario> GetDetalles(int id)
        {
            var db = dbconexion();
            var sql = @"SELECT * FROM usuario WHERE idusuario = @Id";
            return await db.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            var db = dbconexion();
            var sql = @"SELECT * FROM usuario WHERE flag = 0 order by idusuario ASC";

            return await db.QueryAsync<Usuario>(sql, new { });
        }

        public async Task<bool> InsertarUsuario(Usuario usuario)
        {
            var db = dbconexion();
            var sql = @"INSERT INTO usuario (idusuario, dni_usuario, nombres_usuario, correo, password, celular, rol_usuario, fecha_creacion, region, flag) 
                        VALUES (@idusuario ,@dni_usuario, @nombres_usuario, @correo, @password, @celular, @rol_usuario, @fecha_creacion, @region, @flag)";
            var result = await db.ExecuteAsync(sql, new
            {
                usuario.idusuario,
                usuario.dni_usuario,
                usuario.nombres_usuario,
                usuario.correo,
                usuario.password,
                usuario.celular,
                usuario.rol_usuario,
                usuario.fecha_creacion,
                usuario.region,
                usuario.flag
            });
            return result > 0;
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            var db = dbconexion();
            var sql = @"UPDATE productos SET dni_usuario = @dni_usuario, 
                                            nombres_usuario = @nombres_usuario, 
                                            correo = @correo, 
                                            password = @password, 
                                            celular = @celular, 
                                            rol_usuario = @rol_usuario,
                                            fecha_creacion = @fecha_creacion
                                            region = @region
                                            flag = @flag
                                            WHERE idusuario = @idusuario";

            var result = await db.ExecuteAsync(sql, new
            {
                usuario.idusuario,
                usuario.dni_usuario,
                usuario.nombres_usuario,
                usuario.correo,
                usuario.password,
                usuario.celular,
                usuario.rol_usuario,
                usuario.fecha_creacion,
                usuario.region,
                usuario.flag
            });
            return result > 0;
        }
    }
}
