using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using OE.LHB.Models;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace OE.LHB.Migrations.EntityBuilders
{
    public class ProviderEntityBuilder : AuditableBaseEntityBuilder<ProviderEntityBuilder>
    {
        private const string _entityTableName = "Provider";
        private readonly PrimaryKey<ProviderEntityBuilder> _primaryKey = new("PK_Provider", x => x.Id);
 
        public ProviderEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
        }

        protected override ProviderEntityBuilder BuildTable(ColumnsBuilder table)
        {
            Id = AddAutoIncrementColumn(table,"Id");
            Name = AddMaxStringColumn(table,"Name",true);
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> Id { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
