using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;

namespace DAL
{
    public class PersonaRepository
    {
        String ruta = "Persona.txt";
        public void Guardar(Persona persona) 
        {
            FileStream file = new FileStream(ruta, FileMode.Append); //este objeto permite la apertura del archivo
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(persona.ToString());
            writer.Close();
            file.Close(); 

        }
        public void Eliminar (String Identificacion) { }
        public List<Persona> Consultar() 
        {
            List<Persona> personas = new List<Persona>(); 
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate);//abrir fichero
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null) //mientras haya algo que leer, para leer todo el archivo
            {
                Persona persona = MapearPersona(linea);
                personas.Add(persona);
            }
            reader.Close();
            file.Close(); 
            return personas;
        }

        private static Persona MapearPersona(string linea)
        {
            string[] datoPersona = linea.Split(';'); 
            Persona persona = new Persona(); //instanciamos el objeto
            persona.Cedula = datoPersona[0];
            persona.Nombre = datoPersona[1];
            persona.Edad = int.Parse(datoPersona[2]); 
            persona.Sexo = datoPersona[3];
            persona.Pulsacion = Convert.ToDecimal(datoPersona[4]); 
            return persona;
        }

        public Persona BuscarPorIdentificacion(String Identificacion)
        {
            Persona persona = new Persona();
            return persona;
        }
        public void Modificar(Persona personaNew, String identificacion)
        {

        }
    }
}
