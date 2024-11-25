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
                    { new Guid("667589e6-12e3-44de-86cb-141058365c78"), new DateTime(2024, 11, 25, 10, 24, 6, 130, DateTimeKind.Local).AddTicks(8138), "Sul" },
                    { new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), new DateTime(2024, 11, 25, 10, 24, 6, 130, DateTimeKind.Local).AddTicks(8114), "Sudeste" },
                    { new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), new DateTime(2024, 11, 25, 10, 24, 6, 130, DateTimeKind.Local).AddTicks(8137), "Nordeste" },
                    { new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), new DateTime(2024, 11, 25, 10, 24, 6, 129, DateTimeKind.Local).AddTicks(3945), "Centro-oeste" },
                    { new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), new DateTime(2024, 11, 25, 10, 24, 6, 130, DateTimeKind.Local).AddTicks(8139), "Norte" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "DataCriacao", "Descricao", "IdRegiao", "Uf" },
                values: new object[,]
                {
                    { new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9487), "Para", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "PA" },
                    { new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9495), "Rondonia", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "RO" },
                    { new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9501), "Distrito Federal", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "DF" },
                    { new Guid("20792100-80af-49a8-8195-f7c36441c38d"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9479), "Espirito Santo", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "ES" },
                    { new Guid("275002db-aa62-444e-a179-b801583c3568"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9491), "Piaui", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PI" },
                    { new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9474), "Amazonas", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AM" },
                    { new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9476), "Ceara", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "CE" },
                    { new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9475), "Bahia", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "BA" },
                    { new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9492), "Rio de Janeiro", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "RJ" },
                    { new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9485), "Minas Gerais", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "MG" },
                    { new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9490), "Pernambuco", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PE" },
                    { new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9462), "Amapa", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AP" },
                    { new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9498), "Sao Paulo", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "SP" },
                    { new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9494), "Rio Grande do Sul", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "RS" },
                    { new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9499), "Sergipe", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "SE" },
                    { new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9482), "Maranhao", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "MA" },
                    { new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9445), "Acre", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AC" },
                    { new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9483), "Mato Grosso", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "MT" },
                    { new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9500), "Tocantins", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "TO" },
                    { new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9481), "Goias", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "GO" },
                    { new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9461), "Alagoas", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "AL" },
                    { new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9496), "Roraima", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "RR" },
                    { new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9484), "Mato Grosso do Sul", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "MS" },
                    { new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9488), "Paraiba", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PB" },
                    { new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9497), "Santa Catarina", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "SC" },
                    { new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9493), "Rio Grande do Norte", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "RN" },
                    { new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), new DateTime(2024, 11, 25, 10, 24, 6, 131, DateTimeKind.Local).AddTicks(9489), "Parana", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "PR" }
                });

            migrationBuilder.InsertData(
                table: "DDDs",
                columns: new[] { "Id", "DataCriacao", "IdEstado", "NumeroDDD", "Regioes" },
                values: new object[,]
                {
                    { new Guid("02aa05d4-2f75-4d1a-bb6f-d3b4c2b81c3f"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3263), new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), (byte)93, "Santarém/Altamira" },
                    { new Guid("0575d1dd-d7f8-42fd-b559-f894b0098e1b"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3159), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)44, "Maringá/Campo Mourão/Umuarama" },
                    { new Guid("0cb3b87a-3105-4e2c-81a0-2bbffb6ce9db"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3257), new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), (byte)87, "Garanhuns/Petrolina/Salgueiro/Serra Talhada" },
                    { new Guid("1304c362-3ad3-4033-8755-d9cd1d17c66a"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3122), new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), (byte)24, "Angra dos Reis/Petrópolis/Volta Redonda/Piraí" },
                    { new Guid("134d7041-39f7-4f56-a099-9e8a6c2c623f"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3175), new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), (byte)64, "Caldas Novas/Catalão/Itumbiara/Rio Verde" },
                    { new Guid("142d5752-1444-433e-94a2-a2178a1c5951"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3094), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)13, "Região Metropolitana da Baixada Santista/Vale do Ribeira" },
                    { new Guid("1524bc54-cf16-41a7-b63e-14a1f51620e5"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3097), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)15, "Itapetininga/Itapeva/Sorocaba/Tatuí" },
                    { new Guid("1937b120-ee8c-475a-883e-29bd019d5c70"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3260), new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), (byte)91, "Belém e Região Metropolitana" },
                    { new Guid("1abada34-1017-421a-aecb-2bc23c424680"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3148), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)33, "Almenara/Caratinga/Governador Valadares/Manhuaçu/Teófilo Otoni" },
                    { new Guid("1e72df46-ce39-47ff-a9df-a1912622a0d1"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3240), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)71, "Salvador e Região Metropolitana" },
                    { new Guid("269760a5-cfd1-43a4-a1ec-f76068ec545a"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3124), new Guid("20792100-80af-49a8-8195-f7c36441c38d"), (byte)28, "Cachoeiro de Itapemirim/Castelo/Itapemirim/Marataízes" },
                    { new Guid("28af2552-4264-495e-8547-5156cb9c3594"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3250), new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), (byte)82, "Abrangência em todo o estado" },
                    { new Guid("292b8323-8557-4da6-a0c9-e0820b294019"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3271), new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), (byte)98, "São Luís e Região Metropolitana" },
                    { new Guid("304cefaf-8a51-4bee-a1c0-94ba34d615bc"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3272), new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), (byte)99, "Caxias/Codó/Imperatriz" },
                    { new Guid("30943f08-faee-4f23-b31c-ddab7d713778"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3174), new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), (byte)63, "Abrangência em todo o estado" },
                    { new Guid("33e6934b-d850-43f2-ba69-a3f17546967e"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3251), new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), (byte)83, "Abrangência em todo o estado" },
                    { new Guid("33ff9023-c6cc-4d53-aa20-f0c01b5eb718"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3164), new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), (byte)48, "Florianópolis e Região Metropolitana/Criciúma" },
                    { new Guid("38ae2e59-fa2e-4f96-adf6-f5a7d4a39378"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3117), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)18, "Andradina/Araçatuba/Assis/Birigui/Dracena/Presidente Prudente" },
                    { new Guid("4654c36c-b62f-43b8-9dd5-a10795cb28be"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3149), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)34, "Araguari/Araxá/Patos de Minas/Uberlândia/Uberaba" },
                    { new Guid("4d83d495-584c-41f8-9b1f-146a482cacbe"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3249), new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), (byte)81, "Recife e Região Metropolitana/Caruaru" },
                    { new Guid("4ecb7510-4f4b-4997-a033-0e024e50455c"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3235), new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), (byte)66, "Rondonópolis/Sinop" },
                    { new Guid("4f12ca3c-1905-4e2c-a7dc-0f6d1e3644e6"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3166), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)51, "Porto Alegre e Região Metropolitana/Santa Cruz do Sul/Litoral Norte" },
                    { new Guid("50190de0-90e2-4ba3-9aab-9270aeef4783"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3246), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)77, "Barreiras/Bom Jesus da Lapa/Guanambi/Vitória da Conquista" },
                    { new Guid("57d89a9c-0b82-4825-b7f1-eb35a082e2b9"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3165), new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), (byte)49, "Caçador/Chapecó/Lages" },
                    { new Guid("599d40b6-7c02-43e9-9bcc-879978967036"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3254), new Guid("275002db-aa62-444e-a179-b801583c3568"), (byte)86, "Teresina e alguns municípios da Região Integrada de Desenvolvimento da Grande Teresina/Parnaíba" },
                    { new Guid("634c3d8c-966e-48b0-9c61-1cafa5e4a4e2"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3125), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)31, "Belo Horizonte e Região Metropolitana/Conselheiro Lafaiete/Ipatinga/Viçosa" },
                    { new Guid("6387c241-42c5-4059-8a0d-cedd0882447f"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3090), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)12, "Região Metropolitana do Vale do Paraíba e Litoral Norte" },
                    { new Guid("72f9d618-a8ca-4c81-bf3c-fdc676d81631"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3150), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)35, "Alfenas/Guaxupé/Lavras/Poços de Caldas/Pouso Alegre/Varginha" },
                    { new Guid("76540171-4315-4536-a0f4-89df61fcead4"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3151), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)37, "Bom Despacho/Divinópolis/Formiga/Itaúna/Pará de Minas" },
                    { new Guid("808802c6-d1e2-417f-a0cc-90a7641119e5"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3258), new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), (byte)88, "Juazeiro do Norte/Sobral" },
                    { new Guid("83458537-402c-4e14-8494-89628740260e"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3095), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)14, "Avaré/Bauru/Botucatu/Jaú/Lins/Marília/Ourinhos" },
                    { new Guid("87f16367-4e05-49b5-9230-c24d6512c339"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3099), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)17, "Barretos/Catanduva/Fernandópolis/Jales/São José do Rio Preto/Votuporanga" },
                    { new Guid("8af47707-a87b-4fa8-9c5b-9bbf6a089ec3"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3238), new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), (byte)68, "Abrangência em todo o estado" },
                    { new Guid("8bde5c11-51f1-4073-a6a9-62708a3547fc"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3158), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)43, "Apucarana/Londrina" },
                    { new Guid("8d18b14e-f7d6-4765-b04f-03814e864741"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3253), new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), (byte)85, "Fortaleza e Região Metropolitana" },
                    { new Guid("8fcf08f1-ece7-4ded-9888-44485332074a"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3153), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)41, "Curitiba e Região Metropolitana" },
                    { new Guid("908c66f0-022e-4d35-b2a1-34ac5716c368"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3172), new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), (byte)61, "Abrangência em todo o Distrito Federal e alguns municípios da Região Integrada de Desenvolvimento do Distrito Federal e Entorno" },
                    { new Guid("92cd7723-0387-4808-8d96-dc605a8fd2ce"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3162), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)46, "Francisco Beltrão/Pato Branco" },
                    { new Guid("942bb321-7cd9-4f71-92b3-9be112d478ef"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3121), new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), (byte)22, "Cabo Frio/Campos dos Goytacazes/Itaperuna/Macaé/Nova Friburgo" },
                    { new Guid("979bd6ad-69a9-4426-b1c2-6622d1d403c3"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3171), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)55, "Santa Maria/Santana do Livramento/Santo Ângelo/Uruguaiana" },
                    { new Guid("9b183551-4b8c-4e7c-b8f1-87958b8c2354"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3247), new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), (byte)79, "Abrangência em todo o estado " },
                    { new Guid("9b74e431-eac7-47bd-b39f-79bc1e52a608"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3152), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)38, "Curvelo/Diamantina/Montes Claros/Pirapora/Unaí" },
                    { new Guid("9e74b619-1b18-4812-ad82-6052d735f37b"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3169), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)53, "Pelotas/Rio Grande" },
                    { new Guid("a5d93110-3698-4718-b0a8-2adb5f479926"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3123), new Guid("20792100-80af-49a8-8195-f7c36441c38d"), (byte)27, "Vitória e Região Metropolitana/Colatina/Linhares/Santa Maria de Jetibá" },
                    { new Guid("a6e8354e-d258-451c-a17a-09c425823cc6"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3237), new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), (byte)67, "Abrangência em todo o estado" },
                    { new Guid("a721fd1f-3757-4528-9d4b-8e1039f868da"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3265), new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), (byte)95, "Abrangência em todo o estado" },
                    { new Guid("ab5ed1cd-122a-411e-bd8c-299d33874e2a"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3262), new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), (byte)92, "Manaus e Região Metropolitana/Parintins" },
                    { new Guid("ac44c0c4-9edc-4776-849f-c8001d9015cf"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3120), new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), (byte)21, "Rio de Janeiro e Região Metropolitana/Teresópolis" },
                    { new Guid("acc94e08-ba6d-4b40-a970-27d94b9aceb1"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3242), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)74, "Irecê/Jacobina/Juazeiro/Xique-Xique" },
                    { new Guid("ad340b9f-2d88-4273-b1a2-3b3dc5385dd2"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3161), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)45, "Cascavel/Foz do Iguaçu" },
                    { new Guid("b4e0321d-10f3-4624-b749-310f5bd77f6a"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3170), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)54, "Caxias do Sul/Passo Fundo" },
                    { new Guid("b90c3e19-8937-4c50-9c7b-f715ff51ef8d"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3154), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)42, "Ponta Grossa/Guarapuava" },
                    { new Guid("c0223bde-7630-4407-b1bf-c471e9dc0025"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3119), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)19, "Americana/Campinas/Limeira/Piracicaba/Rio Claro/São João da Boa Vista" },
                    { new Guid("cfdf25a6-0283-4ea0-9445-eb65697a08fd"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(2260), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)11, "Região Metropolitana de São Paulo/Região Metropolitana de Jundiaí/Região Geográfica Imediata de Bragança Paulista" },
                    { new Guid("d13e8bc1-a5d1-466c-89c7-a6ed28b00d2a"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3269), new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), (byte)97, "Abrangência no interior do estado" },
                    { new Guid("d3260b19-27bc-4003-b4be-111a5d5f410e"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3239), new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), (byte)69, "Abrangência em todo o estado" },
                    { new Guid("d33059b3-4573-49e4-963e-4f95ea19350f"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3259), new Guid("275002db-aa62-444e-a179-b801583c3568"), (byte)89, "Picos/Floriano" },
                    { new Guid("d7bda7c7-7593-4d8d-ad3b-c7aeabe19392"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3173), new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), (byte)62, "Goiânia e Região Metropolitana/Anápolis/Niquelândia/Porangatu" },
                    { new Guid("de12088e-f97d-4d97-a160-10175c263441"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3241), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)73, "Eunápolis/Ilhéus/Porto Seguro/Teixeira de Freitas" },
                    { new Guid("e700c07f-e618-4756-a98d-1b419a130ae2"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3268), new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), (byte)96, "Abrangência em todo o estado" },
                    { new Guid("eabbb20d-2fb6-48b5-88c2-92f8b6cb8aa7"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3264), new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), (byte)94, "Marabá" },
                    { new Guid("eee1d32b-05cc-4337-a024-5056ecb33783"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3243), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)75, "Alagoinhas/Feira de Santana/Paulo Afonso/Valença" },
                    { new Guid("f11bb190-7e89-44f7-9854-a88310026946"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3147), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)32, "Barbacena/Juiz de Fora/Muriaé/São João del-Rei/Ubá" },
                    { new Guid("f26268b7-4d58-4f06-b1b3-5f96cc39c9d2"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3252), new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), (byte)84, "Abrangência em todo o estado" },
                    { new Guid("f2e00707-65fd-43f4-ac20-50300026557a"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3163), new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), (byte)47, "Balneário Camboriú/Blumenau/Itajaí/Joinville" },
                    { new Guid("f3dbd667-61c7-4012-add3-ca8e179fbc5d"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3176), new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), (byte)65, "Cuiabá e Região Metropolitana" },
                    { new Guid("fb411b16-bd51-4e05-b072-6423e4209f1c"), new DateTime(2024, 11, 25, 10, 24, 6, 133, DateTimeKind.Local).AddTicks(3098), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)16, "Araraquara/Franca/Jaboticabal/Ribeirão Preto/São Carlos/Sertãozinho" }
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
