using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgMaGest.C_Logica.Entidades;

namespace AgMaGest.C_Datos
{
    public class UbicacionDAL
    {
        private PaisDAL paisDAL = new PaisDAL();
        private ProvinciaDAL provinciaDAL = new ProvinciaDAL();
        private LocalidadDAL localidadDAL = new LocalidadDAL();

        public List<Pais> ObtenerPaises()
        {
            return paisDAL.ObtenerPaises();
        }

        public List<Provincia> ObtenerProvinciasPorPais(int idPais)
        {
            return provinciaDAL.ObtenerProvinciasPorPais(idPais);
        }

        public List<Localidad> ObtenerLocalidadesPorProvincia(int idProvincia)
        {
            return localidadDAL.ObtenerLocalidadesPorProvincia(idProvincia);
        }
    }
}
