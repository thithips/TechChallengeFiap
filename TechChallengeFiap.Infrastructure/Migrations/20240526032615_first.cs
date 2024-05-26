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
                    Regioes = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("667589e6-12e3-44de-86cb-141058365c78"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(2812), "Sul" },
                    { new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(2807), "Sudeste" },
                    { new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(2810), "Nordeste" },
                    { new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(2794), "Centro-oeste" },
                    { new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(2813), "Norte" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "DataCriacao", "Descricao", "IdRegiao", "Uf" },
                values: new object[,]
                {
                    { new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3343), "Para", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "PA" },
                    { new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3363), "Rondonia", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "RO" },
                    { new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3376), "Distrito Federal", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "DF" },
                    { new Guid("20792100-80af-49a8-8195-f7c36441c38d"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3211), "Espirito Santo", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "ES" },
                    { new Guid("275002db-aa62-444e-a179-b801583c3568"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3354), "Piaui", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PI" },
                    { new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3203), "Amazonas", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AM" },
                    { new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3209), "Ceara", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "CE" },
                    { new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3206), "Bahia", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "BA" },
                    { new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3357), "Rio de Janeiro", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "RJ" },
                    { new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3341), "Minas Gerais", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "MG" },
                    { new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3351), "Pernambuco", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PE" },
                    { new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3201), "Amapa", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AP" },
                    { new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3371), "Sao Paulo", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "SP" },
                    { new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3361), "Rio Grande do Sul", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "RS" },
                    { new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3373), "Sergipe", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "SE" },
                    { new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3334), "Maranhao", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "MA" },
                    { new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3142), "Acre", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AC" },
                    { new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3337), "Mato Grosso", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "MT" },
                    { new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3374), "Tocantins", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "TO" },
                    { new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3331), "Goias", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "GO" },
                    { new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3199), "Alagoas", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "AL" },
                    { new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3367), "Roraima", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "RR" },
                    { new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3339), "Mato Grosso do Sul", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "MS" },
                    { new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3346), "Paraiba", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PB" },
                    { new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3369), "Santa Catarina", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "SC" },
                    { new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3359), "Rio Grande do Norte", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "RN" },
                    { new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3349), "Parana", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "PR" }
                });

            migrationBuilder.InsertData(
                table: "DDDs",
                columns: new[] { "Id", "DataCriacao", "IdEstado", "NumeroDDD", "Regioes" },
                values: new object[,]
                {
                    { new Guid("02e1ad04-8864-47ba-8c6f-b25b4de570a6"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3818), new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), (byte)92, "Manaus e Região Metropolitana/Parintins" },
                    { new Guid("04854654-7bba-4100-aee6-7ac5245050e8"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3607), new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), (byte)66, "Rondonópolis/Sinop" },
                    { new Guid("057d7dfc-6b5d-4940-80e3-f1135b8ac616"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3829), new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), (byte)98, "São Luís e Região Metropolitana" },
                    { new Guid("09a9ab5e-c61d-4a02-8046-7a244a412fb8"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3635), new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), (byte)83, "Abrangência em todo o estado" },
                    { new Guid("0de34313-5e80-4233-a369-639883c38d3a"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3637), new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), (byte)84, "Abrangência em todo o estado" },
                    { new Guid("197e3f1c-d3c5-4cf0-8927-8965adeaae51"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3610), new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), (byte)68, "Abrangência em todo o estado" },
                    { new Guid("1c037db6-855b-413d-9aa8-7c45050cf37e"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3633), new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), (byte)82, "Abrangência em todo o estado" },
                    { new Guid("20bc6c47-68e2-4410-ac9c-6778e66bc66e"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3582), new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), (byte)47, "Balneário Camboriú/Blumenau/Itajaí/Joinville" },
                    { new Guid("29cdd496-b0b4-4ab7-902f-0e33cdd031d7"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3827), new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), (byte)97, "Abrangência no interior do estado" },
                    { new Guid("2b52f423-b115-4a0d-9d5f-51ebdf7fea37"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3601), new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), (byte)63, "Abrangência em todo o estado" },
                    { new Guid("2b960d85-3a55-43b3-aac5-a9eab09cde6d"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3629), new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), (byte)81, "Recife e Região Metropolitana/Caruaru" },
                    { new Guid("367c1529-6346-4763-9b23-3a8bdea6afd5"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3570), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)42, "Ponta Grossa/Guarapuava" },
                    { new Guid("373001b7-7005-4ea8-bcca-09bf7fe0942a"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3623), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)75, "Alagoinhas/Feira de Santana/Paulo Afonso/Valença" },
                    { new Guid("385f9187-739d-49bc-8914-1dbf883c1ecf"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3599), new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), (byte)62, "Goiânia e Região Metropolitana/Anápolis/Niquelândia/Porangatu" },
                    { new Guid("3abd3da1-3e4d-48b3-af80-853d395313d2"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3598), new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), (byte)61, "Abrangência em todo o Distrito Federal e alguns municípios da Região Integrada de Desenvolvimento do Distrito Federal e Entorno" },
                    { new Guid("3c6c40d0-7e6f-4b79-a0ae-314b50830b4d"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3524), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)13, "Região Metropolitana da Baixada Santista/Vale do Ribeira" },
                    { new Guid("41d561fc-5afe-44bb-a250-848d53d431e3"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3615), new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), (byte)69, "Abrangência em todo o estado" },
                    { new Guid("42b7d2ec-2ac0-4453-ac13-8f33efed2ce8"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3825), new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), (byte)96, "Abrangência em todo o estado" },
                    { new Guid("439de6c8-40ec-4cf1-8dd8-f12af22c74a3"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3501), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)11, "Região Metropolitana de São Paulo/Região Metropolitana de Jundiaí/Região Geográfica Imediata de Bragança Paulista" },
                    { new Guid("441c0f76-c9ed-43b6-a8f5-8b454f174c2a"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3608), new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), (byte)67, "Abrangência em todo o estado" },
                    { new Guid("45da1ab1-4ef9-4d97-af9d-e5463b08ade0"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3558), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)34, "Araguari/Araxá/Patos de Minas/Uberlândia/Uberaba" },
                    { new Guid("48f1fc6a-ec77-49e7-acfb-0877cac2f43b"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3823), new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), (byte)95, "Abrangência em todo o estado" },
                    { new Guid("49a3ed4f-984d-480c-a9dc-807087d7c360"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3588), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)51, "Porto Alegre e Região Metropolitana/Santa Cruz do Sul/Litoral Norte" },
                    { new Guid("4e355170-85eb-4a78-bd15-f32a53eb5e02"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3811), new Guid("275002db-aa62-444e-a179-b801583c3568"), (byte)89, "Picos/Floriano" },
                    { new Guid("58d5c341-003e-426c-ab56-b7f072a524c1"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3576), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)45, "Cascavel/Foz do Iguaçu" },
                    { new Guid("5cc42d37-dce8-4535-becd-530509a75b2e"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3603), new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), (byte)64, "Caldas Novas/Catalão/Itumbiara/Rio Verde" },
                    { new Guid("60dd1ef9-dfe7-4148-a865-2979804fc4e7"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3533), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)17, "Barretos/Catanduva/Fernandópolis/Jales/São José do Rio Preto/Votuporanga" },
                    { new Guid("62a78dda-1ce8-4911-8ab1-28d9a9ec072b"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3617), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)71, "Salvador e Região Metropolitana" },
                    { new Guid("680f8cac-5a16-4f50-b690-5ec1579bd086"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3535), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)18, "Andradina/Araçatuba/Assis/Birigui/Dracena/Presidente Prudente" },
                    { new Guid("69822f11-508f-4abf-aacd-fa157a1a5d24"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3821), new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), (byte)94, "Marabá" },
                    { new Guid("698c7336-83c6-4f79-a2a0-75bfd84a0612"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3621), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)74, "Irecê/Jacobina/Juazeiro/Xique-Xique" },
                    { new Guid("6d1e12e1-498a-41f9-b19e-d495c7c10ad8"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3537), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)19, "Americana/Campinas/Limeira/Piracicaba/Rio Claro/São João da Boa Vista" },
                    { new Guid("74ffc337-9ad0-4fdb-9241-0f0a31f92e7b"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3627), new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), (byte)79, "Abrangência em todo o estado " },
                    { new Guid("76cd09a8-44e4-421f-9cd9-782f4b7074f5"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3531), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)16, "Araraquara/Franca/Jaboticabal/Ribeirão Preto/São Carlos/Sertãozinho" },
                    { new Guid("7cb2b49c-fecc-4b42-a38b-6574092b1796"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3549), new Guid("20792100-80af-49a8-8195-f7c36441c38d"), (byte)27, "Vitória e Região Metropolitana/Colatina/Linhares/Santa Maria de Jetibá" },
                    { new Guid("7d95620f-b6d6-409c-9101-155f63020280"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3639), new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), (byte)85, "Fortaleza e Região Metropolitana" },
                    { new Guid("87828884-78e2-4734-b32d-28cc98676095"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3547), new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), (byte)24, "Angra dos Reis/Petrópolis/Volta Redonda/Piraí" },
                    { new Guid("8ff01699-4e7f-4a6c-bf6d-0eee3058ad16"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3552), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)31, "Belo Horizonte e Região Metropolitana/Conselheiro Lafaiete/Ipatinga/Viçosa" },
                    { new Guid("91d6f37a-8955-4165-95ff-619cc3204c5c"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3625), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)77, "Barreiras/Bom Jesus da Lapa/Guanambi/Vitória da Conquista" },
                    { new Guid("952e2874-a022-41c5-9ebb-4ac0439db43b"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3833), new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), (byte)99, "Caxias/Codó/Imperatriz" },
                    { new Guid("9ae135c7-7990-4a26-b5cd-ceabbc1243fa"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3589), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)53, "Pelotas/Rio Grande" },
                    { new Guid("9ca3d698-a85d-49a7-b2dd-f148fa4236ad"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3545), new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), (byte)22, "Cabo Frio/Campos dos Goytacazes/Itaperuna/Macaé/Nova Friburgo" },
                    { new Guid("9d2555e5-ddef-44bd-a1b7-25afb35ad0aa"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3807), new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), (byte)87, "Garanhuns/Petrolina/Salgueiro/Serra Talhada" },
                    { new Guid("9d898860-ff36-4879-bab3-0d914e8a1d70"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3565), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)37, "Bom Despacho/Divinópolis/Formiga/Itaúna/Pará de Minas" },
                    { new Guid("a110e050-c6ef-442e-aadd-55e9151ec437"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3605), new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), (byte)65, "Cuiabá e Região Metropolitana" },
                    { new Guid("a3d9ad82-b216-436e-ad25-80cc01d76262"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3572), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)43, "Apucarana/Londrina" },
                    { new Guid("a684ff9b-52b9-4799-b3e5-7697cc8385e6"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3503), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)12, "Região Metropolitana do Vale do Paraíba e Litoral Norte" },
                    { new Guid("a8597729-c84e-4638-b90e-bcc5c96cb9ee"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3816), new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), (byte)91, "Belém e Região Metropolitana" },
                    { new Guid("b23f3b37-e61c-407f-bf42-1ba1455a5f05"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3619), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)73, "Eunápolis/Ilhéus/Porto Seguro/Teixeira de Freitas" },
                    { new Guid("b62b2ebb-5983-4779-937a-34cd069df00a"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3640), new Guid("275002db-aa62-444e-a179-b801583c3568"), (byte)86, "Teresina e alguns municípios da Região Integrada de Desenvolvimento da Grande Teresina/Parnaíba" },
                    { new Guid("b94f80d3-d344-480f-a721-c942f0a00092"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3574), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)44, "Maringá/Campo Mourão/Umuarama" },
                    { new Guid("be8c0883-9fd4-42b1-ae0c-a6042af52c3e"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3568), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)41, "Curitiba e Região Metropolitana" },
                    { new Guid("bf135b2e-375a-4b57-83b6-29abcbc24d50"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3551), new Guid("20792100-80af-49a8-8195-f7c36441c38d"), (byte)28, "Cachoeiro de Itapemirim/Castelo/Itapemirim/Marataízes" },
                    { new Guid("c06a393f-aee2-407d-959a-baafec2847fa"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3539), new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), (byte)21, "Rio de Janeiro e Região Metropolitana/Teresópolis" },
                    { new Guid("c2f4930b-52e1-43da-ba33-e274ed981db3"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3566), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)38, "Curvelo/Diamantina/Montes Claros/Pirapora/Unaí" },
                    { new Guid("c402126c-fc7c-4a63-a1bf-e4d663b0e399"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3563), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)35, "Alfenas/Guaxupé/Lavras/Poços de Caldas/Pouso Alegre/Varginha" },
                    { new Guid("c4586c16-1d0e-4758-b78a-c96de16c987e"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3820), new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), (byte)93, "Santarém/Altamira" },
                    { new Guid("cc438caf-5a67-4720-8207-8021b3313abf"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3809), new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), (byte)88, "Juazeiro do Norte/Sobral" },
                    { new Guid("cca7e169-d418-4637-904b-4a79ac365e50"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3527), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)14, "Avaré/Bauru/Botucatu/Jaú/Lins/Marília/Ourinhos" },
                    { new Guid("cf0319b9-66e8-44aa-a247-48fd35d1896e"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3593), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)55, "Santa Maria/Santana do Livramento/Santo Ângelo/Uruguaiana" },
                    { new Guid("cf54e994-6eaf-442d-ab5f-59046e52c766"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3556), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)33, "Almenara/Caratinga/Governador Valadares/Manhuaçu/Teófilo Otoni" },
                    { new Guid("d414cbac-8ed9-4d87-8c50-5f17e9194e15"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3580), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)46, "Francisco Beltrão/Pato Branco" },
                    { new Guid("d587b2db-ff18-4e27-9922-1cfe4dd433b4"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3591), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)54, "Caxias do Sul/Passo Fundo" },
                    { new Guid("e88e04b4-ddb5-47b0-b54b-ab35b77a2889"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3528), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)15, "Itapetininga/Itapeva/Sorocaba/Tatuí" },
                    { new Guid("ea83f9e6-e2bc-4dc6-a8ac-d58b4441af54"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3584), new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), (byte)48, "Florianópolis e Região Metropolitana/Criciúma" },
                    { new Guid("f1d7e2e1-e658-4047-8071-17f77a7ebe45"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3555), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)32, "Barbacena/Juiz de Fora/Muriaé/São João del-Rei/Ubá" },
                    { new Guid("f88343ba-a706-4f81-9554-1a1d02cb106a"), new DateTime(2024, 5, 26, 0, 26, 14, 390, DateTimeKind.Local).AddTicks(3586), new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), (byte)49, "Caçador/Chapecó/Lages" }
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
