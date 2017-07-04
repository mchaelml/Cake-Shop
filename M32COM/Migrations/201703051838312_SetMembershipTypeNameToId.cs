namespace M32COM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMembershipTypeNameToId : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes Set name = 'Pay as You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes Set name = 'Monthly' WHERE Id = 2");
            Sql("UPDATE MembershipTypes Set name = 'Quarterly' WHERE Id = 3");
            Sql("UPDATE MembershipTypes Set name = 'Annually' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
