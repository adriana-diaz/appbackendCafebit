using ProyectoMovilBackend.AccesoDatos;
using ProyectoMovilBackend.Modelos.Request;
using ProyectoMovilBackend.Modelos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using ProyectoMovilBackend.Modelos.Entidades;

namespace ProyectoMovilBackend.Logica
{
    public class LogProyecto
    {
        /// USUARIO
        public ResInsertarUsuario insertarUsuario(ReqInsertarUsuario req)
        {
            ResInsertarUsuario res = new ResInsertarUsuario();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Bad request";
                }
                else
                {
                    if (String.IsNullOrEmpty(req.usuario.cedula))
                    {
                        res.resultado = false;
                        res.error = "cedula Incorrecto";

                    }
                    else if (String.IsNullOrEmpty(req.usuario.nombre))
                    {
                        res.resultado = false;
                        res.error = "Nombre Incorrecto";

                    }
                    else if (String.IsNullOrEmpty(req.usuario.email))
                    {
                        res.resultado = false;
                        res.error = "Email Incorrecto";
                    }
                    else if (String.IsNullOrEmpty(req.usuario.password))
                    {
                        res.resultado = false;
                        res.error = "Password Incorrecto";
                    }
                    else
                    {
                        int? returnId = 0;
                        int? errorId = 0;
                        string errorDescripcion = "";

                        ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
                        miLinq.SP_INGRESAR_USUARIO(req.usuario.cedula, req.usuario.nombre, req.usuario.email, req.usuario.password, ref returnId, ref errorId, ref errorDescripcion);
                        if (returnId <= 0 || returnId == null)
                        {

                            res.resultado = false;
                            res.error = errorDescripcion;
                        }
                        else
                        {
                            //todo paso bien

                            res.resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = $"500 - Error Interno: {ex.Message}";
                Console.WriteLine(ex.ToString()); // Esto registra el error en la consola.
            }

            return res;
        }
        //listo
        public ResActualizarUsuario actualizarUsuario(ReqActualizarUsuario req)
        {
            ResActualizarUsuario res = new ResActualizarUsuario();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Bad request";
                }
                else
                {

                    if (String.IsNullOrEmpty(req.usuario.nombre))
                    {
                        res.resultado = false;
                        res.error = "Nombre Incorrecto";

                    }
                    else if (String.IsNullOrEmpty(req.usuario.email))
                    {
                        res.resultado = false;
                        res.error = "Email Incorrecto";
                    }
                    else if (String.IsNullOrEmpty(req.usuario.password))
                    {
                        res.resultado = false;
                        res.error = "Password Incorrecto";
                    }
                    else
                    {
                        int? returnId = 0;
                        int? errorId = 0;
                        string errorDescripcion = "";

                        ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
                        miLinq.SP_ACTUALIZAR_USUARIO(req.usuario.id_usuario, req.usuario.nombre, req.usuario.email, req.usuario.password, ref returnId, ref errorId, ref errorDescripcion);
                        if (returnId <= 0 || returnId == null)
                        {

                            res.resultado = false;
                            res.error = errorDescripcion;
                        }
                        else
                        {
                            //todo paso bien

                            res.resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "500- Error Interno";
            }

            return res;
        }
        //listo

        ///Sesiones
        ///
        public ResLogin entrarlogin(ReqLogin req)
        {
            ResLogin res = new ResLogin();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Bad request";
                    return res;
                }

                if (String.IsNullOrEmpty(req.login.email))
                {
                    res.resultado = false;
                    res.error = "Correo Incorrecto";
                    return res;
                }

                if (String.IsNullOrEmpty(req.login.password))
                {
                    res.resultado = false;
                    res.error = "Password Incorrecto";
                    return res;
                }

                // Declarar variables necesarias
                int? errorId = 0;
                int? id_usuario = 0;
                string nombre = "";
                string email = req.login.email;
                string errorDescripcion = "";
                long? sesion_id = 0;

                // Crear instancia de la clase de acceso a datos
                ConexionLINQDataContext miLinq = new ConexionLINQDataContext();

                // Llamar al procedimiento almacenado
                miLinq.SP_LOGIN_USUARIO(req.login.email, req.login.password, ref sesion_id, ref id_usuario, ref nombre, ref errorId, ref errorDescripcion);

                if (sesion_id.HasValue && sesion_id.Value > 0 && errorId == 0)
                {
                    // Login exitoso
                    res.sesion_id = sesion_id;
                    res.id_usuario = id_usuario;
                    res.email = email;
                    res.nombre = nombre;
                    res.resultado = true;
                }
                else
                {
                    // Login fallido
                    res.resultado = false;
                    res.error = string.IsNullOrEmpty(errorDescripcion) ? "Credenciales incorrectas" : errorDescripcion;
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "500- Error Interno: " + ex.Message;

            }

            return res;
        }
        ////listo
        //public ResSalirLogin salirlogin(ReqSalirlogin req)
        //{
        //    ResSalirLogin res = new ResSalirLogin();

        //    try
        //    {
        //        if (req == null)
        //        {
        //            res.resultado = false;
        //            res.error = "Bad request";
        //        }
        //        else
        //        {
        //            if (req.login.sesion_id == 0)
        //            {
        //                res.resultado = false;
        //                res.error = "Sesion Incorrecta";
        //            }
        //            else
        //            {
        //                int? returnId = 0;
        //                int? errorId = 0;
        //                string errorDescripcion = "";

        //                ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
        //                miLinq.SP_CERRAR_SESION(req.login.sesion_id, ref returnId, ref errorId, ref errorDescripcion);
        //                if (errorId == 0)
        //                {
        //                    // Cierre de sesión exitoso
        //                    res.resultado = true;
        //                }
        //                else
        //                {
        //                    // Cierre de sesión fallido
        //                    res.resultado = false;
        //                    res.error = string.IsNullOrEmpty(errorDescripcion) ? "Error al cerrar sesión" : errorDescripcion;
        //                }

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.resultado = false;
        //        res.error = "500- Error Interno";
        //    }

        //    return res;
        //}
        ////listo


        /////categorias
        public ResInsertarCategoria insertarCategoria(ReqInsertarCategoria req)
        {
            ResInsertarCategoria res = new ResInsertarCategoria();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Bad request";
                }
                else
                {
                    if (String.IsNullOrEmpty(req.categoria.nombre))
                    {
                        res.resultado = false;
                        res.error = "Nombre Incorrecto";

                    }
                    else
                    {
                        int? returnId = 0;
                        int? errorId = 0;
                        string errorDescripcion = "";

                        ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
                        miLinq.SP_INSERTAR_CATEGORIA(req.categoria.nombre, ref returnId, ref errorId, ref errorDescripcion);

                        //todo paso bien

                        res.resultado = true;

                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "500- Error Interno";
            }

            return res;
        }

        ////listo

        //public ResActualizarCategoria actualizarCategoria(ReqActualizarCategoria req)
        //{
        //    ResActualizarCategoria res = new ResActualizarCategoria();

        //    try
        //    {
        //        if (req == null)
        //        {
        //            res.resultado = false;
        //            res.error = "Bad request";
        //        }
        //        else
        //        {
        //            if (String.IsNullOrEmpty(req.categoria.nombre))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";

        //            }
        //            if (String.IsNullOrEmpty(req.categoria.nuevo_nombre))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";

        //            }
        //            else
        //            {
        //                int? returnId = 0;
        //                int? errorId = 0;
        //                string errorDescripcion = "";

        //                ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
        //                miLinq.ActualizarCategoria(req.categoria.nombre, req.categoria.nuevo_nombre, ref returnId, ref errorId, ref errorDescripcion);
        //                if (returnId <= 0 || returnId == null)
        //                {

        //                    res.resultado = false;
        //                    res.error = errorDescripcion;
        //                }
        //                else
        //                {
        //                    //todo paso bien

        //                    res.resultado = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.resultado = false;
        //        res.error = "500- Error Interno";
        //    }

        //    return res;
        //}
        ////listo


        /////Productos
        /////
        public ResAgregarProducto agregarProducto(ReqAgregarProducto req)
        {
            ResAgregarProducto res = new ResAgregarProducto();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Bad request";
                }
                else
                {
                    if (String.IsNullOrEmpty(req.producto.nombre_categoria))
                    {
                        res.resultado = false;
                        res.error = "Categoria Incorrecta";
                    }

                    if (String.IsNullOrEmpty(req.producto.nombre))
                    {
                        res.resultado = false;
                        res.error = "Nombre Incorrecto";

                    }

                    else if (String.IsNullOrEmpty(req.producto.descripcion))
                    {
                        res.resultado = false;
                        res.error = "Descripcion Incorrecta";
                    }

                    if (req.producto.precio_producto == 0)
                    {
                        res.resultado = false;
                        res.error = "Precio Incorrecto";
                    }

                    else
                    {
                        int? returnId = 0;
                        int? errorId = 0;
                        string errorDescripcion = "";

                        ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
                        miLinq.SP_AGREGAR_PRODUCTO(req.producto.nombre_categoria, req.producto.nombre, req.producto.descripcion, req.producto.precio_producto, ref returnId, ref errorId, ref errorDescripcion);
                        if (returnId <= 0 || returnId == null)
                        {

                            res.resultado = false;
                            res.error = errorDescripcion;
                        }
                        else
                        {
                            //todo paso bien

                            res.resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "500- Error Interno";
            }

            return res;
        }


        //public ResActualizarProducto actualizarProducto(ReqActualizarProducto req)
        //{
        //    ResActualizarProducto res = new ResActualizarProducto();

        //    try
        //    {
        //        if (req == null)
        //        {
        //            res.resultado = false;
        //            res.error = "Bad request";
        //        }
        //        else
        //        {
        //            if (String.IsNullOrEmpty(req.producto.nombre_actual))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";
        //            }

        //            if (String.IsNullOrEmpty(req.producto.nuevo_nombre))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";
        //            }

        //            else if (String.IsNullOrEmpty(req.producto.descripcion))
        //            {
        //                res.resultado = false;
        //                res.error = "Descripcion Incorrecta";
        //            }

        //            else if (req.producto.precio_producto <= 0)
        //            {
        //                res.resultado = false;
        //                res.error = "Precio Incorrecto";
        //            }
        //            else if (String.IsNullOrEmpty(req.producto.nombre_categoria))
        //            {
        //                res.resultado = false;
        //                res.error = "Categoria Incorrecta";
        //            }
        //            else
        //            {
        //                int? returnId = 0;
        //                int? errorId = 0;
        //                string errorDescripcion = "";

        //                using (ConexionLINQDataContext miLinq = new ConexionLINQDataContext())
        //                {
        //                    miLinq.SP_ACTUALIZAR_PRODUCTO(req.producto.nombre_actual, req.producto.nuevo_nombre, req.producto.descripcion, req.producto.precio_producto, req.producto.nombre_categoria, ref returnId, ref errorId, ref errorDescripcion);

        //                    if (returnId <= 0 || returnId == null)
        //                    {

        //                        res.resultado = false;
        //                        res.error = errorDescripcion;
        //                    }
        //                    else
        //                    {
        //                        //todo paso bien

        //                        res.resultado = true;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.resultado = false;
        //        res.error = "500- Error Interno: " + ex.Message;
        //    }

        //    return res;
        //}
        ////listo

        public ResObtenerProductos obtenerProductos()
        {
            ResObtenerProductos res = new ResObtenerProductos();
            try
            {
                ConexionLINQDataContext miLinq = new ConexionLINQDataContext();

                List<SP_CONSULTAR_TODOS_PRODUCTOSResult> resultSet = new List<SP_CONSULTAR_TODOS_PRODUCTOSResult>();

                resultSet = miLinq.SP_CONSULTAR_TODOS_PRODUCTOS().ToList();

                foreach (SP_CONSULTAR_TODOS_PRODUCTOSResult unaPublicacionLinq in resultSet)
                {
                    res.listaDePublicaciones.Add(this.fabricaDePublicacion(unaPublicacionLinq));

                }
                res.resultado = true;
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "Error en backend";
            }
            return res;
        }

        //factoria
        private Producto.ConsultarTodos fabricaDePublicacion(SP_CONSULTAR_TODOS_PRODUCTOSResult publicacionLinq) // este fue para obtener publicaciones
        {
            Producto.ConsultarTodos productoFabricado = new Producto.ConsultarTodos();
            productoFabricado.nombre_categoria = publicacionLinq.categoria_nombre;
            productoFabricado.nombre = publicacionLinq.producto_nombre;
            productoFabricado.descripcion = publicacionLinq.descripcion;
            productoFabricado.precio_producto = (decimal?)publicacionLinq.precio_producto;

            return productoFabricado;
        }

        /////carrito
        /////
        public ResIngresaralCarrito ingresarCarrito(ReqIngresaralCarrito req)
        {
            ResIngresaralCarrito res = new ResIngresaralCarrito();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Bad request";
                }
                else
                {
                    if (req.carrito.id_usuario == 0)
                    {
                        res.resultado = false;
                        res.error = "id Incorrecta";
                    }
                    if (String.IsNullOrEmpty(req.carrito.nombre_producto))
                    {
                        res.resultado = false;
                        res.error = "Nombre Incorrecto";

                    }
                    if (req.carrito.cantidad == 0)
                    {
                        res.resultado = false;
                        res.error = "id Incorrecta";
                    }
                    if (String.IsNullOrEmpty(req.carrito.tamanho))
                    {
                        res.resultado = false;
                        res.error = "Tamanho Incorrecto";

                    }
                    if (String.IsNullOrEmpty(req.carrito.nombre_tienda))
                    {
                        res.resultado = false;
                        res.error = "Nombre Incorrecto";

                    }

                    else
                    {
                        {
                            int? returnId = 0;
                            int? errorId = 0;
                            string errorDescripcion = "";

                            ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
                            miLinq.SP_Ingresar_carrito(req.carrito.id_usuario, req.carrito.nombre_producto, req.carrito.cantidad, req.carrito.tamanho, req.carrito.nombre_tienda, ref returnId, ref errorId, ref errorDescripcion);
                            if (errorId == 0)
                            {
                                // Producto agregado al carrito exitosamente
                                res.resultado = true;
                                res.error = null; // Limpia cualquier error previo
                            }
                            else
                            {
                                // Ocurrió un error al intentar agregar el producto al carrito
                                res.resultado = false;
                                res.error = $"Error {errorId}: {errorDescripcion}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "500- Error Interno" + ex.Message; ;
            }

            return res;
        }

        public ResEliminarProductodelCarrito eliminarProductoCarrito(ReqEliminarProductodelCarrito req)
        {
            ResEliminarProductodelCarrito res = new ResEliminarProductodelCarrito();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Bad request";
                }
                else
                {
                    if (req.carrito.id_usuario == 0)
                    {
                        res.resultado = false;
                        res.error = "id Incorrecta";
                    }
                    if (req.carrito.id_carrito == 0)
                    {
                        res.resultado = false;
                        res.error = "id Incorrecta";
                    }

                    else
                    {
                        {
                            int? returnId = 0;
                            int? errorId = 0;
                            string errorDescripcion = "";

                            ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
                            miLinq.SP_Eliminar_Producto_Carrito(req.carrito.id_carrito, req.carrito.id_usuario, ref returnId, ref errorId, ref errorDescripcion);
                            if (errorId == 0)
                            {
                                // Producto agregado al carrito exitosamente
                                res.resultado = true;
                                res.error = null; // Limpia cualquier error previo
                            }
                            else
                            {
                                // Ocurrió un error al intentar agregar el producto al carrito
                                res.resultado = false;
                                res.error = $"Error {errorId}: {errorDescripcion}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "500- Error Interno" + ex.Message; ;
            }

            return res;
        }

        public ResObtenerProductosCarrito obtenerProductosCarrito(ReqObtenerProductosCarrito req)
        {
            ResObtenerProductosCarrito res = new ResObtenerProductosCarrito();
            try
            {
                if (req.id_usuario <= 0)
                {
                    res.resultado = false;
                    res.error = "ID de usuario incorrecto";
                    return res;
                }

                using (var miLinq = new ConexionLINQDataContext())
                {
                    // Ejecutar el procedimiento almacenado con el id_usuario
                    List<sp_ObtenerProductosCarritoResult> resultSet = miLinq.sp_ObtenerProductosCarrito(req.id_usuario).ToList();

                    // Verificar si hay resultados y mapearlos
                    if (resultSet == null || !resultSet.Any())
                    {
                        res.resultado = false;
                        res.error = "No se encontraron productos en el carrito.";
                    }
                    else
                    {
                        res.listaDeconsultas = resultSet.Select(item => fabricaDeconsultas(item, req.id_usuario)).ToList();
                        res.resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "Error en backend: " + ex.Message;
            }
            return res;
        }

        // Función de fábrica
        private Carrito.consulta fabricaDeconsultas(sp_ObtenerProductosCarritoResult productoLinq, int id_usuario)
        {
            Carrito.consulta consultaFabricada = new Carrito.consulta();
            consultaFabricada.id_usuario = id_usuario;
            consultaFabricada.id_producto = productoLinq.id_producto;
            consultaFabricada.id_carrito = (int)productoLinq.id_carrito;
            consultaFabricada.nombre_producto = productoLinq.nombre_producto;
            consultaFabricada.descripcion = productoLinq.descripcion;
            consultaFabricada.precio_producto = productoLinq.precio_producto;
            consultaFabricada.fecha_agregado = productoLinq.fecha_agregado;
            consultaFabricada.cantidad = (int)productoLinq.cantidad;
            consultaFabricada.tamanho = productoLinq.tamanho;
            consultaFabricada.nombre_tienda = productoLinq.nombre_tienda;


            return consultaFabricada;
        }
        ////Tarjetas

        public ResIngresarTarjeta ingresarTarjeta(ReqIngresarTarjeta req)
        {
            ResIngresarTarjeta res = new ResIngresarTarjeta();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Bad request";
                }
                else
                {
                    if (String.IsNullOrEmpty(req.tarjetas.numero_trajeta))
                    {
                        res.resultado = false;
                        res.error = "numero Incorrecto";
                    }
                    else if (String.IsNullOrEmpty(req.tarjetas.fecha_expiracion))
                    {
                        res.resultado = false;
                        res.error = "fecha Incorrecto";
                    }
                    else if (String.IsNullOrEmpty(req.tarjetas.CVV))
                    {
                        res.resultado = false;
                        res.error = "CVV Incorrecto";
                    }
                    if (req.tarjetas.id_usuario == 0)
                    {
                        res.resultado = false;
                        res.error = "id Incorrecta";
                    }
                    else
                    {
                        {
                            int? returnId = 0;
                            int? errorId = 0;
                            string errorDescripcion = "";


                            ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
                            miLinq.SP_INGRESAR_TARJETA(req.tarjetas.numero_trajeta, req.tarjetas.fecha_expiracion, req.tarjetas.CVV, req.tarjetas.id_usuario, ref returnId, ref errorId, ref errorDescripcion);
                            if (errorId == 0)
                            {
                                // Cierre de sesión exitoso
                                res.resultado = true;
                            }
                            else
                            {
                                // Cierre de sesión fallido
                                res.resultado = false;
                                res.error = string.IsNullOrEmpty(errorDescripcion) ? "Error al cerrar sesión" : errorDescripcion;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "500- Error Interno";
            }

            return res;
        }
        ////listo
        //public ResEliminarTarjeta eliminarTarjeta(ReqEliminarTarjeta req)
        //{
        //    ResEliminarTarjeta res = new ResEliminarTarjeta();

        //    try
        //    {
        //        if (req == null)
        //        {
        //            res.resultado = false;
        //            res.error = "Bad request";
        //        }
        //        else
        //        {
        //            if (String.IsNullOrEmpty(req.tarjetas.numero_trajeta))
        //            {
        //                res.resultado = false;
        //                res.error = "numero Incorrecto";
        //            }
        //            else
        //            {
        //                {
        //                    int? returnId = 0;
        //                    int? errorId = 0;
        //                    string errorDescripcion = "";


        //                    ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
        //                    miLinq.SP_ELIMINAR_TARJETA_POR_NUMERO(req.tarjetas.numero_trajeta, ref errorId, ref errorDescripcion);
        //                    if (errorId == 0)
        //                    {
        //                        // Cierre de sesión exitoso
        //                        res.resultado = true;
        //                    }
        //                    else
        //                    {
        //                        // Cierre de sesión fallido
        //                        res.resultado = false;
        //                        res.error = string.IsNullOrEmpty(errorDescripcion) ? "Error al cerrar sesión" : errorDescripcion;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.resultado = false;
        //        res.error = "500- Error Interno";
        //    }

        //    return res;
        //}
        ////listo
        //public ResActualizarTarjeta actualizarTarjeta(ReqActualizarTarjeta req)
        //{
        //    ResActualizarTarjeta res = new ResActualizarTarjeta();

        //    try
        //    {
        //        if (req == null)
        //        {
        //            res.resultado = false;
        //            res.error = "Bad request";
        //        }
        //        else
        //        {
        //            if (String.IsNullOrEmpty(req.tarjetas.nuevo_numero_trajeta))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";
        //            }
        //            else if (String.IsNullOrEmpty(req.tarjetas.nuevo_numero_trajeta))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";
        //            }
        //            else if (String.IsNullOrEmpty(req.tarjetas.nueva_fecha_expiracion))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";
        //            }
        //            else if (String.IsNullOrEmpty(req.tarjetas.nuevo_CVV))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";
        //            }
        //            else
        //            {
        //                {
        //                    int? errorId = 0;
        //                    string errorDescripcion = "";


        //                    ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
        //                    miLinq.SP_ACTUALIZAR_TARJETA_POR_NUMERO(req.tarjetas.numero_trajeta, req.tarjetas.nuevo_numero_trajeta, req.tarjetas.nueva_fecha_expiracion, req.tarjetas.nuevo_CVV, ref errorId, ref errorDescripcion);
        //                    if (errorId == 0)
        //                    {
        //                        // Cierre de sesión exitoso
        //                        res.resultado = true;
        //                    }
        //                    else
        //                    {
        //                        // Cierre de sesión fallido
        //                        res.resultado = false;
        //                        res.error = string.IsNullOrEmpty(errorDescripcion) ? "Error al cerrar sesión" : errorDescripcion;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.resultado = false;
        //        res.error = "500- Error Interno";
        //    }

        //    return res;
        //}
        ////listo
        public ResObtenerTarjetas obtenerTarjetas(ReqObtenerTarjetas req)
        {
            ResObtenerTarjetas res = new ResObtenerTarjetas();
            try
            {
                if (req.id_usuario <= 0)
                {
                    res.resultado = false;
                    res.error = "ID de usuario incorrecto";
                    return res;
                }

                using (var miLinq = new ConexionLINQDataContext())
                {
                    // Ejecutar el procedimiento almacenado con el id_usuario
                    List<SP_OBTENER_TARJETASResult> resultSet = miLinq.SP_OBTENER_TARJETAS(req.id_usuario).ToList();

                    // Verificar si hay resultados y mapearlos
                    if (resultSet == null || !resultSet.Any())
                    {
                        res.resultado = false;
                        res.error = "No se encontraron tarjetas";
                    }
                    else
                    {
                        res.listaDeconsultas = resultSet.Select(item => fabricaDetarjetas(item, req.id_usuario)).ToList();
                        res.resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "Error en backend: " + ex.Message;
            }
            return res;
        }

        //factoria
        private Tarjetas.consultaTarjeta fabricaDetarjetas(SP_OBTENER_TARJETASResult publicacionLinq, int id_usuario)
        {
            Tarjetas.consultaTarjeta consultadaFabricado = new Tarjetas.consultaTarjeta();
            consultadaFabricado.id_usuario = id_usuario;
            consultadaFabricado.id_tarjeta = publicacionLinq.id_tarjeta;
            consultadaFabricado.numero_trajeta = publicacionLinq.numero_tarjeta;
            consultadaFabricado.fecha_expiracion = publicacionLinq.fecha_expiracion;
            consultadaFabricado.CVV = publicacionLinq.CVV;

            return consultadaFabricado;
        }

        /////faCTURA
        /////
        public ResConsultaFactura generarFactura(ReqConsultaFactura req)
        {
            ResConsultaFactura res = new ResConsultaFactura();
            try
            {
                if (req.id_usuario <= 0)
                {
                    res.resultado = false;
                    res.error = "ID de usuario incorrecto";
                    return res;
                }
                if (req.id_tarjeta <= 0)
                {
                    res.resultado = false;
                    res.error = "ID de tarjeta incorrecto";
                    return res;
                }

                using (var miLinq = new ConexionLINQDataContext())
                {
                    // Ejecutar el procedimiento almacenado con id_usuario y id_tarjeta
                    List<SP_GENERAR_FACTURAResult> resultSet = miLinq.SP_GENERAR_FACTURA(req.id_usuario, req.id_tarjeta).ToList();

                    // Verificar si hay resultados y mapearlos
                    if (resultSet == null || !resultSet.Any())
                    {
                        res.resultado = false;
                        res.error = "No se encontraron productos en el carrito.";
                    }
                    else
                    {
                        res.listaDefacturas = resultSet
                            .Select(item => fabricaDefacturas(item, req.id_usuario, req.id_tarjeta))
                            .ToList();
                        res.resultado = true;
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "Error en backend: " + ex.Message;
            }
            return res;
        }


        // Función de fábrica
        private Factura.Consultar fabricaDefacturas(SP_GENERAR_FACTURAResult productoLinq, int id_usuario, int id_tarjeta)
        {
            Factura.Consultar consultaFabricada = new Factura.Consultar();
            consultaFabricada.id_usuario = id_usuario;
            consultaFabricada.id_tarjeta = id_tarjeta;
            consultaFabricada.id_factura = productoLinq.id_factura;
            consultaFabricada.fecha = productoLinq.fecha;
            consultaFabricada.nombre_usuario = productoLinq.nombre_usuario;
            consultaFabricada.cedula = productoLinq.cedula;
            consultaFabricada.nombre_producto = productoLinq.nombre_producto;
            consultaFabricada.precio_producto = (decimal?)productoLinq.precio_producto;
            consultaFabricada.cantidad = (int)productoLinq.cantidad;
            consultaFabricada.subtotal = (decimal?)productoLinq.subtotal;
            consultaFabricada.monto_total = productoLinq.monto_total;

            return consultaFabricada;
        }

        /////tiendas
        /////
        public ResIngresarTienda insertarTienda(ReqIngresarTienda req)
        {
            ResIngresarTienda res = new ResIngresarTienda();

            try
            {
                if (req == null)
                {
                    res.resultado = false;
                    res.error = "Bad request";
                }
                else
                {
                    if (String.IsNullOrEmpty(req.tiendas.nombre))
                    {
                        res.resultado = false;
                        res.error = "Nombre Incorrecto";

                    }

                    else
                    {
                        int? returnId = 0;
                        int? errorId = 0;
                        string errorDescripcion = "";

                        ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
                        miLinq.SP_AGREGAR_TIENDA(req.tiendas.nombre, ref returnId, ref errorId, ref errorDescripcion);
                        if (returnId <= 0 || returnId == null)
                        {

                            res.resultado = false;
                            res.error = errorDescripcion;
                        }
                        else
                        {
                            //todo paso bien

                            res.resultado = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "500- Error Interno";
            }

            return res;
        }

        //
        //public ResActualizarTienda actualizarTienda(ReqActualizarTienda req)
        //{
        //    ResActualizarTienda res = new ResActualizarTienda();

        //    try
        //    {
        //        if (req == null)
        //        {
        //            res.resultado = false;
        //            res.error = "Bad request";
        //        }
        //        else
        //        {
        //            if (String.IsNullOrEmpty(req.tiendas.nombre))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";

        //            }

        //            else
        //            {
        //                int? returnId = 0;
        //                int? errorId = 0;
        //                string errorDescripcion = "";

        //                ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
        //                miLinq.SP_AGREGAR_TIENDA(req.tiendas.nombre, ref returnId, ref errorId, ref errorDescripcion);
        //                if (returnId <= 0 || returnId == null)
        //                {

        //                    res.resultado = false;
        //                    res.error = errorDescripcion;
        //                }
        //                else
        //                {
        //                    //todo paso bien

        //                    res.resultado = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.resultado = false;
        //        res.error = "500- Error Interno";
        //    }

        //    return res;
        //}
        ////
        //public ResEliminarTienda eliminarTienda(ReqEliminarTienda req)
        //{
        //    ResEliminarTienda res = new ResEliminarTienda();

        //    try
        //    {
        //        if (req == null)
        //        {
        //            res.resultado = false;
        //            res.error = "Bad request";
        //        }
        //        else
        //        {
        //            if (String.IsNullOrEmpty(req.tiendas.nombre))
        //            {
        //                res.resultado = false;
        //                res.error = "Nombre Incorrecto";

        //            }

        //            else
        //            {
        //                int? returnId = 0;
        //                int? errorId = 0;
        //                string errorDescripcion = "";

        //                ConexionLINQDataContext miLinq = new ConexionLINQDataContext();
        //                miLinq.SP_AGREGAR_TIENDA(req.tiendas.nombre, ref returnId, ref errorId, ref errorDescripcion);
        //                if (returnId <= 0 || returnId == null)
        //                {

        //                    res.resultado = false;
        //                    res.error = errorDescripcion;
        //                }
        //                else
        //                {
        //                    //todo paso bien

        //                    res.resultado = true;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        res.resultado = false;
        //        res.error = "500- Error Interno";
        //    }

        //    return res;
        //}

        public ResObtenerTiendas obtenerTiendas()
        {
            ResObtenerTiendas res = new ResObtenerTiendas();
            try
            {
                ConexionLINQDataContext miLinq = new ConexionLINQDataContext();

                List<SP_OBTENER_TIENDASResult> resultSet = new List<SP_OBTENER_TIENDASResult>();

                resultSet = miLinq.SP_OBTENER_TIENDAS().ToList();

                foreach (SP_OBTENER_TIENDASResult unaPublicacionLinq in resultSet)
                {
                    res.listaDeconsultas.Add(this.fabricaDePublicacion(unaPublicacionLinq));

                }
                res.resultado = true;
            }
            catch (Exception ex)
            {
                res.resultado = false;
                res.error = "Error en backend";
            }
            return res;
        }

        //factoria
        private Tiendas.ConsultarTiendas fabricaDePublicacion(SP_OBTENER_TIENDASResult publicacionLinq) // este fue para obtener publicaciones
        {
            Tiendas.ConsultarTiendas tiendaFabricado = new Tiendas.ConsultarTiendas();
            tiendaFabricado.nombre = publicacionLinq.Nombre;


            return tiendaFabricado;
        }

    }
}
