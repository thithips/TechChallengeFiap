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
                    { new Guid("667589e6-12e3-44de-86cb-141058365c78"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(3999), "Sul" },
                    { new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(3996), "Sudeste" },
                    { new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(3998), "Nordeste" },
                    { new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(3981), "Centro-oeste" },
                    { new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4002), "Norte" }
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "Id", "DataCriacao", "Descricao", "IdRegiao", "Uf" },
                values: new object[,]
                {
                    { new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4222), "Para", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "PA" },
                    { new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4237), "Rondonia", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "RO" },
                    { new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4248), "Distrito Federal", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "DF" },
                    { new Guid("20792100-80af-49a8-8195-f7c36441c38d"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4211), "Espirito Santo", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "ES" },
                    { new Guid("275002db-aa62-444e-a179-b801583c3568"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4230), "Piaui", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PI" },
                    { new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4205), "Amazonas", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AM" },
                    { new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4209), "Ceara", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "CE" },
                    { new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4207), "Bahia", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "BA" },
                    { new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4232), "Rio de Janeiro", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "RJ" },
                    { new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4220), "Minas Gerais", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "MG" },
                    { new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4228), "Pernambuco", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PE" },
                    { new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4203), "Amapa", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AP" },
                    { new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4243), "Sao Paulo", new Guid("6fb578f8-5176-4906-a805-3a100adde0c9"), "SP" },
                    { new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4236), "Rio Grande do Sul", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "RS" },
                    { new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4245), "Sergipe", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "SE" },
                    { new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4215), "Maranhao", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "MA" },
                    { new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4199), "Acre", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "AC" },
                    { new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4217), "Mato Grosso", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "MT" },
                    { new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4246), "Tocantins", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "TO" },
                    { new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4213), "Goias", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "GO" },
                    { new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4201), "Alagoas", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "AL" },
                    { new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4239), "Roraima", new Guid("91ea2869-3fb0-4c39-8583-f420f8d48fa5"), "RR" },
                    { new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4219), "Mato Grosso do Sul", new Guid("8b985725-487b-4a32-92a5-cb708f44c54b"), "MS" },
                    { new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4224), "Paraiba", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "PB" },
                    { new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4241), "Santa Catarina", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "SC" },
                    { new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4234), "Rio Grande do Norte", new Guid("78fa8876-6c2d-4a09-b981-f77538f18fbb"), "RN" },
                    { new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4226), "Parana", new Guid("667589e6-12e3-44de-86cb-141058365c78"), "PR" }
                });

            migrationBuilder.InsertData(
                table: "DDDs",
                columns: new[] { "Id", "DataCriacao", "IdEstado", "NumeroDDD", "Regioes" },
                values: new object[,]
                {
                    { new Guid("044b0cc3-cff1-4d71-98cd-d8d832df0fbe"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4576), new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), (byte)83, "Abrangência em todo o estado" },
                    { new Guid("0583aa9f-e1f9-4492-b188-44445b037830"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4573), new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), (byte)81, "Recife e Região Metropolitana/Caruaru" },
                    { new Guid("07bd9cf3-34d7-41c3-a031-89922920cb19"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4476), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)16, "Araraquara/Franca/Jaboticabal/Ribeirão Preto/São Carlos/Sertãozinho" },
                    { new Guid("18a9b601-cb3c-42dd-b049-b4bed1eb96f5"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4581), new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), (byte)84, "Abrangência em todo o estado" },
                    { new Guid("1e798bb6-f9ef-40fc-bcff-4ed6c7172618"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4496), new Guid("20792100-80af-49a8-8195-f7c36441c38d"), (byte)28, "Cachoeiro de Itapemirim/Castelo/Itapemirim/Marataízes" },
                    { new Guid("298564f8-674e-4b2a-927f-7e4024200bad"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4583), new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), (byte)85, "Fortaleza e Região Metropolitana" },
                    { new Guid("2ac85176-4291-4198-8133-f8f0d7c87f8d"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4546), new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), (byte)63, "Abrangência em todo o estado" },
                    { new Guid("2bb68928-fe0a-4efc-8316-085f950841db"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4529), new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), (byte)48, "Florianópolis e Região Metropolitana/Criciúma" },
                    { new Guid("2ee9be52-6662-40c6-b598-5c613c059c54"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4514), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)41, "Curitiba e Região Metropolitana" },
                    { new Guid("36c459a9-4c10-4533-b72a-b9dd2bfcf73d"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4507), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)37, "Bom Despacho/Divinópolis/Formiga/Itaúna/Pará de Minas" },
                    { new Guid("37006624-40e5-4fd5-9ae6-ca161c7ec33a"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4535), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)53, "Pelotas/Rio Grande" },
                    { new Guid("38960460-6ea6-4d66-b9ec-9d5f533b19c0"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4494), new Guid("20792100-80af-49a8-8195-f7c36441c38d"), (byte)27, "Vitória e Região Metropolitana/Colatina/Linhares/Santa Maria de Jetibá" },
                    { new Guid("409404d3-5ca6-4fef-af31-51a58481cf17"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4565), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)74, "Irecê/Jacobina/Juazeiro/Xique-Xique" },
                    { new Guid("41f6321f-5901-4f50-9a0a-618846dcdcff"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4598), new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), (byte)93, "Santarém/Altamira" },
                    { new Guid("42a89b40-f4c2-4294-8164-2bf4254db8e0"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4569), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)77, "Barreiras/Bom Jesus da Lapa/Guanambi/Vitória da Conquista" },
                    { new Guid("443cc9c9-e854-4fcb-862d-2d4eb4e44489"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4567), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)75, "Alagoinhas/Feira de Santana/Paulo Afonso/Valença" },
                    { new Guid("45c9967a-c314-4b94-b667-27d1d6073641"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4441), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)14, "Avaré/Bauru/Botucatu/Jaú/Lins/Marília/Ourinhos" },
                    { new Guid("49da6561-e08b-47eb-b876-e9160df2b816"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4542), new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), (byte)62, "Goiânia e Região Metropolitana/Anápolis/Niquelândia/Porangatu" },
                    { new Guid("4ad7e51b-d434-465e-805d-f0d63a5a7e41"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4553), new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), (byte)67, "Abrangência em todo o estado" },
                    { new Guid("54217610-f222-4454-9d8f-0da6bb7b2d3c"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4588), new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), (byte)88, "Juazeiro do Norte/Sobral" },
                    { new Guid("5cd55c37-e1ad-493c-8447-b3f3f3c4d568"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4536), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)54, "Caxias do Sul/Passo Fundo" },
                    { new Guid("5de53de0-8720-48a2-a008-49a5025d7045"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4593), new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), (byte)92, "Manaus e Região Metropolitana/Parintins" },
                    { new Guid("5f12d41a-db6f-43a7-be1c-6676308b020e"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4564), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)73, "Eunápolis/Ilhéus/Porto Seguro/Teixeira de Freitas" },
                    { new Guid("60610e8c-b98e-4cdf-9585-50e498a9cca6"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4519), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)44, "Maringá/Campo Mourão/Umuarama" },
                    { new Guid("62313755-e43e-4b6c-a4aa-f7855cd39e9f"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4557), new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), (byte)69, "Abrangência em todo o estado" },
                    { new Guid("62440b10-3d74-48d6-8cf2-e85cefd96d7b"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4550), new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), (byte)65, "Cuiabá e Região Metropolitana" },
                    { new Guid("6e3902d5-7847-449d-a12e-696ce5761a22"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4574), new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), (byte)82, "Abrangência em todo o estado" },
                    { new Guid("7bb2be39-606a-4a15-a7ab-5063db95e727"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4540), new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), (byte)61, "Abrangência em todo o Distrito Federal e alguns municípios da Região Integrada de Desenvolvimento do Distrito Federal e Entorno" },
                    { new Guid("7ea1db80-7353-4896-9430-09d1b4b99980"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4474), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)15, "Itapetininga/Itapeva/Sorocaba/Tatuí" },
                    { new Guid("7eca720f-2cc5-4428-a1c5-cdd98423bc73"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4502), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)33, "Almenara/Caratinga/Governador Valadares/Manhuaçu/Teófilo Otoni" },
                    { new Guid("81dc7af6-0cb7-4c9e-bb12-edd64a714382"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4484), new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), (byte)21, "Rio de Janeiro e Região Metropolitana/Teresópolis" },
                    { new Guid("81dddcff-07d3-4582-a4f0-d4d85acb1537"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4603), new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), (byte)96, "Abrangência em todo o estado" },
                    { new Guid("8e14eb41-12b1-427b-8baf-5975378cf940"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4478), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)17, "Barretos/Catanduva/Fernandópolis/Jales/São José do Rio Preto/Votuporanga" },
                    { new Guid("913339bf-d4bc-4dd6-b8b5-d249a44a32e6"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4487), new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), (byte)24, "Angra dos Reis/Petrópolis/Volta Redonda/Piraí" },
                    { new Guid("9283fa9c-50de-4ebe-a639-6bcdec2f0968"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4505), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)35, "Alfenas/Guaxupé/Lavras/Poços de Caldas/Pouso Alegre/Varginha" },
                    { new Guid("9afcca82-b65a-4401-9357-6282e236be25"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4538), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)55, "Santa Maria/Santana do Livramento/Santo Ângelo/Uruguaiana" },
                    { new Guid("9c569af6-1906-4291-9f3e-6a8f9f51d91b"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4480), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)18, "Andradina/Araçatuba/Assis/Birigui/Dracena/Presidente Prudente" },
                    { new Guid("a407bcbe-e3a1-462e-8db4-878ff2c7e0a0"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4552), new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), (byte)66, "Rondonópolis/Sinop" },
                    { new Guid("a45f163c-896a-418e-be58-8580cbc7c007"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4590), new Guid("275002db-aa62-444e-a179-b801583c3568"), (byte)89, "Picos/Floriano" },
                    { new Guid("a6099026-f5fd-44af-9f0b-36695d44f440"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4555), new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), (byte)68, "Abrangência em todo o estado" },
                    { new Guid("b523dafb-dadc-4e21-9064-5d9c6b2e444f"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4497), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)31, "Belo Horizonte e Região Metropolitana/Conselheiro Lafaiete/Ipatinga/Viçosa" },
                    { new Guid("bfb6c141-0e59-4c34-b6a0-cba4e2c48258"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4600), new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), (byte)94, "Marabá" },
                    { new Guid("c0630627-323d-47f0-9e7c-c2f55cecc2c0"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4571), new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), (byte)79, "Abrangência em todo o estado " },
                    { new Guid("c5918313-fd54-472a-b92d-1f34bc3a141a"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4504), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)34, "Araguari/Araxá/Patos de Minas/Uberlândia/Uberaba" },
                    { new Guid("c5df78d0-1ea4-494d-a9ed-c1e14990c5e0"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4607), new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), (byte)98, "São Luís e Região Metropolitana" },
                    { new Guid("c6677d7c-7493-4106-aaa4-4763f3a4b197"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4437), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)12, "Região Metropolitana do Vale do Paraíba e Litoral Norte" },
                    { new Guid("c73afde1-6434-403f-83ab-e5d7f19ffaa6"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4482), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)19, "Americana/Campinas/Limeira/Piracicaba/Rio Claro/São João da Boa Vista" },
                    { new Guid("c99d60b1-6485-42af-b6e3-5004aa2843db"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4439), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)13, "Região Metropolitana da Baixada Santista/Vale do Ribeira" },
                    { new Guid("d3fa89dc-8183-4bbf-a37c-365826491ced"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4517), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)43, "Apucarana/Londrina" },
                    { new Guid("d490206e-293f-4b97-9d6a-6f816237b31f"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4499), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)32, "Barbacena/Juiz de Fora/Muriaé/São João del-Rei/Ubá" },
                    { new Guid("d587e61e-f773-4c2a-9dc6-6caf85cc33be"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4531), new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), (byte)49, "Caçador/Chapecó/Lages" },
                    { new Guid("db7b16a0-95cf-40e7-b1ed-3b1ba41ad108"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4548), new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), (byte)64, "Caldas Novas/Catalão/Itumbiara/Rio Verde" },
                    { new Guid("de1c4ecf-cade-4394-a557-f741bef5a2a9"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4512), new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), (byte)38, "Curvelo/Diamantina/Montes Claros/Pirapora/Unaí" },
                    { new Guid("e4567660-69b7-4e75-baac-7c5c64628783"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4524), new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), (byte)47, "Balneário Camboriú/Blumenau/Itajaí/Joinville" },
                    { new Guid("e5e40fd9-3dde-40b8-b577-2449711803f2"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4584), new Guid("275002db-aa62-444e-a179-b801583c3568"), (byte)86, "Teresina e alguns municípios da Região Integrada de Desenvolvimento da Grande Teresina/Parnaíba" },
                    { new Guid("eebda4fc-9c0c-4d06-ac92-951413f7ee92"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4605), new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), (byte)97, "Abrangência no interior do estado" },
                    { new Guid("eef46fa6-6b1f-45d4-84c7-cb22e99831fa"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4522), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)46, "Francisco Beltrão/Pato Branco" },
                    { new Guid("f0a8bcae-b604-4875-943c-a2337414afa8"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4602), new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), (byte)95, "Abrangência em todo o estado" },
                    { new Guid("f0e88c0f-af73-46eb-a01f-21cd5f297ee5"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4485), new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), (byte)22, "Cabo Frio/Campos dos Goytacazes/Itaperuna/Macaé/Nova Friburgo" },
                    { new Guid("f17bcb7f-bc5b-4f30-ac9d-b7cfb87d402c"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4515), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)42, "Ponta Grossa/Guarapuava" },
                    { new Guid("f348eff9-a667-4f5a-a969-27fbad25c941"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4533), new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), (byte)51, "Porto Alegre e Região Metropolitana/Santa Cruz do Sul/Litoral Norte" },
                    { new Guid("f49807a1-8169-4069-88d6-894205c39daa"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4609), new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), (byte)99, "Caxias/Codó/Imperatriz" },
                    { new Guid("f6cbeb67-f846-4160-91ad-5bed89ed704e"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4521), new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), (byte)45, "Cascavel/Foz do Iguaçu" },
                    { new Guid("f90537dc-cd52-4658-a0b3-7ba82398d18b"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4559), new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), (byte)71, "Salvador e Região Metropolitana" },
                    { new Guid("f9785991-5664-40a1-87b9-a6723f402860"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4592), new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), (byte)91, "Belém e Região Metropolitana" },
                    { new Guid("f9bde588-aade-4097-ab4d-6552cca6a394"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4434), new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), (byte)11, "Região Metropolitana de São Paulo/Região Metropolitana de Jundiaí/Região Geográfica Imediata de Bragança Paulista" },
                    { new Guid("fc155e39-58b1-484b-825b-d5de7c8ff016"), new DateTime(2024, 5, 26, 21, 14, 48, 388, DateTimeKind.Local).AddTicks(4586), new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), (byte)87, "Garanhuns/Petrolina/Salgueiro/Serra Talhada" }
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
