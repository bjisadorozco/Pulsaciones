using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;
namespace BLL
{
    public class PersonaService
    {
        PersonaRepository personaRepository;
    
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }
        public string Guardar(Persona persona)
        {
            try
            {
                personaRepository.Guardar(persona);
                return "Datos guardados satisfactoriamente";
            }
            catch (Exception exception)
            {
                return "Ocurrio el siguiente error: " + exception.Message;
            }
        }
        public ConsultaResponse Consultar()
        {
            try
            {
               return new ConsultaResponse(personaRepository.Consultar()); //instancia consultaResponse que instancia la lista
            }
            catch (Exception exception)
            {

                return new ConsultaResponse("Ocurrio el siguiente error: " + exception.Message); //utiliza el constructor que recibe un string y retornara Error
            }
        }
    }
    public class ConsultaResponse //clase de respuesta para lo del null
    {
        public List<Persona> Personas { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public ConsultaResponse(List<Persona> personas) //por el try
        {
            Personas = personas;
            Error = false;
        }
        public ConsultaResponse(string mensaje) //por el catch
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
