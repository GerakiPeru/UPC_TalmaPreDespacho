namespace WebApplication1.Controllers
{
    using EsquemaEntidades.Perfiles;
    using LogicaNegocio.Seguridad;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// PersonaController
    /// </summary>
    public class beUsuarioController : ApiController
    {
        [HttpGet]
        public IHttpActionResult getUsuarios()
        {
            try
            {
                blUsuario bl = new blUsuario();
                List<beUsuario> ocol = bl.GetUsuariosAll();
                return Ok(ocol);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public IHttpActionResult getUsuario([FromUri] string Codigo)
        {
            try
            {
                blUsuario bl = new blUsuario();
                beUsuario be = bl.GetUsuariobyCodigo(Codigo.ToString());
                return Ok(be);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public IHttpActionResult getUsuarioById(string Codigo)
        {
            try
            {
                blUsuario bl = new blUsuario();
                beUsuario be = bl.GetUsuariobyCodigo(Codigo.ToString());
                return Ok(be);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IHttpActionResult insertUsuario([FromBody] beUsuario usuario)
        {
            try
            {
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public IHttpActionResult updateUsuario([FromBody] beUsuario usuario, [FromUri] string id)
        {
            try
            {
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        public IHttpActionResult deleteUsuario([FromUri] string id)
        {
            try
            {
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
