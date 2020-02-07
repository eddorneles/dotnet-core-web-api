using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

using Model;
using Model.Context;


namespace Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private MySqlContext context;

        public PersonServiceImpl( MySqlContext context ){
            this.context = context;
        }//END constructor

        // Contador responsável por gerar um fake ID já que não estamos
        // acessando nenhum banco de dados
        private volatile int count;

        // Metodo responsável por criar uma nova pessoa
        // Se tivéssemos um banco de dados esse seria o
        // momento de persistir os dados
        public Person Create(Person person)
        {
            try{
                this.context.Add( person );
                this.context.SaveChanges();
            return person;
            }catch( Exception e ){
                throw e;
            }//END try
        }

        // Método responsável por retornar uma pessoa
        // como não acessamos nenhuma base de dados
        // estamos retornando um mock
        public Person FindById(long id)
        {
            return this.context.Persons.SingleOrDefault( p => p.Id.Equals(id) );
        }

        // Método responsável por deletar
        // uma pessoa a partir de um ID
        public void Delete( long id ){
            var result = this.context.Persons.SingleOrDefault( p => p.Id.Equals( id ) );
            try{
                if( result != null ){
                    this.context.Persons.Remove( result );
                }//END if
            }catch( Exception e){
                throw e;
            }
        }//END Delete

        // Método responsável por retornar todas as pessoas
        // mais uma vez essas informações são mocks
        public List<Person> FindAll()
        {
            return this.context.Persons.ToList();
        }

        // Método responsável por atualizar uma pessoa
        // por ser mock retornamos a mesma informação passada
        public Person Update(Person person)
        {
            if( !Exists( person ) ){
                return new Person();
            } 
            var result = context.Persons.SingleOrDefault( p => p.Id.Equals( person.Id ) );
            try{
                this.context.Entry( result ).CurrentValues.SetValues( person );
                this.context.SaveChanges();
            }catch( Exception e ){
                throw e;
            }//END try
            return person;
        }//END Update

        private bool Exists( Person person ){
            return this.context.Persons.Any( p => p.Id.Equals(person.Id) );
        }

    }
}
