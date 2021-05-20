using Microsoft.EntityFrameworkCore.Migrations;

namespace crud_pessoa.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Telefon = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    Cep = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Rua = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idade = table.Column<string>(type: "char(3)", maxLength: 3, nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "char(11)", maxLength: 11, nullable: false),
                    ContatoId = table.Column<int>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Contato_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pessoa_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_ContatoId",
                table: "Pessoa",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
