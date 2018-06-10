namespace ResidenceAdmin.Persistency.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountingInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Stage = c.String(),
                        Caracteristic = c.String(),
                        PaymentType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Number = c.Int(nullable: false),
                        City = c.String(),
                        District = c.String(),
                        Bloc = c.String(),
                        Entrance = c.String(),
                        Apartment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Content = c.String(),
                        Employee_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Employee_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmpoyeeCode = c.String(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        Phone = c.String(),
                        Adress_Id = c.Int(),
                        Identity_Id = c.Int(),
                        WorkInfo_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeAddresses", t => t.Adress_Id)
                .ForeignKey("dbo.EmployeeIdentities", t => t.Identity_Id)
                .ForeignKey("dbo.EmployeeWorkInfoes", t => t.WorkInfo_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.Adress_Id)
                .Index(t => t.Identity_Id)
                .Index(t => t.WorkInfo_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.EmployeeIdentities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityCard = c.String(),
                        Uin = c.String(),
                        PlaceOfBirth = c.String(),
                        DateOfBirth = c.String(),
                        MaritalStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeWorkInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOfEmployment = c.DateTime(nullable: false),
                        Interruptions = c.DateTime(nullable: false),
                        SeniorityType = c.Int(nullable: false),
                        Seniority_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Seniorities", t => t.Seniority_Id)
                .Index(t => t.Seniority_Id);
            
            CreateTable(
                "dbo.Seniorities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Years = c.Int(nullable: false),
                        Months = c.Int(nullable: false),
                        Days = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Documents", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Employees", "WorkInfo_Id", "dbo.EmployeeWorkInfoes");
            DropForeignKey("dbo.EmployeeWorkInfoes", "Seniority_Id", "dbo.Seniorities");
            DropForeignKey("dbo.Documents", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Identity_Id", "dbo.EmployeeIdentities");
            DropForeignKey("dbo.Employees", "Adress_Id", "dbo.EmployeeAddresses");
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.EmployeeWorkInfoes", new[] { "Seniority_Id" });
            DropIndex("dbo.Employees", new[] { "User_Id" });
            DropIndex("dbo.Employees", new[] { "WorkInfo_Id" });
            DropIndex("dbo.Employees", new[] { "Identity_Id" });
            DropIndex("dbo.Employees", new[] { "Adress_Id" });
            DropIndex("dbo.Documents", new[] { "User_Id" });
            DropIndex("dbo.Documents", new[] { "Employee_Id" });
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Seniorities");
            DropTable("dbo.EmployeeWorkInfoes");
            DropTable("dbo.EmployeeIdentities");
            DropTable("dbo.Employees");
            DropTable("dbo.Documents");
            DropTable("dbo.EmployeeAddresses");
            DropTable("dbo.AccountingInfoes");
        }
    }
}
