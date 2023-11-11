using System;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure.Endpoint.Builders
{
    public class SqlEntitySettings   
    {
        public string TableName { get; set; } //Categoria
        public string Schema { get; set; }    //seguridad
        public bool HasSchema { get => !string.IsNullOrEmpty(Schema); }  
        public string NormalizedTableName { get => HasSchema ? $"[{Schema}].[{TableName}]" : TableName; }
        public List<SqlColumnSettings> Columns { get; set; }
    }

    public class SqlColumnSettings
    {
        public string Name { get; set; }  //como sale en la base de datos
        public string DomainName { get; set; }  //como sale en el c#
        public string ParameterName { get => $"@{Name}"; }
        public SqlDbType SqlDbType { get; set; }
        public bool IsComputedColumn { get; set; } = false;
        public bool HasConversion => !(Conversion is null);
        public PropertyConversionData Conversion { get; set; } = null;
        public bool IsComplete { get; set; } = false;
        public bool IsPrimaryKey { get; set; }
        public bool IsNullable { get; set; }
    }

    public class PropertyConversionData
    {
        public dynamic OutgoingConversion { get; set; }
        public dynamic IncommingConversion { get; set; }
        public Type ProviderType { get; set; }
        public Type PropertyType { get; set; }
    }
}
