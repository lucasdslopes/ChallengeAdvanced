using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InovaX.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InovaX_Tb_Endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CEP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Rua = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_Endereco", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_Produto",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Preco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Quantidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_Produto", x => x.IdProduto);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_Servico",
                columns: table => new
                {
                    IdServico = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Preco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_Servico", x => x.IdServico);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_Telefone",
                columns: table => new
                {
                    TelefoneId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DDI = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DDD = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_Telefone", x => x.TelefoneId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_Avaliacao",
                columns: table => new
                {
                    IdAvaliacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataAvaliacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Texto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdProduto = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProdutoIdProduto = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    IdServico = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ServicoIdServico = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_Avaliacao", x => x.IdAvaliacao);
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_Avaliacao_InovaX_Tb_Produto_ProdutoIdProduto",
                        column: x => x.ProdutoIdProduto,
                        principalTable: "InovaX_Tb_Produto",
                        principalColumn: "IdProduto");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_Avaliacao_InovaX_Tb_Servico_ServicoIdServico",
                        column: x => x.ServicoIdServico,
                        principalTable: "InovaX_Tb_Servico",
                        principalColumn: "IdServico");
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_Distribuidor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    TelefoneId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_Distribuidor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_Distribuidor_InovaX_Tb_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "InovaX_Tb_Endereco",
                        principalColumn: "IdEndereco");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_Distribuidor_InovaX_Tb_Telefone_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "InovaX_Tb_Telefone",
                        principalColumn: "TelefoneId");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_Distribuidor_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CPF = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RG = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    TelefoneId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_PessoaFisica_InovaX_Tb_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "InovaX_Tb_Endereco",
                        principalColumn: "IdEndereco");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_PessoaFisica_InovaX_Tb_Telefone_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "InovaX_Tb_Telefone",
                        principalColumn: "TelefoneId");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_PessoaFisica_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InovaX_Tb_PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CNPJ = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NaturezaJuridica = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Situacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    TelefoneId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InovaX_Tb_PessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_PessoaJuridica_InovaX_Tb_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "InovaX_Tb_Endereco",
                        principalColumn: "IdEndereco");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_PessoaJuridica_InovaX_Tb_Telefone_TelefoneId",
                        column: x => x.TelefoneId,
                        principalTable: "InovaX_Tb_Telefone",
                        principalColumn: "TelefoneId");
                    table.ForeignKey(
                        name: "FK_InovaX_Tb_PessoaJuridica_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistribuidorProduto",
                columns: table => new
                {
                    DistribuidoresId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProdutosIdProduto = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribuidorProduto", x => new { x.DistribuidoresId, x.ProdutosIdProduto });
                    table.ForeignKey(
                        name: "FK_DistribuidorProduto_InovaX_Tb_Distribuidor_DistribuidoresId",
                        column: x => x.DistribuidoresId,
                        principalTable: "InovaX_Tb_Distribuidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistribuidorProduto_InovaX_Tb_Produto_ProdutosIdProduto",
                        column: x => x.ProdutosIdProduto,
                        principalTable: "InovaX_Tb_Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistribuidorServico",
                columns: table => new
                {
                    DistribuidoresId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ServicosIdServico = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistribuidorServico", x => new { x.DistribuidoresId, x.ServicosIdServico });
                    table.ForeignKey(
                        name: "FK_DistribuidorServico_InovaX_Tb_Distribuidor_DistribuidoresId",
                        column: x => x.DistribuidoresId,
                        principalTable: "InovaX_Tb_Distribuidor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistribuidorServico_InovaX_Tb_Servico_ServicosIdServico",
                        column: x => x.ServicosIdServico,
                        principalTable: "InovaX_Tb_Servico",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistribuidorProduto_ProdutosIdProduto",
                table: "DistribuidorProduto",
                column: "ProdutosIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_DistribuidorServico_ServicosIdServico",
                table: "DistribuidorServico",
                column: "ServicosIdServico");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_Avaliacao_ProdutoIdProduto",
                table: "InovaX_Tb_Avaliacao",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_Avaliacao_ServicoIdServico",
                table: "InovaX_Tb_Avaliacao",
                column: "ServicoIdServico");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_Distribuidor_EnderecoId",
                table: "InovaX_Tb_Distribuidor",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_Distribuidor_TelefoneId",
                table: "InovaX_Tb_Distribuidor",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_PessoaFisica_EnderecoId",
                table: "InovaX_Tb_PessoaFisica",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_PessoaFisica_TelefoneId",
                table: "InovaX_Tb_PessoaFisica",
                column: "TelefoneId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_PessoaJuridica_EnderecoId",
                table: "InovaX_Tb_PessoaJuridica",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_InovaX_Tb_PessoaJuridica_TelefoneId",
                table: "InovaX_Tb_PessoaJuridica",
                column: "TelefoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistribuidorProduto");

            migrationBuilder.DropTable(
                name: "DistribuidorServico");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_Avaliacao");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_PessoaFisica");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_PessoaJuridica");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_Distribuidor");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_Produto");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_Servico");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_Endereco");

            migrationBuilder.DropTable(
                name: "InovaX_Tb_Telefone");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
