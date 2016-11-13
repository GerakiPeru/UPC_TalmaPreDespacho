using EsquemaEntidades.Perfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaNegocio.Seguridad
{
    public class blUsuario
    {

        private List<beUsuario> usuarios = new List<beUsuario>();
        public blUsuario() 
        {

            beUsuario be;
            be = new beUsuario() { CO_USUA = "00000000000001", AL_USUA = "agrey", NO_USUA = "Allan Davis", AP_USUA = "Grey", AM_USUA = "Ferrari", PW_USUA = "12345678" };
            usuarios.Add(be);
            be = new beUsuario() { CO_USUA = "00000000000002", AL_USUA = "jjara", NO_USUA = "Julisa", AP_USUA = "Jara", AM_USUA = "Garro", PW_USUA = "02345678" };
            usuarios.Add(be);
            be = new beUsuario() { CO_USUA = "00000000000003", AL_USUA = "hvega", NO_USUA = "Hector", AP_USUA = "Vega", AM_USUA = "Gonzales", PW_USUA = "92345678" };
            usuarios.Add(be);
        }

        public List<beUsuario> GetUsuariosAll()
        {
            return usuarios;
        }

        public beUsuario GetUsuariobyCodigo(string Codigo)
        {
            beUsuario usuario = new beUsuario();
            foreach (var be in usuarios.Where(be=> be.CO_USUA == Codigo).ToList())
            {
                usuario = be;
                break;
            }
            return usuario;
        }

        public beUsuario Valida_Usuario(string AL_USUA, string PW_USUA)
        {

            beUsuario be;
            be = new beUsuario();
            foreach (var o in usuarios.Where(o => o.AL_USUA == AL_USUA.ToLower() && o.PW_USUA == PW_USUA).ToList())
                be = o;

            return be;
        }
    }
}
