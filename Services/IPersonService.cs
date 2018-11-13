using System.Collections.Generic;

using webapi01.Model;


namespace webapi01.Services{
    public interface IPersonService{
        Person Create( Person person );
        Person FindById( long id );
        List<Person> FindAll();
        Person Update( Person person);
        void Delete( long id);
    }
}