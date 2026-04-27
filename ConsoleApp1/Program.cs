using System;
using System.Collections.Generic;

// El namespace es el contenedor principal que agrupa todas nuestras clases.
namespace Colecciones
{
    // ============================================================
    // CLASE LIBRO: Representa el objeto básico del sistema.
    // Solo contiene los datos del libro y un método para obtener el título.
    // ============================================================
    internal class Libro
    {
        
    }

    // ============================================================
    // CLASE LECTOR: Representa a la persona que pide libros.
    // Según la consigna, tiene nombre, dni y un máximo de 3 préstamos.
    // ============================================================
    internal class Lector
    {
        
    }

    // ============================================================
    // CLASE BIBLIOTECA: Es el cerebro del programa.
    // Maneja la lista global de libros y la lista de lectores registrados.
    // ============================================================
    internal class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        public Biblioteca()
        {
            this.libros = new List<Libro>();
            this.lectores = new List<Lector>();
        }

       
        private Libro buscarLibro(string titulo)
        {
            Libro buscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo))
                i++;
            if (i != libros.Count) buscado = libros[i];
            return buscado;
        }

       
        private Lector buscarLector(string dni)
        {
            Lector buscado = null;
            int i = 0;
            while (i < lectores.Count && !lectores[i].getDni().Equals(dni))
                i++;
            if (i != lectores.Count) buscado = lectores[i];
            return buscado;
        }

        
        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            if (buscarLibro(titulo) == null)
            {
                libros.Add(new Libro(titulo, autor, editorial));
                return true;
            }
            return false;
        }

        
        public bool altaLector(string nombre, string dni)
        {
            if (buscarLector(dni) == null)
            {
                lectores.Add(new Lector(nombre, dni));
                return true;
            }
            return false;
        }

        
        public string prestarLibro(string titulo, string dni)
        {
            Lector lector = buscarLector(dni);
            if (lector == null) return "LECTOR INEXISTENTE";

            if (lector.getCantidadPrestamos() >= 3) return "TOPE DE PRESTAMO ALCAZADO";

            Libro libro = buscarLibro(titulo);
            if (libro == null) return "LIBRO INEXISTENTE";

            
            libros.Remove(libro); 
            lector.agregarLibroPrestado(libro);
            return "PRESTAMO EXITOSO";
        }
    }

    // ============================================================
    // CLASE TEST: Donde el programa arranca.
    // Contiene el método Main que orquestará las pruebas para el video.
    // ============================================================
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca miBiblioteca = new Biblioteca();

            
            miBiblioteca.agregarLibro("Csharp para principiantes", "Autor A", "Editorial X");
            miBiblioteca.agregarLibro("Lógica de Programación", "Autor B", "Editorial Y");
            miBiblioteca.agregarLibro("Estructuras de Datos", "Autor C", "Editorial Z");
            miBiblioteca.agregarLibro("UML avanzado", "Autor D", "Editorial W");

            miBiblioteca.altaLector("Pepe Grillo", "12345678");

            Console.WriteLine("=== PRUEBAS DE REQUERIMIENTOS ===\n");

            
            Console.WriteLine("Prueba 1 (Éxito): " + miBiblioteca.prestarLibro("Csharp para principiantes", "12345678"));

         
            Console.WriteLine("Prueba 2 (Libro inexistente): " + miBiblioteca.prestarLibro("Libro Fantasma", "12345678"));

           
            Console.WriteLine("Prueba 3 (Lector inexistente): " + miBiblioteca.prestarLibro("Lógica de Programación", "99999999"));

            miBiblioteca.prestarLibro("Lógica de Programación", "12345678"); 
            miBiblioteca.prestarLibro("Estructuras de Datos", "12345678");   

            Console.WriteLine("Prueba 4 (Tope alcanzado): " + miBiblioteca.prestarLibro("UML avanzado", "12345678"));

            Console.WriteLine("\nSimulación finalizada. Presione una tecla para cerrar.");
            Console.ReadKey();
        }
    }
}