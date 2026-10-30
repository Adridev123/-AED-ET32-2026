using System;
using System.Data;
using MySqlConnector;

namespace GestionEscuela
{
    class Program
    {
        static string cadenaConexion = "Server=127.0.0.1;Database=tp2;User Id=root;Password=;";

        static void Main(string[] args)
        {
            int opcion = -1;
            do
            {
                Console.WriteLine("\n========= GESTIÓN DE ALUMNOS =========");
                Console.WriteLine("1. Registrar alumno");
                Console.WriteLine("2. Listar todos los alumnos");
                Console.WriteLine("3. Buscar alumnos por curso");
                Console.WriteLine("4. Modificar edad de un alumno");
                Console.WriteLine("5. Eliminar alumno");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1: RegistrarAlumno(); break;
                        case 2: ListarAlumnos(); break;
                        case 3: BuscarAlumnosPorCurso(); break;
                        case 4: ModificarEdadAlumno(); break;
                        case 5: EliminarAlumno(); break;
                        case 0: Console.WriteLine("¡Aplicación cerrada con éxito!"); break;
                        default: Console.WriteLine("Opción no válida. Intente nuevamente."); break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                    opcion = -1;
                }
            } while (opcion != 0);
        }

        static void RegistrarAlumno()
        {
            Console.WriteLine("\n--- REGISTRAR ALUMNO ---");

            Console.Write("Nombre completo: ");
            string nombre = Console.ReadLine();
            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("Error: El nombre no puede estar vacío.");
                return;
            }

            Console.Write("Edad: ");
            if (!int.TryParse(Console.ReadLine(), out int edad) || edad <= 0)
            {
                Console.WriteLine("Error: La edad debe ser un número entero positivo.");
                return;
            }

            Console.Write("Curso: ");
            string curso = Console.ReadLine();
            if (string.IsNullOrEmpty(curso))
            {
                Console.WriteLine("Error: El curso no puede estar vacío.");
                return;
            }

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    using (MySqlCommand comando = new MySqlCommand("RegistrarAlumno", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("p_nombre", nombre);
                        comando.Parameters.AddWithValue("p_edad", edad);
                        comando.Parameters.AddWithValue("p_curso", curso);

                        comando.ExecuteNonQuery();
                        Console.WriteLine("¡Alumno registrado con éxito!");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error de conexión o base de datos: {ex.Message}");
            }
        }

        static void ListarAlumnos()
        {
            Console.WriteLine("\n--- LISTA DE TODOS LOS ALUMNOS ---");

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    using (MySqlCommand comando = new MySqlCommand("ListarAlumnos", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (MySqlDataReader lector = comando.ExecuteReader())
                        {
                            if (!lector.HasRows)
                            {
                                Console.WriteLine("No se encontraron alumnos registrados.");
                                return;
                            }

                            while (lector.Read())
                            {
                                Console.WriteLine($"{lector["id"]} - {lector["nombre"]} - {lector["edad"]} años - Curso: {lector["curso"]}");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error de conexión o base de datos: {ex.Message}");
            }
        }

        static void BuscarAlumnosPorCurso()
        {
            Console.WriteLine("\n--- BUSCAR ALUMNOS POR CURSO ---");

            Console.Write("Ingrese el nombre del curso a buscar: ");
            string curso = Console.ReadLine();
            if (string.IsNullOrEmpty(curso))
            {
                Console.WriteLine("Error: El curso no puede estar vacío.");
                return;
            }

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    using (MySqlCommand comando = new MySqlCommand("BuscarAlumnosPorCurso", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("p_curso", curso);

                        using (MySqlDataReader lector = comando.ExecuteReader())
                        {
                            if (!lector.HasRows)
                            {
                                Console.WriteLine($"No se encontraron alumnos registrados en el curso: {curso}");
                                return;
                            }

                            while (lector.Read())
                            {
                                Console.WriteLine($"{lector["id"]} - {lector["nombre"]} - {lector["edad"]} años - Curso: {lector["curso"]}");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error de conexión o base de datos: {ex.Message}");
            }
        }

        static void ModificarEdadAlumno()
        {
            Console.WriteLine("\n--- MODIFICAR EDAD DE ALUMNO ---");

            Console.Write("Ingrese el ID del alumno: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Error: El ID debe ser un número entero positivo.");
                return;
            }

            Console.Write("Ingrese la nueva edad: ");
            if (!int.TryParse(Console.ReadLine(), out int nuevaEdad) || nuevaEdad <= 0)
            {
                Console.WriteLine("Error: La edad debe ser un número entero positivo.");
                return;
            }

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    using (MySqlCommand comando = new MySqlCommand("ModificarEdadAlumno", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("p_id", id);
                        comando.Parameters.AddWithValue("p_nueva_edad", nuevaEdad);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                            Console.WriteLine("¡Edad modificada con éxito!");
                        else
                            Console.WriteLine($"No se encontró ningún alumno con el ID: {id}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error de conexión o base de datos: {ex.Message}");
            }
        }

        static void EliminarAlumno()
        {
            Console.WriteLine("\n--- ELIMINAR ALUMNO ---");

            Console.Write("Ingrese el ID del alumno a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
            {
                Console.WriteLine("Error: El ID debe ser un número entero positivo.");
                return;
            }

            try
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    using (MySqlCommand comando = new MySqlCommand("EliminarAlumno", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("p_id", id);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                            Console.WriteLine("¡Alumno eliminado con éxito!");
                        else
                            Console.WriteLine($"No se encontró ningún alumno con el ID: {id}");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error de conexión o base de datos: {ex.Message}");
            }
        }
    }
}
