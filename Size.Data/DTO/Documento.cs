using Size.Data.Enums;
using System;

namespace Size.Data.DTO
{
    public class Documento
    {
        public Guid ID { get; private set; }
        public ETipoDocumento TipoDocumento { get; private set; }
        public string Numero { get; private set; }
    }
}
