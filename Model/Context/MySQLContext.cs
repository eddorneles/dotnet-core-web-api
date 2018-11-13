using Microsoft.EntityFrameworkCore;

namespace webapi01.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(){

        }//END constructor()

        public MySQLContext( DbContextOptions<MySQLContext> options ) : base(options) {

        }//END constructor()

        //Permite mapear a tabela para os objetos da classe
        public DbSet<Person> Person{get; set;}
    }
}