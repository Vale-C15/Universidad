using lib_comunicaciones.Interfaces;
using lib_entidades.Modelos;
using lib_presentaciones.Interfaces;
using lib_utilidades;

namespace lib_presentaciones.Implementaciones
{
    public class NivelesPresentacion : INivelesPresentacion
    {
        private INivelesComunicacion? iComunicacion = null;
        public NivelesPresentacion(INivelesComunicacion iComunicacion)
        {
            this.iComunicacion = iComunicacion;
        }
        public async Task<List<Niveles>> Listar()
        {
            var lista = new List<Niveles>();
            var datos = new Dictionary<string, object>();
            var respuesta = await iComunicacion!.Listar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Niveles>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
        public async Task<List<Niveles>> Buscar(Niveles entidad, string tipo)
        {
            var lista = new List<Niveles>();
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            datos["Tipo"] = tipo;
            var respuesta = await iComunicacion!.Buscar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            lista = JsonConversor.ConvertirAObjeto<List<Niveles>>(
                JsonConversor.ConvertirAString(respuesta["Entidades"]));
            return lista;
        }
        public async Task<Niveles> Guardar(Niveles entidad)
        {
            if (entidad.Id != 0
                || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            var respuesta = await iComunicacion!.Guardar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Niveles>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
        public async Task<Niveles> Modificar(Niveles entidad)
        {
            if (entidad.Id == 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            var respuesta = await iComunicacion!.Modificar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Niveles>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
        public async Task<Niveles> Borrar(Niveles entidad)
        {
            if (entidad.Id == 0 || !entidad.Validar())
            {
                throw new Exception("lbFaltaInformacion");
            }
            var datos = new Dictionary<string, object>();
            datos["Entidad"] = entidad;
            var respuesta = await iComunicacion!.Borrar(datos);
            if (respuesta.ContainsKey("Error"))
            {
                throw new Exception(respuesta["Error"].ToString()!);
            }
            entidad = JsonConversor.ConvertirAObjeto<Niveles>(
                JsonConversor.ConvertirAString(respuesta["Entidad"]));
            return entidad;
        }
    }
}
