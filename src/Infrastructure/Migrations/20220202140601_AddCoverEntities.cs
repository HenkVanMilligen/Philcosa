using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Philcosa.Infrastructure.Migrations
{
    public partial class AddCoverEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoverIssuers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverIssuers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoverTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoverValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MinValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Covers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOnDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverIssuerId = table.Column<int>(type: "int", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AmountIssued = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Atlas = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Alberta = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CoverTypeId = table.Column<int>(type: "int", nullable: true),
                    ValueId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    ImageDataUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Covers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Covers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Covers_CoverIssuers_CoverIssuerId",
                        column: x => x.CoverIssuerId,
                        principalTable: "CoverIssuers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Covers_CoverTypes_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalTable: "CoverTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Covers_CoverValues_ValueId",
                        column: x => x.ValueId,
                        principalTable: "CoverValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoverThemes",
                columns: table => new
                {
                    CoverId = table.Column<int>(type: "int", nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverThemes", x => new { x.CoverId, x.ThemeId });
                    table.ForeignKey(
                        name: "FK_CoverThemes_Covers_CoverId",
                        column: x => x.CoverId,
                        principalTable: "Covers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoverThemes_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, "VEN", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 483, DateTimeKind.Local).AddTicks(7816), null, null, "Venda" },
                    { 2, "TRA", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 487, DateTimeKind.Local).AddTicks(142), null, null, "Transkei" },
                    { 3, "CIS", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 487, DateTimeKind.Local).AddTicks(164), null, null, "Ciskei" },
                    { 4, "BOP", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 487, DateTimeKind.Local).AddTicks(167), null, null, "Bophuthatswana" },
                    { 5, "SWA", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 487, DateTimeKind.Local).AddTicks(169), null, null, "South West Africa" },
                    { 6, "RSA", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 487, DateTimeKind.Local).AddTicks(171), null, null, "South Africa" },
                    { 7, "NAM", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 487, DateTimeKind.Local).AddTicks(173), null, null, "Namibia" }
                });

            migrationBuilder.InsertData(
                table: "CoverIssuers",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 23, "NAV", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5981), null, null, "SA Navy" },
                    { 24, "FOU", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5995), null, null, "SA Philatelic Foundation" },
                    { 25, "SAP", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6007), null, null, "SA Police" },
                    { 26, "SPO", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6020), null, null, "SA Post Office" },
                    { 27, "SAR", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6034), null, null, "SA Railway Services" },
                    { 28, "SAT", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6046), null, null, "SA Transport Services" },
                    { 29, "SHP", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6059), null, null, "Ship Society of SA" },
                    { 30, "SHS", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6073), null, null, "Simonstown Historical Society" },
                    { 33, "SAA", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6113), null, null, "South African Airways" },
                    { 32, "AER", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6100), null, null, "South African Air Force (Aerobic)" },
                    { 22, "DEF", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5969), null, null, "SA Defence Force" },
                    { 34, "SAM", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6127), null, null, "South African Airways Museum" },
                    { 35, "TRS", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6140), null, null, "The Railway Society" },
                    { 36, "UNN", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6153), null, null, "United Nations" },
                    { 37, "WPH", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6166), null, null, "Warner Pharmaceuticals" },
                    { 38, "WWF", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6369), null, null, "World Wildlife Fund" },
                    { 31, "SNM", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(6086), null, null, "Simonstown Navy Museum" },
                    { 21, "ARM", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5955), null, null, "SA Army" },
                    { 20, "SMW", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5919), null, null, "SA Air Force Museum (World War Series)" },
                    { 6, "FST", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5699), null, null, "Flitestar" },
                    { 1, "APH", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(3673), null, null, "Airphilsa" },
                    { 2, "CAP", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5550), null, null, "Caprivi Airways" },
                    { 3, "FED", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5573), null, null, "Philatelic Federation" },
                    { 4, "GLD", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5595), null, null, "First Day Fabrics (GOLD)" },
                    { 5, "SLK", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5656), null, null, "First Day Fabrics (SILK)" },
                    { 19, "SMS", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5905), null, null, "SA Air Force Museum (Spesials)" },
                    { 8, "KPA", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5729), null, null, "Kempton Park Philatelic Society (Kemp Air)" },
                    { 9, "KPC", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5743), null, null, "Kempton Park Philatelic Society (Kemp kard)" },
                    { 7, "FAL", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5712), null, null, "Foreign Airline" },
                    { 11, "KPM", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5772), null, null, "Kempton Park Philatelic Society (Kemp Maksikard)" },
                    { 12, "NAM", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5789), null, null, "Nam Post" },
                    { 13, "NAA", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5805), null, null, "Namib Air/Air Namibia" },
                    { 14, "NAD", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5824), null, null, "Namib Air/Air Namibia (Delivery flights)" },
                    { 15, "PRV", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5849), null, null, "Private" },
                    { 16, "PRC", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5863), null, null, "Private (Ciskei Handcancelled)" }
                });

            migrationBuilder.InsertData(
                table: "CoverIssuers",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 17, "SMA", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5877), null, null, "SA Air Force Museum (Anniversary Flights)" },
                    { 18, "SMO", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5892), null, null, "SA Air Force Museum (Original Series)" },
                    { 10, "KPK", "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 181, DateTimeKind.Local).AddTicks(5758), null, null, "Kempton Park Philatelic Society (Kemp Kover" }
                });

            migrationBuilder.InsertData(
                table: "CoverTypes",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 8, "BAL", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 488, DateTimeKind.Local).AddTicks(5951), null, null, "Balloon" },
                    { 1, "FDC", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 488, DateTimeKind.Local).AddTicks(5735), null, null, "First Day" },
                    { 2, "CMC", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 488, DateTimeKind.Local).AddTicks(5943), null, null, "Comemorative" },
                    { 3, "FLT", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 488, DateTimeKind.Local).AddTicks(5946), null, null, "Flight" },
                    { 4, "MIL", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 488, DateTimeKind.Local).AddTicks(5948), null, null, "Military" },
                    { 5, "FIL", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 488, DateTimeKind.Local).AddTicks(5949), null, null, "Filatelic" },
                    { 9, "RWY", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 488, DateTimeKind.Local).AddTicks(5953), null, null, "Railway" }
                });

            migrationBuilder.InsertData(
                table: "CoverValues",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "MaxValue", "MinValue" },
                values: new object[,]
                {
                    { 5, "$$$$$", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 489, DateTimeKind.Local).AddTicks(4494), null, null, 500m, 150.01m },
                    { 4, "$$$$", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 489, DateTimeKind.Local).AddTicks(4492), null, null, 150m, 50.01m },
                    { 6, "$$$$$$", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 489, DateTimeKind.Local).AddTicks(4496), null, null, null, 500.01m },
                    { 2, "$$", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 489, DateTimeKind.Local).AddTicks(4427), null, null, 15m, 5.01m },
                    { 3, "$$$", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 489, DateTimeKind.Local).AddTicks(4489), null, null, 50m, 15.01m },
                    { 1, "$", "DataSeed", new DateTime(2022, 2, 2, 16, 5, 59, 489, DateTimeKind.Local).AddTicks(3465), null, null, 5m, 0m }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 61, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4943), null, null, "Maps" },
                    { 86, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5232), null, null, "Rotary International" },
                    { 85, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5221), null, null, "Roses" },
                    { 84, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5209), null, null, "Road Safety" },
                    { 83, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5199), null, null, "Rivers" },
                    { 82, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5188), null, null, "Religion/Churches" },
                    { 81, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5177), null, null, "Red Cross" },
                    { 80, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5165), null, null, "Railway/Trains" },
                    { 79, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5155), null, null, "Presidents and Leaders" },
                    { 78, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5146), null, null, "Postal History" },
                    { 77, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5136), null, null, "Police" },
                    { 76, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5126), null, null, "Platinum" },
                    { 75, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5116), null, null, "Paintings" },
                    { 74, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5105), null, null, "Orchids" },
                    { 72, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5082), null, null, "Nursing" },
                    { 71, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5072), null, null, "National Festivals" },
                    { 70, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5063), null, null, "Music" },
                    { 69, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5053), null, null, "Mushrooms/Fungi" },
                    { 68, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5011), null, null, "Museums" },
                    { 67, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4998), null, null, "Monuments" },
                    { 66, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4989), null, null, "Monkeys and Baboons" },
                    { 65, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4978), null, null, "Mining/Minerals" },
                    { 64, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4969), null, null, "Millenium" },
                    { 63, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4960), null, null, "Military" },
                    { 62, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4951), null, null, "Meteorology/Weather" },
                    { 87, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5243), null, null, "Royals" }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 73, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5095), null, null, "Olympic Games" },
                    { 89, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5267), null, null, "Science and Technology" },
                    { 90, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5279), null, null, "Settlers" },
                    { 60, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4935), null, null, "Manufacturing/Industries" },
                    { 115, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5598), null, null, "Writing/Printing" },
                    { 114, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5585), null, null, "Wildlife" },
                    { 113, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5572), null, null, "Whales/Dolphins/Sharks" },
                    { 112, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5559), null, null, "Waterfalls" },
                    { 111, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5546), null, null, "Water and Sanitation" },
                    { 110, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5534), null, null, "Voortrekkers" },
                    { 109, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5521), null, null, "van Riebeeck" },
                    { 108, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5508), null, null, "UPU" },
                    { 107, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5495), null, null, "United Nations" },
                    { 106, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5482), null, null, "Uniforms/Costumes" },
                    { 105, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5469), null, null, "Unicef" },
                    { 88, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5255), null, null, "Rugby" },
                    { 104, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5455), null, null, "Triangle Stamps" },
                    { 102, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5429), null, null, "Towns/Cities History" },
                    { 101, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5417), null, null, "Tourism" },
                    { 100, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5403), null, null, "Tennis" },
                    { 99, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5390), null, null, "Swimming" },
                    { 98, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5377), null, null, "Stamp on Stamps" },
                    { 97, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5365), null, null, "Stamp Exhibition" },
                    { 96, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5353), null, null, "Stamp Day" },
                    { 95, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5340), null, null, "Sport" },
                    { 94, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5328), null, null, "Spiders" },
                    { 93, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5316), null, null, "Snakes/Lizards/Reptiles" },
                    { 92, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5304), null, null, "Ships/Maritime" },
                    { 91, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5292), null, null, "Shells" },
                    { 103, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5442), null, null, "Transport" },
                    { 59, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4926), null, null, "Mandela" },
                    { 30, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4698), null, null, "Education" },
                    { 57, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4908), null, null, "Lions International" },
                    { 26, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4596), null, null, "Dinosaurs/Fossils/Archaeology" },
                    { 25, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4588), null, null, "Definitive Series" },
                    { 24, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4583), null, null, "Cricket" },
                    { 23, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4576), null, null, "Constitution" },
                    { 22, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4570), null, null, "Community Services" },
                    { 21, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4564), null, null, "Communication" },
                    { 20, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4557), null, null, "Christmas" },
                    { 19, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4551), null, null, "Child Paintings" },
                    { 18, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4544), null, null, "Child" }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 17, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4537), null, null, "Cats/Dogs" },
                    { 16, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4530), null, null, "Cars" },
                    { 15, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4524), null, null, "Butterflies" },
                    { 27, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4603), null, null, "Diplomacy" },
                    { 14, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4519), null, null, "Bridges/Dams" },
                    { 12, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4507), null, null, "Boxing" },
                    { 11, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4501), null, null, "Boer War" },
                    { 10, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4495), null, null, "Birds/Bats" },
                    { 9, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4479), null, null, "Balloon Flights" },
                    { 8, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4462), null, null, "Atletics" },
                    { 7, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4450), null, null, "Astronomy/Space" },
                    { 6, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4446), null, null, "Arts/Culture/Traditions" },
                    { 5, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4420), null, null, "Architecture" },
                    { 4, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4413), null, null, "Apartheid" },
                    { 3, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4408), null, null, "Antarctica" },
                    { 2, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4397), null, null, "Agriculture/Farming" },
                    { 1, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(2983), null, null, "Afrikaans language" },
                    { 13, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4513), null, null, "Boy Scouts/Girl Guides" },
                    { 58, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4916), null, null, "Literature/Writers" },
                    { 28, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4610), null, null, "Disabled" },
                    { 116, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5611), null, null, "WWF" },
                    { 56, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4900), null, null, "Law" },
                    { 55, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4891), null, null, "Landscapes/Nature" },
                    { 54, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4883), null, null, "ITU" },
                    { 53, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4875), null, null, "Insects/Bees" },
                    { 52, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4867), null, null, "Horses/Equestrian" },
                    { 51, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4859), null, null, "Heraldry/Coat of Arms" },
                    { 50, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4852), null, null, "Health/Medicine" },
                    { 49, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4844), null, null, "Hares/Rabbits" },
                    { 48, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4835), null, null, "Grasses" },
                    { 47, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4828), null, null, "Government and Politics" },
                    { 46, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4822), null, null, "Golf" },
                    { 45, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4816), null, null, "Geology" },
                    { 29, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4666), null, null, "Easter" },
                    { 44, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4809), null, null, "Gem Stones/Jewels" },
                    { 42, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4797), null, null, "Frogs" },
                    { 41, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4791), null, null, "Forts and Castles" },
                    { 40, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4784), null, null, "Forestry/Trees" },
                    { 39, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4777), null, null, "Football/Soccer" },
                    { 38, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4770), null, null, "Food and Drink" },
                    { 37, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4764), null, null, "Flora/Flowers" },
                    { 36, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4758), null, null, "Flight and Aircraft" }
                });

            migrationBuilder.InsertData(
                table: "Themes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "LastModifiedBy", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { 35, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4747), null, null, "Flags" },
                    { 34, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4740), null, null, "Fishing/Angling" },
                    { 33, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4733), null, null, "Fish and Marine Life" },
                    { 32, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4727), null, null, "Famous Persons" },
                    { 31, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4721), null, null, "Energy" },
                    { 43, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(4803), null, null, "Fruit/Vegetables" },
                    { 117, "DataSeed", new DateTime(2022, 2, 2, 16, 6, 1, 147, DateTimeKind.Local).AddTicks(5655), null, null, "Chinese year theme" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Covers_CountryId",
                table: "Covers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_CoverIssuerId",
                table: "Covers",
                column: "CoverIssuerId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_CoverTypeId",
                table: "Covers",
                column: "CoverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Covers_ValueId",
                table: "Covers",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_CoverThemes_ThemeId",
                table: "CoverThemes",
                column: "ThemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverThemes");

            migrationBuilder.DropTable(
                name: "Covers");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CoverIssuers");

            migrationBuilder.DropTable(
                name: "CoverTypes");

            migrationBuilder.DropTable(
                name: "CoverValues");
        }
    }
}
