using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Escribe tu nombre: ");
            var nombre = Console.ReadLine();
            Console.WriteLine("Hola " + nombre);
            Console.ReadLine();
        }
    }
}
