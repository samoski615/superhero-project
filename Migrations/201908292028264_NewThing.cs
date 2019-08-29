namespace SuperHeroProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewThing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Superheroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        superHeroName = c.String(),
                        alterEgo = c.String(),
                        primaryAbility = c.String(),
                        secondaryAbility = c.String(),
                        catchphrase = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.People");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Superheroes");
        }
    }
}
