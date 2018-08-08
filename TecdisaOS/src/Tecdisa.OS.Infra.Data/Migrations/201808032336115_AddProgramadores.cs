namespace Tecdisa.OS.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProgramadores : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Programadores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Programadores");
        }
    }
}
