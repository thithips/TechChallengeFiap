using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechChallengeFiap.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regioes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regioes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    IdRegiao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Regioes_IdRegiao",
                        column: x => x.IdRegiao,
                        principalTable: "Regioes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DDDs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroDDD = table.Column<byte>(type: "tinyint", nullable: false),
                    IdEstado = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDDs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DDDs_Estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    IdDDD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatos_DDDs_IdDDD",
                        column: x => x.IdDDD,
                        principalTable: "DDDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regioes",
                columns: new[] { "Id", "DataCriacao", "Descricao" },
                values: new object[,]
                {
                    { new Guid("667589e6-12e3-44de-86cb-141058365c78"), new DateTime(2024, 5, 19, 20, 47, 26, 876, DateTimeKind.Local).AddTicks(1853), "Sul" },
                    { new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), new DateTime(2024, 5, 19, 20, 47, 26, 876, DateTimeKind.Local).AddTicks(1850), "Sudeste" },
                    { new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), new DateTime(2024, 5, 19, 20, 47, 26, 876, DateTimeKind.Local).AddTicks(1852), "Nordeste" },
                    { new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), new DateTime(2024, 5, 19, 20, 47, 26, 876, DateTimeKind.Local).AddTicks(1832), "Centro-oeste" },
                    { new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), new DateTime(2024, 5, 19, 20, 47, 26, 876, DateTimeKind.Local).AddTicks(1855), "Norte" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "DataCriacao", "Descricao", "IdRegiao", "Uf" },
                values: new object[,]
                {
                    { new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Para", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "PA" },
                    { new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rondonia", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "RO" },
                    { new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Distrito Federal", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "DF" },
                    { new Guid("20792100-80af-49a8-8195-f7c36441c38d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Espirito Santo", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "ES" },
                    { new Guid("275002db-aa62-444e-a179-b801583c3568"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piaui", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PI" },
                    { new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amazonas", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AM" },
                    { new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceara", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "CE" },
                    { new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahia", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "BA" },
                    { new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rio de Janeiro", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "RJ" },
                    { new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minas Gerais", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "MG" },
                    { new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pernambuco", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PE" },
                    { new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amapa", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AP" },
                    { new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sao Paulo", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "SP" },
                    { new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rio Grande do Sul", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "RS" },
                    { new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergipe", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "SE" },
                    { new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maranhao", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "MA" },
                    { new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acre", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AC" },
                    { new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mato Grosso", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "MT" },
                    { new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tocantins", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "TO" },
                    { new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Goias", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "GO" },
                    { new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alagoas", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "AL" },
                    { new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roraima", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "RR" },
                    { new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mato Grosso do Sul", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "MS" },
                    { new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paraiba", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PB" },
                    { new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Santa Catarina", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "SC" },
                    { new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rio Grande do Norte", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "RN" },
                    { new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parana", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "PR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_IdDDD",
                table: "Contatos",
                column: "IdDDD");

            migrationBuilder.CreateIndex(
                name: "IX_DDDs_IdEstado",
                table: "DDDs",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_IdRegiao",
                table: "Estados",
                column: "IdRegiao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "DDDs");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Regioes");
        }
    }
}
