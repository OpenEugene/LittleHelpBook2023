using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace OE.LHB.Migrations.EntityBuilders
{
    public class LHBEntityBuilder : AuditableBaseEntityBuilder<LHBEntityBuilder>
    {
        private const string _entityTableName = "OELHB";
        private readonly PrimaryKey<LHBEntityBuilder> _primaryKey = new("PK_OELHB", x => x.LHBId);
        private readonly ForeignKey<LHBEntityBuilder> _moduleForeignKey = new("FK_OELHB_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public LHBEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override LHBEntityBuilder BuildTable(ColumnsBuilder table)
        {
            LHBId = AddAutoIncrementColumn(table,"LHBId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> LHBId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
