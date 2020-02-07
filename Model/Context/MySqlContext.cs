using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(){

        }//END constructor()

        public MySqlContext( DbContextOptions<MySqlContext> options ) : base(options) {

        }//END constructor()

        //Permite mapear a tabela para os objetos da classe
        public DbSet<Person> Persons{get; set;}
    }
}