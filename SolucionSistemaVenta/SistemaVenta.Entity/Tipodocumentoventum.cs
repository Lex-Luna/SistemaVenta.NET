﻿using System;
using System.Collections.Generic;

namespace SistemaVenta.Entity;

public partial class Tipodocumentoventum
{
    public int IdTipoDocumentoVenta { get; set; }

    public string? Descripcion { get; set; }

    public ulong? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
