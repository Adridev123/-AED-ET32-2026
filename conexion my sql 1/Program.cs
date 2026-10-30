using System;
using MySqlConnector;

namespace ConexionMySQL1
{
    class Program
    {
        static string connectionString = "Server=127.0.0.1;Database=tp1;User Id=root;Password=;";
        static string querySelect = "SELECT productosid, nombre, precio, stock FROM productos";

        static void ListarProductos()
        {
            Console.WriteLine("\n--- LISTA DE PRODUCTOS ---");

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (var command = new MySqlCommand(querySelect, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("No hay productos registrados.");
                                return;
                            }
                            while (reader.Read())
                            {
                                int productosid = reader.GetInt32("productosid");
                                string nombre = reader.GetString("nombre");
                                int precio = reader.GetInt32("precio");
                                int stock = reader.GetInt32("stock");

                                Console.WriteLine($"ID: {productosid} | Producto: {nombre} | Precio: ${precio:F2} | Stock: {stock}");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error de Base de Datos: {ex.Message}");
            }
        }

        static void AgregarProducto()
        {
            Console.WriteLine("\n--- AGREGAR NUEVO PRODUCTO ---");

            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Precio: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal precio))
            {
                Console.WriteLine("Precio no válido. Operación cancelada.");
                return;
            }

            Console.Write("Stock inicial: ");
            if (!int.TryParse(Console.ReadLine(), out int stock))
            {
                Console.WriteLine("Stock no válido. Operación cancelada.");
                return;
            }

            string queryInsert = "INSERT INTO productos (nombre, precio, stock) VALUES (@nombre, @precio, @stock)";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(queryInsert, connection))
                    {
                        command.Parameters.AddWithValue("@nombre", nombre);
                        command.Parameters.AddWithValue("@precio", precio);
                        command.Parameters.AddWithValue("@stock", stock);

                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                            Console.WriteLine("¡Producto agregado con éxito!");
                        else
                            Console.WriteLine("No se pudo agregar el producto.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error al insertar: {ex.Message}");
            }
        }

        static void ActualizarStock()
        {
            Console.WriteLine("\n--- ACTUALIZAR STOCK DE PRODUCTO ---");

            Console.Write("Ingresa el ID del producto a modificar: ");
            if (!int.TryParse(Console.ReadLine(), out int productosid))
            {
                Console.WriteLine("ID no válido.");
                return;
            }

            Console.Write("Ingresa la nueva cantidad de stock: ");
            if (!int.TryParse(Console.ReadLine(), out int nuevoStock))
            {
                Console.WriteLine("Cantidad no válida.");
                return;
            }

            string queryUpdate = "UPDATE productos SET stock = @stock WHERE productosid = @productosid";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(queryUpdate, connection))
                    {
                        command.Parameters.AddWithValue("@stock", nuevoStock);
                        command.Parameters.AddWithValue("@productosid", productosid);

                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                            Console.WriteLine("¡Stock actualizado con éxito!");
                        else
                            Console.WriteLine("No se encontró ningún producto con ese ID.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error al actualizar: {ex.Message}");
            }
        }

        static void EliminarProducto()
        {
            Console.WriteLine("\n--- ELIMINAR PRODUCTO ---");

            Console.Write("Ingresa el ID del producto que deseas borrar: ");
            if (!int.TryParse(Console.ReadLine(), out int productosid))
            {
                Console.WriteLine("ID no válido.");
                return;
            }

            string queryDelete = "DELETE FROM productos WHERE productosid = @productosid";

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(queryDelete, connection))
                    {
                        command.Parameters.AddWithValue("@productosid", productosid);

                        int filasAfectadas = command.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                            Console.WriteLine("¡Producto eliminado con éxito!");
                        else
                            Console.WriteLine("No se encontró ningún producto con ese ID.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error al eliminar: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("\n--- MENÚ DE INVENTARIO ---");
                Console.WriteLine("1. Listar productos");
                Console.WriteLine("2. Agregar producto");
                Console.WriteLine("3. Actualizar stock");
                Console.WriteLine("4. Eliminar producto");
                Console.WriteLine("5. Salir");
                Console.Write("Elige una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            ListarProductos();
                            break;
                        case 2:
                            AgregarProducto();
                            break;
                        case 3:
                            ActualizarStock();
                            break;
                        case 4:
                            EliminarProducto();
                            break;
                        case 5:
                            Console.WriteLine("¡Hasta luego!");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, introduce un número válido.");
                }
            } while (opcion != 5);
        }
    }
}
